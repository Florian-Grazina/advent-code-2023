using _12;

string[] input = File.ReadAllLines("../../../input.txt");

List<Spring> springs = [];

foreach(string line in input)
{
    Spring spring = new(line.Split(' ')[0], line.Split(' ')[1].Split(',').Select(int.Parse).ToList());
    spring.GenerateCombinations();
    springs.Add(spring);
}

Console.WriteLine(springs.Sum(s => s.Possibilities));
