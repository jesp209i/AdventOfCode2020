using AdventOfCode;
using AdventOfCode.Day6;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfTests
{
    public class Day6Test
    {
        [Fact]
        public void TestInput()
        {
            var reader = new InputReader();
            reader.SetInput(@".\testcustomsinput.txt");
            var list = reader.ToGroupStringList();
            Assert.Equal("abc", list[0]);
            Assert.Equal("a b c", list[1]);
            Assert.Equal("ab ac", list[2]);
            Assert.Equal("a a a a", list[3]);
            Assert.Equal("b", list[4]);
        }
        [Theory]
        [InlineData("abc", 3)]
        [InlineData("a b c", 3)]
        [InlineData("ab ac", 3)]
        [InlineData("a a a a", 1)]
        [InlineData("b", 1)]
        public void YesAnswers(string answers, int expected)
        {
            var list = new List<string>();
            list.Add(answers);
            var day6 = new AoCDay6(list);
            day6.Solve();
            day6.AnswerCount.Should().Be(expected);

        }
    }
}
