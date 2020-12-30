using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day5
{
    public class AoCDay5 : IAoCDay
    {
        private List<BoardingPass> _boardingPasses = new List<BoardingPass>();
        public AoCDay5(List<string> boardingStrings)
        {
            foreach(var bp in boardingStrings)
            {
                _boardingPasses.Add(new BoardingPass(bp));
            }
        }
        public void Solve()
        {
            Console.WriteLine($"Day 5-part1: {PartOne()}");
            Console.WriteLine($"Day 5-part2: {PartTwo()}");
        }

        private int PartTwo()
        {
            _boardingPasses.Sort();
            BoardingPass oneLower;
            int bestbet = 0;
            for (int i = 1; i < _boardingPasses.Count; i++)
            {
                oneLower = _boardingPasses[i-1];
                if (_boardingPasses[i].SeatId != (oneLower.SeatId+1))
                {
                    bestbet = _boardingPasses[i].SeatId - 1;
                }
            }
            return bestbet;
        }

        public int PartOne()
        {
            int highest = 0;
            _boardingPasses.ForEach(x=> {
                if (x.SeatId > highest) highest = x.SeatId;
            });
            return highest;
        }
    }
}
