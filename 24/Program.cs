namespace _24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input.txt");
            List<Hailstone> hailstones = [];

            foreach (string line in input)
            {
                hailstones.Add(new Hailstone(line));
            }

            for(long i = 0; i < 1000000;  i++)
            {
                hailstones.ForEach(h => h.Move());

                var groupedHail = hailstones.GroupBy(h => new { h.X, h.Y });
                var starsWithSameCoordsCount = groupedHail.Where(group => group.Count() > 1).ToList();

                if(starsWithSameCoordsCount.Count > 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
