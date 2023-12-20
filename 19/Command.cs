using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _19
{
    internal class Command
    {
        public string Id { get; set; }
        public string[] Workflow { get; set; }
        public Units Units { get; set; }


        public Command(string input)
        {
            Parse(input);
        }


        private void Parse(string input)
        {
            string[] splittedInput = input.Split('{');

            Id = splittedInput[0];
            Workflow = splittedInput[1].Replace('}',' ').Trim().Split(',');
        }

        public List<Units> Test()
        {
            List<Units> toReturn = [];

            foreach (string w in Workflow)
            {
                string[] process = w.Split(':');

                toReturn.AddRange(process[0] switch
                {
                    "x" => CalculateX(Units.RangeX, process),
                    "m" => CalculateM(Units.RangeM, process),
                    "a" => CalculateA(Units.RangeA, process),
                    "s" => CalculateS(Units.RangeS, process),
                });
            }

            return toReturn;
        }

        private List<Units> CalculateX((int,int) range, string[] process)
        {
            int total = range.Item2 - range.Item1 + 1;
            List<Units> result = [];

            if (process[0].Contains('<'))
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (comparaison - 1) / total;

                result.Add(new(
                    pourcentage * Units.Number,
                    (range.Item1,comparaison - 1),
                    Units.RangeM,
                    Units.RangeA,
                    Units.RangeS,
                    process[1]));

                Units.Number -= pourcentage * Units.Number;
            }

            else if (process[0].Contains('>'))
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (range.Item2 - comparaison) / total;

                result.Add(new(
                    pourcentage * Units.Number,
                    (comparaison + 1, range.Item2),
                    Units.RangeM,
                    Units.RangeA,
                    Units.RangeS,
                    process[1]));

                Units.Number -= pourcentage * Units.Number;
            }

            else
            {
                result.Add(new(
                    pourcentage * Units.Number,
                    (comparaison + 1, range.Item2),
                    Units.RangeM,
                    Units.RangeA,
                    Units.RangeS,
                    process[1]));
            }

        }

        private void AddToDico(Dictionary<string, double> dico, string key, double value)
        {
            if (dico.ContainsKey(key))
                dico[key] += value;
            else
                dico.Add(key, value);
        }

        public string WorkFlow(Part part)
        {
            foreach (string w in Workflow)
            {
                try
                {
                    string[] process = w.Split(':');

                    bool isProcessed = process[0].First() switch
                    {
                        'x' => Compare(part.X, process[0]),
                        'm' => Compare(part.M, process[0]),
                        'a' => Compare(part.A, process[0]),
                        's' => Compare(part.S, process[0])
                    };

                    if (isProcessed)
                        return process[1];
                }
                catch
                {
                    return w;
                }
            }

            throw new Exception("Workflow issue");
        }

        private bool Compare(int part, string process)
        {
            if (process.Contains('>'))
                return part > int.Parse(process[2..]);

            if(process.Contains('<'))
                return part < int.Parse(process[2..]);

            throw new Exception("Compare issue");
        }
    }
}
