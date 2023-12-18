using _15;
using System.Text.RegularExpressions;

string[] input = File.ReadAllText("../../../input.txt").Split(',');
List<Box> boxes = [];

for(int i = 0; i < 256; i++)
    boxes.Add(new Box());

int result = 0;

foreach(string line in input)
{
    int index = 0;

    Match match = Regex.Match(line, @"^\w+");

    foreach(char c in match.Value)
    {
        index += Convert.ToByte(c);
        index *= 17;
        index %= 256;
    }

    string lens = line.Replace('=', ' ').Replace('-', ' ');

    if(match.Value == "ot")
        Console.WriteLine();

    if (line.Contains('='))
    {
        if (boxes[index].Lenses.Contains(match.Value))
            boxes[index].Lenses[match.Value] = int.Parse(lens.Split(' ')[1]);
        else
            boxes[index].AddLens(lens);
    }

    if (line.Contains('-'))
    {
        if (boxes[index].Lenses.Contains(match.Value))
            boxes[index].Lenses.Remove(match.Value);
    }
}

int boxIndex = 1;
foreach(Box box in boxes)
{
    int boxRes = 0;

    var keyCollection = box.Lenses.Keys;
    string[] myKeys = new string[box.Lenses.Count];
    keyCollection.CopyTo(myKeys, 0);

    for (int i = 0; i < box.Lenses.Count; i++)
    {
        int lensValue = boxIndex * (i + 1) * (int)box.Lenses[myKeys[i]];
        boxRes += lensValue;
    }

    result += boxRes;
    boxIndex++;
}

Console.WriteLine(result);