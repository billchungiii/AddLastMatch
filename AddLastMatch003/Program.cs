using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace AddLastMatch003
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var (no, value) in Read("TextFile1.txt"))
            {
                Console.WriteLine($"{no} -- {value}");
            }

            Console.ReadLine();
        }

        static IEnumerable<(string, string)> Read(string path)
        {

            return ReadFile(path).Distinct(new MyEqualityComparer()).Reverse();

        }

        static IEnumerable<(string, string)> ReadFile(string path)
        {
            return File.ReadLines(path).Select((x) => Split(x)).Reverse();


            static (string, string) Split(string line)
            {
                var content = line.Split(",");
                return (content[0], content[1]);
            }

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
