using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day2
{
    public class AoCDay2 : IAoCDay
    {
        private List<PasswordRule> _list = new List<PasswordRule>();
        public int _validPasswords = 0;
        public AoCDay2(List<string> list)
        {
            list.ForEach(x => _list.Add(new PasswordRule(x)));
        }
        public void Solve()
        {
            PartOne();
            Console.WriteLine($"Day 2-part1: {_validPasswords}");
            _validPasswords = 0;
            PartTwo();
            Console.WriteLine($"Day 2-part2: {_validPasswords}");

        }
        public void PartOne()
        {
            _list.ForEach(x => {
                if (x.IsAmountOfRuleLetterInPasswordCorrect())
                    _validPasswords++;
            });
        }
        public void PartTwo()
        {
            _list.ForEach(x=> {
                if (x.IsRuleLetterInOnlyOneCorrectPosition())
                    _validPasswords++;
            });

        }
        private class PasswordRule
        {
            public int FirstPosition { get; set; }
            public int SecondPosition { get; set; }
            public char RuleLetter { get; set; }
            public string Password { get; set; }

            public PasswordRule(string ruleAndPassword)
            {
                var split = ruleAndPassword.IndexOf(":");
                RuleLetter = ruleAndPassword[split - 1];
                Password = ruleAndPassword.Substring(split + 1, ruleAndPassword.Length - split - 1).Trim();
                string firstPart = ruleAndPassword.Substring(0, split - 2);
                var dash = firstPart.IndexOf("-");
                FirstPosition = int.Parse(firstPart.Substring(0, dash)) - 1;
                SecondPosition = int.Parse(firstPart.Substring(dash + 1, firstPart.Length - dash - 1)) - 1;
            }
            public bool IsAmountOfRuleLetterInPasswordCorrect()
            {
                int count = 0;
                foreach( char c in Password)
                {
                    if (c.Equals(RuleLetter)) { count++; }
                }
                return count >= FirstPosition+1 && count <= SecondPosition+1;
            }
            public bool IsRuleLetterInOnlyOneCorrectPosition()
            {
                bool firstCorrect = Password[FirstPosition].Equals(RuleLetter);
                bool secondCorrect = Password[SecondPosition].Equals(RuleLetter);
                return firstCorrect.Equals(!secondCorrect);
            }
        }
    }
}
