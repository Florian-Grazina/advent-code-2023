string[] input = File.ReadAllLines("../../../large.txt");
int result = 0;
Dictionary<string, int> spelledDigits = new()
{
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four", 4},
    {"five", 5},
    {"six", 6},
    {"seven", 7},
    {"eight", 8},
    {"nine", 9}
};


foreach (string line in input)
{
    List<char> digitInLine = new();

    for (int i = 0; i < line.Length; i++)
    {
        char c = line[i];
        int spelledDigit = IsCharSpelledDigit(line, i);

        // check if char is letter
        if (spelledDigit != 0)
            digitInLine.Add(char.Parse(spelledDigit.ToString()));

        // check if char is digit
        if (int.TryParse(c.ToString(), out _))
            digitInLine.Add(c);
    }

    using StreamWriter sw = new("../../../nico.txt", true);


    string lineResult = $"{digitInLine[0]}{digitInLine[^1]}";
    sw.WriteLine(lineResult);
    result += int.Parse(lineResult);
}

int IsCharSpelledDigit(string line, int index)
{
    foreach(string spelledDigit in spelledDigits.Keys)
    {
        bool isDigit = false;

        if (line.Length - index < spelledDigit.Length)
            continue;

        for(int i = 0; i < spelledDigit.Length; i++)
        {
            if (spelledDigit[i] != line[index + i])
            {
                isDigit = false;
                break;
            }
            isDigit = true;
        }

        if (isDigit)
            return spelledDigits[spelledDigit];
    }

    return 0;
}

Console.WriteLine(result);