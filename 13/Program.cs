using _13;

string input = File.ReadAllText("../../../input.txt");
string[] splittedInput = input.Split("\r\n\r\n");

List<Pattern> patterns = [];

foreach(string line in splittedInput)
{
    Pattern pattern = new(line.Split("\r\n"));
    patterns.Add(pattern);
    pattern.CheckMirrors();
}

foreach(Pattern pattern in patterns)
{
    if (pattern.NbOfColumns > pattern.NbOfRows && pattern.NbOfRows > 0)
        pattern.NbOfColumns = 0;
    if (pattern.NbOfRows >= pattern.NbOfColumns && pattern.NbOfColumns > 0)
        pattern.NbOfRows = 0;
}

for(int i = 0; i < patterns.Count; i++)
{
    if (patterns[i].NbOfColumns > 0 && patterns[i].NbOfRows > 0)
    {
        Console.WriteLine(i);
    }
}


Console.WriteLine(patterns.Sum(p => p.NbOfColumns + p.NbOfRows * 100));