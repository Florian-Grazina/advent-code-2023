string[] input = File.ReadAllLines("../../../input.txt");

string[,] map = new string[input[0].Length, input.Length];

Dictionary<int, int> results = [];

// mapping
for (int y = 0; y < input.Length; y++)
{
    for(int x = 0; x < input[0].Length; x++)
    {
        map[x,y] = input[y][x].ToString();
    }
}


// Cycles
for(int nbCycle = 1000000000; nbCycle >= 0; nbCycle--)
{
    MoveUp();
    MoveLeft();
    MoveDown();
    MoveRight();

    if (nbCycle < 1000000000 - 114)
    {
        while(nbCycle > 42)
        {
            nbCycle -= 42;
        }
    }
}

Console.WriteLine(GetResult());



// calculate result
int GetResult()
{
    int result = 0;
    for (int y = 0; y < map.GetLength(1); y++)
    {
        int res = Enumerable.Range(0, map.GetLength(1))
                            .Select(x => map[x, y])
                            .ToArray()
                            .Count(m => m == "O");

        result += res * (map.GetLength(1) - y);
    }

    return result;
}




void MoveUp()
{
    for (int y = 0; y < map.GetLength(1); y++)
    {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            if (map[x,y] == "O")
                MoveRockUp(x, y);
        }
    }
}

void MoveDown()
{
    for (int y = map.GetLength(1) - 1; y >= 0 ; y--)
    {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            if (map[x,y] == "O")
                MoveRockDown(x, y);
        }
    }
}

void MoveLeft()
{
    for (int x = 0; x < map.GetLength(0); x++)
    {
        for(int y = 0; y < map.GetLength(1); y++)
        {
            if (map[x,y] == "O")
                MoveRockLeft(x, y);
        }
    }
}

void MoveRight()
{
    for (int x = map.GetLength(0) - 1; x >= 0; x--)
    {
        for (int y = 0; y < map.GetLength(1); y++)
        {
            if (map[x,y] == "O")
                MoveRockRight(x, y);
        }
    }
}


void MoveRockUp(int x, int y)
{
    if (y == 0)
        return;

    if (map[x, y-1] == ".")
    {
        map[x, y-1] = "O";
        map[x, y] = ".";
        MoveRockUp(x, y-1);
    }
}

void MoveRockDown(int x, int y)
{
    if (y == map.GetLength(1) - 1)
        return;

    if (map[x, y + 1] == ".")
    {
        map[x, y + 1] = "O";
        map[x, y] = ".";
        MoveRockDown(x, y + 1);
    }
}

void MoveRockRight(int x, int y)
{
    if (x == map.GetLength(0) - 1)
        return;

    if (map[x + 1, y] == ".")
    {
        map[x + 1, y] = "O";
        map[x, y] = ".";
        MoveRockRight(x + 1, y);
    }
}

void MoveRockLeft(int x, int y)
{
    if(x == 0)
        return;

    if (map[x - 1, y] == ".")
    {
        map[x - 1, y] = "O";
        map[x, y] = ".";
        MoveRockLeft(x - 1, y);
    }
}


void Print()
{
    for (int y = 0; y < map.GetLength(1); y++)
    {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            Console.Write(map[x, y]);
        }
        Console.WriteLine();
    }
}
