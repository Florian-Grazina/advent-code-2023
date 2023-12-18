namespace _18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input-test.txt");
            //string[] input = File.ReadAllLines("../../../input.txt");

            // map
            //int maxX = 500;
            //int maxY = 350;
            (long, long) coord = (0, 0);

            List<(long, long)> coords = [];
            int result = 0;
            

            // commands
            List<Command> commands = [];
            foreach (string line in input)
                commands.Add(new Command(line));

            // process
            foreach (Command command in commands)
            {
                (long, long) move = command.Move();
                coord = AddTuples(coord, move);
                coords.Add(coord);
            }

            //FloodFill(map, 100, 100);
            //Print();
            Console.WriteLine(CalculatePolygonArea(coords) + commands.Sum(c => c.Steps));


            static long CalculatePolygonArea(List<(long, long)> coordinates)
            {
                int n = coordinates.Count;

                long sum = 0;

                for (int i = 0; i < n - 1; i++)
                {
                    sum += (coordinates[i].Item1 * coordinates[i + 1].Item2 - coordinates[i + 1].Item1 * coordinates[i].Item2);
                }

                // Add the contribution of the last edge
                sum += (coordinates[n - 1].Item1 * coordinates[0].Item2 - coordinates[0].Item1 * coordinates[n - 1].Item2);

                // Calculate the absolute value and divide by 2
                return Math.Abs(sum) / 2;
            }


            (long, long) AddTuples((long, long) tuple1, (long, long) tuple2)
            {
                long sum1 = tuple1.Item1 + tuple2.Item1;
                long sum2 = tuple1.Item2 + tuple2.Item2;

                Console.WriteLine();
                return (sum1, sum2);
            }

            //void Draw()
            //{
            //    map[coord.Item1, coord.Item2] = "#";
            //}

            //void Print()
            //{
            //    for (int y = 0; y < map.GetLength(1); y++)
            //    {
            //        for (int x = 1; x < map.GetLength(0); x++)
            //        {
            //            if (map[x, y] == "#")
            //                result++;

            //            Console.Write(map[x, y]);
            //        }
            //        Console.WriteLine();

            //    }
            //}

            void FloodFill(string[,] loop, int x, int y)
            {
                int columns = loop.GetLength(0);
                int rows = loop.GetLength(1);

                Queue<(int, int)> queue = [];

                queue.Enqueue((x, y));

                while (queue.Count > 0)
                {
                    var (col, row) = queue.Dequeue();

                    if (row >= 0 && row < rows && col >= 0 && col < columns && loop[col, row] == ".")
                    {
                        loop[col, row] = "#";

                        queue.Enqueue((col - 1, row));
                        queue.Enqueue((col + 1, row));
                        queue.Enqueue((col, row - 1));
                        queue.Enqueue((col, row + 1));
                        queue.Enqueue((col - 1, row - 1));
                        queue.Enqueue((col - 1, row + 1));
                        queue.Enqueue((col + 1, row - 1));
                        queue.Enqueue((col + 1, row + 1));
                    }
                }
            }
        }
    }
}
