using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AvgInterpreter
{
    class Program
    {
        private static double[] array = new double[0];
        static void Main(string[] args)
        {
            var cmds = File.ReadAllLines("program.avg");
            for (int i = 0; i < cmds.Length; i++)
            {
                switch (cmds[i][0])
                {
                    case 'a':
                        Avg();
                        break;
                    case 's':
                        Set(cmds[i]);
                        break;
                    default:
                        Console.WriteLine($"Unknown command at line {i + 1}");
                        break;
                }
            }
        }

        private static void Set(string cmd)
        {
            var matches = Regex.Matches(cmd, @"[\d.]*\d");
            array = new double[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                if (double.TryParse(matches[i].Value, out double val))
                {
                    array[i] = val;
                }
            }
        }

        private static void Avg()
        {
            double temp = 0;
            foreach (var item in array)
            {
                temp += item;
            }
            Console.Write(temp / array.Length);
            Console.ReadKey(true);
        }
    }
}
