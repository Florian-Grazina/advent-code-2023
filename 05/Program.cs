using _05;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

string[] input = File.ReadAllLines("../../../input.txt");
string[] inputTrimmed = input.Where(x => !string.IsNullOrEmpty(x)).ToArray();


List<Seed> seeds = [];
List<long> seedsInput = inputTrimmed[0].Split(": ")[1].Split(" ").Select(long.Parse).ToList();

for (int i = 0; i < seedsInput.Count; i += 2)
{
    seeds.Add(new Seed(seedsInput[i], seedsInput[i + 1]));
}

for (int i = 1; i < inputTrimmed.Length; i++)
{
    string[] splittedLine = inputTrimmed[i].Split(" ");

    if (long.TryParse(splittedLine[0].ToString(), out _))
        ExecCommand(splittedLine[0], splittedLine[1], splittedLine[2]);
    else
    {
        Reset();
    }
    Console.WriteLine(i);
}
Reset();

File.WriteAllText(AppContext.BaseDirectory + "answer.txt", seeds.Min(s => s.Locations[0]).ToString());

void ExecCommand(string destinationString, string sourceString, string rangeString)
{
    long destination = long.Parse(destinationString);
    long source = long.Parse(sourceString);
    long delta = destination - source;
    long range = long.Parse(rangeString);

    List<Seed> seedsToAdd = [];

    for (int i = 0; i < seeds.Count; i++)
    {
        if (seeds[i].IsMapped)
            continue;

        if (seeds[i].Locations[0] > source + range)
            continue;

        if (seeds[i].Locations[1] < source)
            continue;

        if (seeds[i].Locations[0] >= source && seeds[i].Locations[1] >= source + range)
        {
            seedsToAdd.Add(new Seed(seeds[i].Locations[0] + delta, source + range + delta));
            seeds[i].Locations[0] = source + range;
        }

        else if (seeds[i].Locations[0] <= source && seeds[i].Locations[1] <= source + range)
        {
            seedsToAdd.Add(new Seed(source + delta, seeds[i].Locations[1] + delta));
            seeds[i].Locations[1] = source;
        }

        else if (seeds[i].Locations[0] >= source && seeds[i].Locations[1] <= source + range)
        {
            seeds[i].Locations[0] += delta;
            seeds[i].Locations[1] += delta;
            seeds[i].IsMapped = true;
        }

        else if (seeds[i].Locations[0] <= source && seeds[i].Locations[1] >= source + range)
        {
            var seed1 = new Seed(seeds[i].Locations[0], source) { IsMapped = false };
            seeds[i].Locations = [source, source + range];
            seeds[i].IsMapped = true;
            var seed3 = new Seed(seeds[i].Locations[1], source + delta) { IsMapped = false };

            seedsToAdd.AddRange([seed1, seed3]);
        }
    }
    seeds.AddRange(seedsToAdd);
    seedsToAdd.Clear();
}

void Reset()
{
    foreach (Seed seed in seeds)
    {
        seed.IsMapped = false;
    }
}

