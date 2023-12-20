
namespace _20.Modules
{
    internal static class ModuleFactory
    {
        public static List<Module> ListModules = [];
        public static long LowPulses { get; set; } = 0;
        public static long HighPulses { get; set; } = 0;
        public static Queue<Command> Queue = [];


        public static void CreateModule(string input)
        {
            ListModules.Add(input[0] switch
            {
                '%' => new FlipFlop(input),
                'b' => new Broadcaster(input),
                '&' => new Conjunction(input),
                _ => new Output(input)
            });
        }
    }

    public enum Pulse
    {
        high,low
    }
}
