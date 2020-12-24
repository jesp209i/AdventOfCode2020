using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day1
{
    public class AoCDay1 : IAoCDay
    {
        //private List<int> _list = new List<int>(){ 1721, 979, 366, 299, 675, 1456 };
        private List<int> _list = new List<int>();

        int magicNumber = 2020;
        int number1;
        int number2;
        int number3;
        public AoCDay1(List<int> numbers)
        {
            _list = numbers;
        }
        private void PartOne()
        {
            int candidate1;
            int candidate2;
            for (int i = 0; i < _list.Count; i++)
            {
                candidate1 = _list[i];
                for (int j = 1; j < _list.Count; j++)
                {
                    if (i != j)
                    {
                        candidate2 = _list[j];
                        var amIDone = candidate1 + candidate2 - magicNumber;
                        if (amIDone == 0)
                        {
                            number1 = candidate1;
                            number2 = candidate2;
                        }
                    }
                }
            }
        }
        private void PartTwo()
        {
            int candidate1;
            int candidate2;
            int candidate3;
           // int times = 1;
            for (int i = 0; i < _list.Count; i++)
            {
                candidate1 = _list[i];
                for (int j = 1; j < _list.Count; j++)
                {
                    if (i != j)
                    {
                        candidate2 = _list[j];
                        for (int k = 2; k < _list.Count; k++)
                        {
                            
                            if (k != j || k !=i)
                            {
                                candidate3 = _list[k];
                                var amIDone = candidate1 + candidate2 + candidate3 - magicNumber;
                                //Console.WriteLine($"run {times} : {candidate1} + {candidate2} + {candidate3} = {candidate1+candidate2+candidate3}");
                                //times++;
                                if (amIDone == 0)
                                {
                                    number1 = candidate1;
                                    number2 = candidate2;
                                    number3 = candidate3;
                                }
                            }
                        }

                    }
                }
            }
        }
        private int MultiplyTwo() => number1 * number2;
        private int MultiplyThree() => number1 * number2 * number3;

        public void Solve()
        {
            PartOne();
            Console.WriteLine($"Day 1-part1: {MultiplyTwo()}");
            PartTwo();
            Console.WriteLine($"Day 1-part2: {MultiplyThree()}");
        }
    }
}
