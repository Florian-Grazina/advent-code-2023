namespace _21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input.txt");
            Plot start = Garden.Generate(input);
            List<Plot> plots = [start];
            int steps = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < steps; i ++)
            {
                List<Plot> newPlots = [];
                foreach(Plot plot in plots)
                {
                    newPlots.AddRange(plot.Step());
                }

                plots = newPlots.Distinct().ToList();
            }

            Console.WriteLine(plots.Count);
        }
    }
}
