using _06;
using System.Text.RegularExpressions;

string[] input = File.ReadAllLines("../../../input.txt");

MatchCollection timeMatches = Regex.Matches(input[0], @" (\d+)");
MatchCollection distMatches = Regex.Matches(input[1], @" (\d+)");

List<Race> races = [];

for (int i = 0; i < timeMatches.Count; i++)
{
    races.Add(new Race(
        long.Parse(timeMatches[i].Groups[1].Value),
        long.Parse(distMatches[i].Groups[1].Value)
        ));
}

foreach(Race race in races)
{
    for (long timePressing = 1; timePressing < race.Time; timePressing++)
    {
        race.CalculateDistance(timePressing);
    }
}

Console.WriteLine(races.Select(r => r.BeatRecord).Aggregate((old, dist) => old * dist));
