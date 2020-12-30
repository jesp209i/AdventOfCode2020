using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day4
{
    public class AoCDay4 : IAoCDay
    {
        private readonly List<Passport> _passports = new List<Passport>();

        public AoCDay4(List<string> potentialPassports)
        {
            foreach (var pp in potentialPassports)
            {
                _passports.Add(new Passport(pp));
            }
        }
        public void Solve()
        {
            Console.WriteLine($"Day 4-part1: {PartOne()}");
            Console.WriteLine($"Day 4-part2: {PartTwo()}");
        }

        private object PartTwo()
        {
            int validPassports = 0;
            foreach (var pp in _passports)
            {
                if (pp.BetterValidation())
                {
                    validPassports++;
                }
            }
            return validPassports;
        }

        public int PartOne()
        {
            int validPassports = 0;
            foreach(var pp in _passports)
            {
                if (pp.ValidIgnoreCid())
                {
                    validPassports++;
                }
            }
            return validPassports;
        }
    }
}
