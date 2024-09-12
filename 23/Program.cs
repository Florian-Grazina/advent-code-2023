namespace _23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input.txt");

            // mapping
            var map = new string[input[0].Length, input.Length];
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    map[x, y] = input[y][x].ToString();
                }
            }

            // hiking
            Logs.Hikes.Add(new(map, (1, 0), 0));

            while(Logs.Hikes.Any(h => h.IsActive))
            {
                foreach(Hike hike in Logs.Hikes)
                {
                    hike.Start();
                }

                Logs.Hikes = Logs.NewHikes;
                Logs.NewHikes = [];
            }

            Console.WriteLine(Logs.LongestHike);
        }
    }
}
