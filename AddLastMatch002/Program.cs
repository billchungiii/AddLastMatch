using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace AddLastMatch002
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var (no, value) in Read ("TextFile1.txt"))
            {
                Console.WriteLine($"{no} -- {value}");
            }

            Console.ReadLine();
        }


     

        static IEnumerable<(string, string)> Read(string path)
        {
            var set = new HashSet<(string, string)>(new MyEqualityComparer());
            foreach (var line in ReadFile(path))
            {
                var content = line.Split(",");
                set.Add((content[0], content[1]));
            }
            return set.Reverse();
        }

        static IEnumerable<string> ReadFile(string path)
        {
            return File.ReadLines(path).Reverse();
        }
    }

    class MyEqualityComparer : IEqualityComparer<(string, string)>
    {
        public bool Equals((string, string) x, (string, string) y)
        {
            return x.Item2 == y.Item2;
        }

        public int GetHashCode([DisallowNull] (string, string) obj)
        {
            return obj.Item2.GetHashCode();
        }
    }
}
