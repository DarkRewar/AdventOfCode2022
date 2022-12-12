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
                switch (split[1])
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

                score += CalculateScore(split[1], split[0]);
            }

            Console.WriteLine($"Score is: {score}");
        }

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
    }
}