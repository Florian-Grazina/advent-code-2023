using _20.Modules;

namespace _20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input.txt");

            foreach (string line in input)
            {
                ModuleFactory.CreateModule(line);
            }

            Broadcaster broadcaster = (Broadcaster)ModuleFactory.ListModules.First(m => m.Id == "roadcaster");

            // list all linked modules
            List<string> mods = ModuleFactory.ListModules.SelectMany(m => m.LinkedModules).ToList();
            foreach(string mod in mods)
            {
                if(ModuleFactory.ListModules.FirstOrDefault(m => m.Id == mod) == null)
                    ModuleFactory.ListModules.Add(new Output(mod));
            }

            ModuleFactory.ListModules.OfType<Conjunction>().ToList().ForEach(c => c.UpdateInput());

            // push button

            Output rx = (Output)ModuleFactory.ListModules.First(m => m.Id == "rx");

            long button = 0;

            while(rx.LastPulseReceived != Pulse.low)
            {
                button++;
                Console.Clear();
                Console.WriteLine(button);

                broadcaster.PushButton();
                while (ModuleFactory.Queue.TryPeek(out _))
                    ModuleFactory.Queue.Dequeue().Release();
            }

            Console.WriteLine(button);

            // 833083290 too high
            // 833109122
        }
    }
}
