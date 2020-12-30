using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public class InputReader
    {
        string _path;
        public void SetInput(string path)
        {
            _path = path;
        }
        public List<string> ToStringList()
        {
            var result = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@_path);
            foreach(string line in lines)
            {
                result.Add(line);
            }
            return result;
        }
        public List<string> ToGroupStringList()
        {
            var result = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@_path);
            string group = "";
            foreach (string line in lines)
            {
                
                if (string.IsNullOrWhiteSpace(line))
                {
                    result.Add(group);
                    group = "";
                }
                else
                {
                    if (group.Length == 0)
                    {
                        group = line;
                    }
                    else
                    {
                        group = group + " " + line;
                    }
                }
            }
            result.Add(group);
            return result;
        }
        public List<int> ToIntList()
        {
            var result = new List<int>();
            string[] lines = System.IO.File.ReadAllLines(@_path);
            foreach (string line in lines)
            {
                result.Add(int.Parse(line));
            }
            return result;
        }
    }
}
