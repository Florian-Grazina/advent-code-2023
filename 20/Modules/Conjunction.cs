using _20.Modules;

namespace _20
{
    internal class Conjunction(string input) : Module(input)
    {
        public List<Module> InputModules;

        public void UpdateInput()
        {
            InputModules = ModuleFactory.ListModules.Where(m => m.LinkedModules.Contains(Id)).ToList();
        }

        public override void Release(Pulse pulse)
        {
            if (InputModules.All(v => v.LastPulseSend == Pulse.high))
                SendPulse(Pulse.low);
            else
                SendPulse(Pulse.high);
        }
    }
}
