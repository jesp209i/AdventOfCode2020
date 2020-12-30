using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfTests
{
    public class InputReaderTest
    {
        [Fact]
        public void PassportList()
        {
            var reader = new InputReader();
            reader.SetInput(@".\testpassportinput.txt");
            var result = reader.ToGroupStringList();
            Assert.Equal(6, result.Count);
        }
        [Fact]
        public void CustomsList()
        {
            var reader = new InputReader();
            reader.SetInput(@".\testcustomsinput.txt");
            var result = reader.ToGroupStringList();
            Assert.Equal(5, result.Count);
        }

    }
}
