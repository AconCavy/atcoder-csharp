using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var G = new int[9, 9];
            for (var i = 0; i < 9; i++)
            {
                var S = Scanner.Scan<string>();
                for (var j = 0; j < 9; j++)
                {
                    G[i, j] = S[j] - '0';
                }
            }

            var answer = true;
            for (var i = 0; i < 9 && answer; i++)
            {
                var used = new bool[10];
                for (var j = 0; j < 9 && answer; j++)
                {
                    if (used[G[i, j]]) answer = false;
                    used[G[i, j]] = true;
                }
            }

            for (var j = 0; j < 9 && answer; j++)
            {
                var used = new bool[10];
                for (var i = 0; i < 9 && answer; i++)
                {
                    if (used[G[i, j]]) answer = false;
                    used[G[i, j]] = true;
                }
            }

            var D8 = new[] { (1, 2), (2, 1), (2, -1), (1, -2), (-1, -2), (-2, -1), (-2, 1), (-1, 2) };
            for (var i = 0; i < 9 && answer; i++)
            {
                for (var j = 0; j < 9 && answer; j++)
                {
                    foreach (var (dh, dw) in D8)
                    {
                        var (nh, nw) = (i + dh, j + dw);
                        if (nh < 0 || 9 <= nh || nw < 0 || 9 <= nw) continue;
                        answer &= G[i, j] != G[nh, nw];
                    }
                }
            }

            Console.WriteLine(answer ? "Yes" : "No");
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
