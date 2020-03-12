using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AddLastMatch
{
    class Program
    {
        async static Task Main(string[] args)
        {
            foreach (var item in await ReadAsync("TextFile1.txt"))
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            Console.ReadLine();
        }

        async static ValueTask<Dictionary<string, string>> ReadAsync(string path)
        {
            var result = new Dictionary<string, string>();
            using (StreamReader reader = File.OpenText(path))
            {
                while (await reader.ReadLineAsync() is string line)
                {
                    var content = line.Split(',');
                    result[content[1]] = content[0];
                }
            }

            return result;
        }
    }
}

