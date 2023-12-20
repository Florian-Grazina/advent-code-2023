
namespace _20.Modules
{
    internal abstract class Module
    {
        public string Id { get; set; }
        public Pulse? LastPulseReceived { get; set; } = null;
        public Pulse? LastPulseSend { get; set; } = null;
        public List<string> LinkedModules { get; set; } = [];


        public Module(string input)
        {
            if(this is Output)
            {
                Id = input;
            }
            else 
                Parse(input);
        }

        private void Parse(string input)
        {
            string[] values = input.Split(" -> ");
            Id = values[0][1..];
            LinkedModules = [.. values[1].Split(", ")];
        }

        public void ReceivePulse(Pulse pulse)
        {
            LastPulseReceived = pulse;
            ModuleFactory.Queue.Enqueue(new(this, pulse));
        }

        protected void SendPulse(Pulse pulse)
        {
            foreach (string moduleId in LinkedModules)
            {
                if (pulse == Pulse.low)
                    ModuleFactory.LowPulses++;
                else
                    ModuleFactory.HighPulses++;

                //Console.WriteLine($"{Id} - {pulse} -> {moduleId}");

                Module receivingModule = ModuleFactory.ListModules.FirstOrDefault(m => m.Id == moduleId);

                if (receivingModule == null)
                    continue;

                LastPulseSend = pulse;

                receivingModule.ReceivePulse(pulse);
            }
        }

        public abstract void Release(Pulse pulse);
    }
}
