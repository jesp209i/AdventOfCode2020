using System;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Day4;
using AdventOfCode.Day5;
using AdventOfCode.Day6;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code!");
            var reader = new InputReader();

            reader.SetInput(@".\Day6\input6.txt");
            var day6 = new AoCDay6(reader.ToGroupStringList());
            day6.Solve();
            /*
            reader.SetInput(@".\Day5\input5.txt");
            var day5 = new AoCDay5(reader.ToStringList());
            day5.Solve();
            reader.SetInput(@".\Day4\input4.txt");
            var day4 = new AoCDay4(reader.ToPassportStringList());
            day4.Solve();
            reader.SetInput(@".\Day1\input.txt");
            var day1 = new AoCDay1(reader.ToIntList());
            day1.Solve();
            reader.SetInput(@".\Day2\input.txt");
            var day2 = new AoCDay2(reader.ToStringList());
            day2.Solve();
            reader.SetInput(@".\Day3\input3.txt");
            var day3 = new AoCDay3(reader.ToStringList());
            day3.Solve();*/
            Console.ReadLine();
        }
    }
}
