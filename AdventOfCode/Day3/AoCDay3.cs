using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day3
{
    public class AoCDay3 : IAoCDay
    {
        private readonly List<string> _input;
        public AoCDay3(List<string> input)
        {
            _input = input;
        }

        public long PartOne()
        {
            return TreeCounter(1, 3);
        }
        public long PartTwo()
        {
            long oneone = TreeCounter(1, 1);
            long threeone = TreeCounter(1, 3); 
            long fiveone = TreeCounter(1, 5);
            long sevenone = TreeCounter(1, 7);
            long onetwo = TreeCounter(2, 1);
            return oneone * threeone * fiveone * sevenone * onetwo;
        }
        public void Solve()
        {
            
            Console.WriteLine($"Day 3-part1: {PartOne()}");
            Console.WriteLine($"Day 3-part2: {PartTwo()}");
        }

        private long TreeCounter(int x, int y)
        {
            long trees = 0;
            int xPosition = 0;
            int yPosition = 0;
            int length = _input.Count;
            int stringLength = _input[0].Length;
            while (xPosition + x < length)
            {
                xPosition = xPosition + x;
                yPosition = yPosition + y;
                if (yPosition >= stringLength)
                {
                    yPosition = yPosition - stringLength;
                }
                if (_input[xPosition][yPosition].Equals('#'))
                {
                    trees++;
                }
            }
            return trees;
        }
    }
}
