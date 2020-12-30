using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            //Console.WriteLine($"Day 6-part2: {PartTwo()}");
        }

        private int PartOne()
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
            // 
            throw new NotImplementedException();
        }
    }
}
