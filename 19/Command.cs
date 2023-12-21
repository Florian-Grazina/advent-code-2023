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

        public List<Units> Test(Units units)
        {
            Units = units;
            List<Units> toReturn = [];

            if (Id == "qqz")
                Console.WriteLine();

            foreach (string w in Workflow)
            {
                string[] process = w.Split(':');

                if(process.Length > 1)
                {
                    toReturn.Add(process[0][0] switch
                    {
                        'x' => CalculateX(Units.RangeX, process),
                        'm' => CalculateM(Units.RangeM, process),
                        'a' => CalculateA(Units.RangeA, process),
                        's' => CalculateS(Units.RangeS, process),
                    });
                }
                else
                    toReturn.Add(ok(w));

            }

            if(toReturn.Where(u =>u.Number < 0).Count() > 0)
                Console.WriteLine();

            return toReturn;
        }

        private Units ok(string process)
        {
            Units toReturn = new(
                Units.Number,
                Units.RangeX,
                Units.RangeM,
                Units.RangeA,
                Units.RangeS,
                process);

            Units.Number = 0;
            return toReturn;
        }

        private Units CalculateX((int,int) range, string[] process)
        {
            double total = range.Item2 - range.Item1 + 1;
            Units result;

            if (process[0].Contains('<'))
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (comparaison - 1 - range.Item1) / total;
                long okok = (long)Math.Round(pourcentage * Units.Number);

                result = new(
                    okok,
                    (range.Item1,comparaison - 1),
                    Units.RangeM,
                    Units.RangeA,
                    Units.RangeS,
                    process[1]);

                Units.RangeX = (comparaison, range.Item2);
                Units.Number -= okok;
            }

            else
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (range.Item2 - comparaison) / total;
                long okok = (long)Math.Round(pourcentage * Units.Number);

                result = new(
                    okok,
                    (comparaison + 1, range.Item2),
                    Units.RangeM,
                    Units.RangeA,
                    Units.RangeS,
                    process[1]);

                Units.RangeX = (range.Item1, comparaison);
                Units.Number -= okok;
            }

            return result;
        }
        private Units CalculateM((int, int) range, string[] process)
        {
            double total = range.Item2 - range.Item1 + 1;
            Units result;

            if (process[0].Contains('<'))
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (comparaison - 1 - range.Item1) / total;
                long okok = (long)Math.Round(pourcentage * Units.Number);

                result = new(
                    okok,
                    Units.RangeX,
                    (range.Item1, comparaison - 1),
                    Units.RangeA,
                    Units.RangeS,
                    process[1]);

                Units.RangeM = (comparaison, range.Item2);
                Units.Number -= okok;
            }

            else
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (range.Item2 - comparaison) / total;
                long okok = (long)Math.Round(pourcentage * Units.Number);

                result = new(
                    okok,
                    Units.RangeX,
                    (comparaison + 1, range.Item2),
                    Units.RangeA,
                    Units.RangeS,
                    process[1]);

                Units.RangeM = (range.Item1, comparaison);
                Units.Number -= okok;
            }

            return result;
        }
        private Units CalculateA((int, int) range, string[] process)
        {
            double total = range.Item2 - range.Item1 + 1;
            Units result;

            if (process[0].Contains('<'))
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (comparaison - 1 - range.Item1) / total;
                long okok = (long)Math.Round(pourcentage * Units.Number);

                result = new(
                    okok,
                    Units.RangeX,
                    Units.RangeM,
                    (range.Item1, comparaison - 1),
                    Units.RangeS,
                    process[1]);

                Units.RangeA = (comparaison, range.Item2);
                Units.Number -= okok;
            }

            else
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (range.Item2 - comparaison) / total;
                long okok = (long)Math.Round(pourcentage * Units.Number);

                result = new(
                    okok,
                    Units.RangeX,
                    Units.RangeM,
                    (comparaison + 1, range.Item2),
                    Units.RangeS,
                    process[1]);

                Units.RangeA = (range.Item1, comparaison);
                Units.Number -= okok;
            }

            return result;
        }
        private Units CalculateS((int, int) range, string[] process)
        {
            double total = range.Item2 - range.Item1 + 1;
            Units result;

            if (process[0].Contains('<'))
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (comparaison - 1 - range.Item1) / total;
                long okok = (long)Math.Round(pourcentage * Units.Number);

                result = new(
                    okok,
                    Units.RangeX,
                    Units.RangeM,
                    Units.RangeA,
                    (range.Item1, comparaison - 1),
                    process[1]);

                Units.RangeS = (comparaison, range.Item2);
                Units.Number -= okok;
            }

            else
            {
                int comparaison = int.Parse(process[0][2..]);
                double pourcentage = (range.Item2 - comparaison) / total;
                long okok = (long)Math.Round(pourcentage * Units.Number);

                result = new(
                    okok,
                    Units.RangeX,
                    Units.RangeM,
                    Units.RangeA,
                    (comparaison + 1, range.Item2),
                    process[1]);

                Units.RangeS = (range.Item1, comparaison);
                Units.Number -= okok;
            }


            return result;
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
