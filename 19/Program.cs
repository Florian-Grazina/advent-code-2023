namespace _19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input-test.txt");

            double unitTotal = 256000000000000;
            double A = 0;
            double R = 0;
            List<Command> listCommands = [];
            List<Units> listUnits = [];

            foreach (string command in input)
                listCommands.Add(new Command(command));

            listUnits.Add(new(unitTotal, (1, 4000), (1, 4000), (1, 4000), (1, 4000), "in"));


            // process
            while(A + R != unitTotal)
            {
                List<Units> result = [];

                foreach (Units unit in listUnits)
                {
                    result.AddRange(listCommands.First(c => c.Id == unit.Command).Test());

                    foreach (Units res in result)
                    {
                        if (res.Command == "A")
                            A += res.Number;

                        else if (res.Command == "R")
                            R += res.Number;
                    }
                }

                listUnits.AddRange(result.Where(u => u.Command != "A" && u.Command != "R"));
                listUnits.RemoveAll(u => u.Number == 0);
            }

            Console.WriteLine(A);
        }
    }
}
