using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Day1
{
    public class Day1
    {
        public const string FileToRead = "D:/Curtis/Documents/Projects/AdventOfCode/AdventOfCode2022/AdventOfCode2022/Day1/input.txt";
        
        public void Execute()
        {
            List<int> elves = new List<int>();
            int max = 0;
            int current = 0;
            foreach (var line in File.ReadLines(FileToRead))
            {
                max = Math.Max(max, current);
                
                if (string.IsNullOrEmpty(line))
                {
                    elves.Add(current);
                    current = 0;
                }
                else if (int.TryParse(line, out int lineInt))
                {
                    current += lineInt;
                }
            }

            elves.Sort((a, b) => a > b ? -1 : a == b ? 0 : 1);
            Console.WriteLine($"Max is: {max}");
            Console.WriteLine($"Total top 3 is: {elves.Take(3).Sum()}");
        }
    }
}