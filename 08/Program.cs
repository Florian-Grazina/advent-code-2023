using _08;
using System.Text.RegularExpressions;

string[] input = File.ReadAllLines("../../../input.txt");

string command = input[0];
List<Node> nodes = [];

for (int i = 2; i < input.Length; i++)
{
    MatchCollection matches = Regex.Matches(input[i], @"(\w\w\w)");
    nodes.Add(new Node(matches[0].Value, [matches[1].Value, matches[2].Value]));
}

List<Node> actualLocations = nodes.Where(n => n.Location[2] == 'A').ToList();

List<Route> routes = [];

foreach (Node node in actualLocations)
{
    routes.Add(new Route(node));
}

foreach (Route route in routes)
{
    Console.WriteLine("Calculating route");
    while (route.ActiveNode.Location[2] != 'Z')
    {
        if (command[(int)route.NumberOfSteps % command.Length] == 'L')
            route.ActiveNode = nodes.Where(n => n.Location == route.ActiveNode.Network[0]).First();
        if (command[(int)route.NumberOfSteps % command.Length] == 'R')
            route.ActiveNode = nodes.Where(n => n.Location == route.ActiveNode.Network[1]).First();
        route.NumberOfSteps ++;
    }
    Console.WriteLine("Done");
}

long result = 1;
foreach (Route route in routes)
{
    result = LCM(result, route.NumberOfSteps);
}

static long GCF(long a, long b)
{
    while (b != 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

static long LCM(long a, long b)
{
    return a / GCF(a, b) * b;
}

Console.WriteLine(result);