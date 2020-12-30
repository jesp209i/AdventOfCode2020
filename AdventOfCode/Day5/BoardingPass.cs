using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day5
{
    public class BoardingPass : IComparable<BoardingPass>
    {
        private readonly string _boardingPassString;
        public int Row { get; set; }
        public int Column { get; set; }
        public int SeatId { get; set; }

        public BoardingPass(string boardingPassString)
        {
            _boardingPassString = boardingPassString;
            Parse(_boardingPassString);
        }

        private void Parse(string boardingPassString)
        {
            string firstPart = Regex.Match(boardingPassString, @"[FB]+").Value;
            string secondPart = Regex.Match(boardingPassString, @"[RL]+").Value;
            Row = HighLow(127, firstPart);
            Column = HighLow(7, secondPart);
            SeatId = Row * 8 + Column;
        }
        public int CompareTo(BoardingPass comparePart)
        {
            if (comparePart == null)
                return 1;
            else
                return this.SeatId.CompareTo(comparePart.SeatId);
        }
        private int HighLow(int high, string placement)
        {
            int result = 0;
            int lowRow = 0;
            int highRow = high;
            int left = high + 1;
            foreach (char c in placement)
            {
                left = left / 2;
                if (c == 'F' || c == 'L')
                {
                    highRow -= left;
                }
                if (c == 'B' || c == 'R')
                {
                    lowRow += left;
                }
            }
            switch (placement[placement.Length-1])
            {
                case 'F':
                    result = lowRow;
                    break;
                case 'B':
                    result = highRow;
                    break;
                case 'L':
                    result = lowRow;
                    break;
                case 'R':
                    result = highRow;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
