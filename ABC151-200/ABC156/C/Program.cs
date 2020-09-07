using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var n = int.Parse(Console.ReadLine());
            var xi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var mean = (int)Math.Round(xi.Average());
            Console.WriteLine(xi.Select(x => CalcHealth(x, mean)).Sum());
        }

        static int CalcHealth(int x, int p) => (x - p) * (x - p);
    }
}