using AdventOfCode.Day5;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfTests
{
    public class Day5Test
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR",70,7,567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void TestCase(string boardingString, int row, int column, int seatId)
        {
            var boardingpass = new BoardingPass(boardingString);

            boardingpass.Row.Should().Be(row);

            boardingpass.Column.Should().Be(column);

            boardingpass.SeatId.Should().Be(seatId);

        }
    }
}
