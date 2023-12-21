namespace _19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input.txt");

            long unitTotal = 256000000000000;
            long A = 0;
            long R = 0;
            List<Command> listCommands = [];
            List<Units> listUnits = [];

            foreach (string command in input)
                listCommands.Add(new Command(command));

            listUnits.Add(new(unitTotal, (1, 4000), (1, 4000), (1, 4000), (1, 4000), "in"));


            // process
            while(A + R < unitTotal)
            {
                List<Units> result = [];

                foreach (Units unit in listUnits)
                {
                    result.AddRange(listCommands.First(c => c.Id == unit.Command).Test(unit));

                    foreach (Units res in result)
                    {
                        if (res.Command == "A")
                        {
                            A += res.Number;
                            res.Number = 0;
                        }

                        else if (res.Command == "R")
                        {
                            R += res.Number;
                            res.Number = 0;
                        }
                    }
                }

                listUnits.AddRange(result.Where(u => u.Command != "A" && u.Command != "R"));
                listUnits.RemoveAll(u => u.Number == 0);
            }
            Console.WriteLine(R);
            Console.WriteLine(A);
        }
    }
}
