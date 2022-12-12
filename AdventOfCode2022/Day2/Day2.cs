using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Day2
{
    public class Day2
    {
        public const string FileToRead =
            "D:/Curtis/Documents/Projects/AdventOfCode/AdventOfCode2022/AdventOfCode2022/Day2/input.txt";

        public void Execute()
        {
            int score = 0;
            foreach (var line in File.ReadLines(FileToRead))
            {
                var split = line.Split(' ');
                var move = DetermineMove(split[0], split[1]);
                switch (move)
                {
                    case "Y": // paper
                        score += 2;
                        break;
                    case "X": // rock
                        score += 1;
                        break;
                    case "Z": // scissors
                        score += 3;
                        break;
                }

                score += CalculateScore(move, split[0]);
            }

            Console.WriteLine($"Score is: {score}");
        }

        /// <summary>
        /// A/X for Rock,
        /// B/Y for Paper, and
        /// C/Z for Scissors
        /// </summary>
        /// <param name="me"></param>
        /// <param name="opponent"></param>
        /// <returns></returns>
        public int CalculateScore(string me, string opponent) => (me, opponent) switch
        {
            (me: "X", opponent: "C") => 6,
            (me: "Y", opponent: "A") => 6,
            (me: "Z", opponent: "B") => 6,
            (me: "X", opponent: "A") => 3,
            (me: "Y", opponent: "B") => 3,
            (me: "Z", opponent: "C") => 3,
            _ => 0,
        };

        /// <summary>
        /// The Elf finishes helping with the tent and sneaks back over to you.
        /// "Anyway, the second column says how the round needs to end:
        /// - X means you need to lose,
        /// - Y means you need to end the round in a draw, and
        /// - Z means you need to win. Good luck!"
        /// </summary>
        /// <param name="opponent"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public string DetermineMove(string opponent, string result) => (opponent, result) switch
        {
            (opponent: "B", result: "X") => "X",
            (opponent: "A", result: "Y") => "X",
            (opponent: "C", result: "Z") => "X",
            (opponent: "C", result: "X") => "Y",
            (opponent: "B", result: "Y") => "Y",
            (opponent: "A", result: "Z") => "Y",
            _ => "Z",
        };
    }
}