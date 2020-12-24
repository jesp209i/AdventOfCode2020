using AdventOfCode.Day3;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfTests
{
    public class Day3Test
    {
        private List<string> _list = new List<string>();
        public Day3Test()
        {
            _list.Add("..##.......");
            _list.Add("#...#...#..");
            _list.Add(".#....#..#.");
            _list.Add("..#.#...#.#");
            _list.Add(".#...##..#.");
            _list.Add("..#.##.....");
            _list.Add(".#.#.#....#");
            _list.Add(".#........#");
            _list.Add("#.##...#...");
            _list.Add("#...##....#");
            _list.Add(".#..#...#.#");
        }
        [Fact]
        public void GoodTestData()
        {
            Assert.Equal("..##.......", _list[0]);
            Assert.Equal("..#.##.....", _list[5]);
            Assert.Equal(".#..#...#.#", _list[10]);
        }
        [Fact]
        public void PartTwoTest()
        {
            var day3 = new AoCDay3(_list);

            var result = day3.PartTwo();

            Assert.Equal(336, result);
        }
    }
}
