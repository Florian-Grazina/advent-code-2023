namespace _19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input-test.txt");

            double unit = 256000000000000;
            double A = 0;
            double R = 0;
            List<Command> listCommands = [];

            foreach (string command in input)
                listCommands.Add(new Command(command));

            listCommands.First(c => c.Id == "in").Unit = unit;


            // process
            while(listCommands.Sum(c => c.Unit) > 0)
            {
                List<Command> commandsToProcess = listCommands.Where(c => c.Unit > 0).ToList();

                foreach (var command in commandsToProcess)
                {
                    if(command.Id == "qqz")
                        Console.WriteLine();

                    Dictionary<string, double> result = command.Test();

                    foreach(KeyValuePair<string, double> kvp in result)
                    {
                        if (kvp.Key == "A")
                            A += kvp.Value;

                        else if (kvp.Key == "R")
                            R += kvp.Value;

                        else
                            listCommands.First(c => c.Id == kvp.Key).Unit = kvp.Value;
                    }
                }
            }

            Console.WriteLine(A);
        }
    }
}
