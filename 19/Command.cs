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
        public double Unit { get; set; }


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

        public Dictionary<string, double> Test()
        {
            Dictionary<string, double> toReturn = [];

            foreach (string w in Workflow)
            {
                string[] process = w.Split(':');
                double unitPassed = 0;

                if (process[0].Contains('<'))
                {
                    unitPassed = (int.Parse(process[0][2..]) - 1) / 4000d * Unit;
                    AddToDico(toReturn, process[1], unitPassed);
                }

                else if (process[0].Contains('>'))
                {
                    unitPassed = (4000 - int.Parse(process[0][2..])) / 4000d * Unit;
                    AddToDico(toReturn, process[1], unitPassed);
                }

                else
                {
                    unitPassed = Unit;
                    AddToDico(toReturn, process[0], unitPassed);
                }

                Unit -= unitPassed;
            }

            return toReturn;
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
