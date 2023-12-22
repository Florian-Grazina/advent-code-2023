namespace _16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input.txt");


            Grid.Generate(input);


            List<long> results = [];

            for (int i = 0; i < 4; i++)
            {
                if (i == (int)Direction.left)
                    for(int y = 0; y < Grid.Map.GetLength(1); y++)
                        Run(Grid.Map.GetLength(0), y, (Direction)i);

                if (i == (int)Direction.right)
                    for (int y = 0; y < Grid.Map.GetLength(1); y++)
                        Run(0, y, (Direction)i);

                if (i == (int)Direction.top)
                    for (int x = 0; x < Grid.Map.GetLength(0); x++)
                        Run(x, Grid.Map.GetLength(0), (Direction)i);

                if (i == (int)Direction.bot)
                    for (int x = 0; x < Grid.Map.GetLength(0); x++)
                        Run(x, 0, (Direction)i);
            }


            void Run(int coordx, int coordy, Direction dir)
            {
                // test
                Grid.Generate(input);
                Grid.ListLaser.Add(new((coordx, coordy), dir));

                while (!Grid.ListLaser.All(l => l.IsActive == false))
                {
                    Grid.Move();
                }

                // result
                long res = 0;

                for (int y = 0; y < Grid.Map.GetLength(1); y++)
                {
                    for (int x = 0; x < Grid.Map.GetLength(0); x++)
                    {
                        if (Grid.Map[x, y].IsEnergized)
                            res++;
                    }
                }
                Console.WriteLine(res);
                results.Add(res);
            }

            Console.WriteLine(results.Max());
        }
    }
}
