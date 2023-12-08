
using _03_12;

string[] lines = File.ReadAllLines("../../../input.txt");

List<CoordNumber> coordNumbers = new();
List<int> coordGearRatio = new();
List<int> mapGearRatio = new()
{
    - 1 - lines[0].Length,
    + 0 - lines[0].Length,
    + 1 - lines[0].Length,

    - 1,
    + 1,

    - 1 + lines[0].Length,
    + 0 + lines[0].Length,
    + 1 + lines[0].Length,
};

SetCoords();


// compare coordNumber of all possibleCoords
long answer = 0;

foreach(int coord in coordGearRatio)
{
    int gearRatio = 1;
    HashSet<int> possibleGearRatioCoords = new();
    mapGearRatio.ForEach(m => possibleGearRatioCoords.Add(coord + m));

    HashSet<CoordNumber> listGearRatio = new();

    foreach (CoordNumber coordNumber in coordNumbers)
    {
        if (possibleGearRatioCoords.Intersect(coordNumber.Coord).Any())
            listGearRatio.Add(coordNumber);
    }

    if (listGearRatio.Count != 2)
        continue;

    answer += listGearRatio.Select(obj => obj.Number).Aggregate((current, next) => current * next);
}

Console.WriteLine(answer);


void SetCoords()
{
    for(int indexLine = 0; indexLine < lines.Length; indexLine++)
    {
        string numberToMap = string.Empty;

        for (int i = 0; i < lines[indexLine].Length; i++)
        {
            if (int.TryParse(lines[indexLine][i].ToString(), out int nb) )
            {
                numberToMap += nb;
            }

            // catch the symbols
            else if (lines[indexLine][i] == '*')
            {
                coordGearRatio.Add(indexLine * lines[indexLine].Length + i + 1);
            }
            // ---------------

            if (!string.IsNullOrEmpty(numberToMap))
            {
                if(i == lines[indexLine].Length - 1)
                {
                    AddCoords(indexLine, i, numberToMap);
                    numberToMap = string.Empty;
                }

                else if (!int.TryParse(lines[indexLine][i+1].ToString(), out _))
                {
                    AddCoords(indexLine, i, numberToMap);
                    numberToMap = string.Empty;
                }
            }
        }
    }
    Console.WriteLine(coordNumbers);
}


void AddCoords(int indexLine, int i, string numberToMap)
{
    List<int> listCoords = new();

    int coord = indexLine * lines[indexLine].Length + i + 1;
    for (int j = 0; j < numberToMap.Length; j++)
    {
        listCoords.Add(coord - j);
    }

    coordNumbers.Add(new CoordNumber()
    {
        Number = int.Parse(numberToMap),
        Coord = listCoords
    });
}