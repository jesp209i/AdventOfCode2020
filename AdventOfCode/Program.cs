using System;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code!");
            var reader = new InputReader();
            reader.SetInput(@".\Day1\input.txt");
            var day1 = new AoCDay1(reader.ToIntList());
            day1.Solve();
            reader.SetInput(@".\Day2\input.txt");
            var day2 = new AoCDay2(reader.ToStringList());
            day2.Solve();
            reader.SetInput(@".\Day3\input3.txt");
            var day3 = new AoCDay3(reader.ToStringList());
            day3.Solve();







            Console.ReadLine();
        }
    }
}
