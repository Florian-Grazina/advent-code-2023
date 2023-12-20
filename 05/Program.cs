using _05;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

string[] input = File.ReadAllLines("../../../input.txt");
string[] inputTrimmed = input.Where(x => !string.IsNullOrEmpty(x)).ToArray();


List<Seed> seeds = [];
List<Command> commands = [];
Soil soilType = 0;
List<long> seedsInput = inputTrimmed[0].Split(": ")[1].Split(" ").Select(long.Parse).ToList();

foreach(string line in inputTrimmed)
{
    if (int.TryParse(line[0].ToString(), out _))
    {
        long[] values = line.Split(' ').Select(long.Parse).ToArray();
        commands.Add(new(values[0], values[1], values[2], soilType));
    }
    else
        soilType++;
}

commands.Reverse();

for (int i = 0; i < seedsInput.Count; i += 2)
{
    seeds.Add(new Seed(seedsInput[i], seedsInput[i]));
}

long indexSeed = 0;

while(true)
{
    indexSeed++;
    long tempIndex = indexSeed;

    for(int i = 8; i > 1; i--)
    {
        List<Command> steps = commands.Where(c => c.Soil == (Soil)i).ToList();
        foreach(Command c in steps)
        {
            long move = c.Move(tempIndex);

            if (move != 0)
            {
                tempIndex += move;
                break;
            }
        }
    }

    if (seeds.Any(s => s.isInRange(tempIndex)))
    {
        Console.WriteLine(tempIndex);
        break;
    }
}
