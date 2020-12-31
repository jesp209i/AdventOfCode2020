using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day6
{
    public class AoCDay6 : IAoCDay
    {
        public int AnswerCount { get; set; }
        string answers = "abcdefghijklmnopqrstuvwxyz";
        private readonly List<string> _customGroups;

        public AoCDay6(List<string> customGroups)
        {
            _customGroups = customGroups;
        }
        public void Solve()
        {
            Console.WriteLine($"Day 6-part1: {PartOne()}");
            Console.WriteLine($"Day 6-part2: {PartTwo()}");
        }

        public int PartOne()
        {
            foreach(string cg in _customGroups)
            {
                foreach(char c in answers)
                {
                    if (cg.Contains(c)) AnswerCount++;
                }
            }
            return AnswerCount;
        }

        public int PartTwo()
        {
            AnswerCount = 0;
            foreach (var cg in _customGroups)
            {
                string matchString = "";
                Regex rx = new Regex(@"(\b\w+\b)");
                var matches = rx.Matches(cg);
                int runs = 0;
                foreach (Match potentialMatch in matches)
                {
                    if (runs == 0)
                    {
                        matchString = potentialMatch.Value;
                        runs++;
                        continue;
                    }
                    string goodMatches = "";
                    foreach (char c in matchString)
                    {
                        if (potentialMatch.Value.Contains(c))
                        {
                            goodMatches += c;
                        }
                    }
                    matchString = goodMatches;
                    runs++;
                    if (string.IsNullOrWhiteSpace(matchString)) continue;
                }
                AnswerCount += matchString.Length;
            }
            return AnswerCount;
        }
    }
}
