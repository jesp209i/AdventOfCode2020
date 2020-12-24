using AdventOfCode.Day2;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfTests
{
    public class Day2Test
    {
        [Theory]
        [InlineData("1-3 a: abcde", 1)]
        [InlineData("1-3 b: cdefg", 0)]
        [InlineData("2-9 c: ccccccccc", 1)]
        public void PartOne(string ruleAndPassword, int expected)
        {
            List<string> _list = new List<string>();
            _list.Add(ruleAndPassword);
            // arrange
            var day2 = new AoCDay2(_list);

            // act
            day2.PartOne();

            // assert
            Assert.Equal(expected, day2._validPasswords);

        }
        [Theory]
        [InlineData("1-3 a: abcde", 1)]
        [InlineData("1-3 b: cdefg", 0)]
        [InlineData("2-9 c: ccccccccc", 0)]
        public void PartTwo(string ruleAndPassword, int expected)
        {
            List<string> _list = new List<string>();
            _list.Add(ruleAndPassword);
            // arrange
            var day2 = new AoCDay2(_list);

            // act
            day2.PartTwo();

            // assert
            Assert.Equal(expected, day2._validPasswords);
        }
    }
}
