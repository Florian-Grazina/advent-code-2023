using _02_12;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<GameModel> games = new();
            IEnumerable<string> lines = File.ReadLines("../../../input.txt");

            GameModel bag = new() { BlueCubes = 14, GreenCubes = 13, RedCubes = 12 };

            // each full game
            foreach(string line in lines)
            {
                GameModel game = new();
                games.Add(game);

                Match match = Regex.Match(line, @"Game (\d+):");
                game.Id  = int.Parse(match.Groups[1].Value);

                string id = line.Substring(5, 1);
                string fullGameString = line.Substring(7);

                string[] setsOfGame = fullGameString.Split(';');

                // each set of a game
                foreach(string setOfGame in setsOfGame)
                {
                    string[] cubesDraw = setOfGame.Split(',');

                    //each set of cubes
                    foreach (string cube in cubesDraw)
                    {
                        string[] numberCube = cube.Split(' ');
                        switch (numberCube[2])
                        {
                            case "blue":
                                game.BlueCubes = game.BlueCubes < int.Parse(numberCube[1]) ? int.Parse(numberCube[1]) : game.BlueCubes;
                                break;
                            case "red":
                                game.RedCubes = game.RedCubes < int.Parse(numberCube[1]) ? int.Parse(numberCube[1]) : game.RedCubes;
                                break;
                            case "green":
                                game.GreenCubes = game.GreenCubes < int.Parse(numberCube[1]) ? int.Parse(numberCube[1]) : game.GreenCubes;
                                break;
                        }
                    }
                }
                if(bag.BlueCubes < game.BlueCubes|| bag.GreenCubes < game.GreenCubes || bag.RedCubes < game.RedCubes)
                    game.GameIsPossible = false;
            }
            int res = games.Sum(g => g.GreenCubes * g.BlueCubes * g.RedCubes);
            Console.WriteLine(res);
        }
    }
}
