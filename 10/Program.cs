using _10;

string[] input = File.ReadAllLines("../../../input.txt");

Location location = new();

foreach (string line in input)
{
    if (line.Contains('S'))
    {
        location.X = line.IndexOf('S');
        location.Y = location.Map.Count();
    }
    location.Map.Add(line.ToCharArray());
}

Console.WriteLine(location.Navigate());
