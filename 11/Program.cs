using _11_12;

string[] input = File.ReadAllLines("../../../input.txt");

List<List<char>> map = [];
List<Node> nodes = [];
int growth = 999999;


for (int y = 0; y < input.Length; y++)
{
    map.Add([.. input[y].ToCharArray()]);

    if (input[y].ToCharArray().All(c => c == '.'))
        nodes.Add(new Expand(0, y));
}

for (int x = 0; x < map[0].Count; x++)
{
    bool needToExpend = true;

    for(int y = 1; y < map.Count; y++)
    {
        if (map[y][x] != map[y - 1][x])
        {
            needToExpend = false;
            break;
        }
    }

    if (needToExpend)
        nodes.Add(new Expand(x, 0));
}


for (int y = 0; y < map.Count; y++)
{
    for (int x = 0; x < map[0].Count; x++)
    {
        if (map[y][x] == '#')
            nodes.Add(new Galaxy(x, y));
    }
}

List<Expand> expandsY = nodes.OfType<Expand>().Where(e => e.Coords[0] == 0).ToList();
List<Expand> expandsX = nodes.OfType<Expand>().Where(e => e.Coords[1] == 0).ToList();

foreach(Expand expand in expandsY)
{
    nodes.Where(n => n.Coords[1] > expand.Coords[1]).ToList().ForEach(n => n.Coords[1] += growth);
}

foreach (Expand expand in expandsX)
{
    nodes.Where(n => n.Coords[0] > expand.Coords[0]).ToList().ForEach(n => n.Coords[0] += growth);
}


List<Galaxy> galaxies = nodes.OfType<Galaxy>().ToList();

foreach (Galaxy galaxy in galaxies)
{
    galaxy.CalculateSteps(galaxies.Where(g => g.Id != galaxy.Id && g.Steps == 0).ToList());
}

Console.WriteLine(galaxies.Sum(g => g.Steps));