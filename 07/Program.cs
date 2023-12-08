using _07_12;

string[] input = File.ReadAllLines("../../../input.txt");
List<Hand> hands = [];

foreach(string line in input)
{
    string[] splittedLine = line.Split(" ");
    hands.Add(new Hand(splittedLine[0], int.Parse(splittedLine[1])));
}

hands = [.. hands.OrderBy(h => h.Value)];

for(int i = 0; i < hands.Count; i++)
{
    hands[i].Rank = i + 1;
}

Console.WriteLine(hands.Sum(h => h.Rank * h.Bids));