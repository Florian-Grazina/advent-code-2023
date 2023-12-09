string[] input = File.ReadAllLines("../../../input.txt");

List<List<int>> histories = [];

foreach (string line in input)
{
    histories.Add(line.Split(' ').Select(i => int.Parse(i)).ToList());
}

foreach(var hist in histories)
{
    List<List<int>> predictions = [];
    predictions.Add(hist);

    while(!predictions.Last().All(i => i == 0))
    {
        List<int> newPred = [];

        for(int i = 0; i < predictions.Last().Count - 1; i++)
        {
            newPred.Add(predictions.Last()[i+1] - predictions.Last()[i]);
        }

        predictions.Add(newPred);
    }

    predictions.Reverse();

    for(int i = 0; i < predictions.Count; i ++)
    {
        if(i == 0)
            predictions[i].Insert(0, 0);
        else
            predictions[i].Insert(0, predictions[i].First() - predictions[i - 1].First());
    }
}

Console.WriteLine(histories.Sum(list => list.First()));