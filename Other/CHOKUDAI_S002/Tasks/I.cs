using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace Tasks
{
    public class I
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
            var N = Scanner.Scan<int>();
            var F = new (long, long)[N];
            for (var i = 0; i < N; i++)
            {
                var (A, B) = Scanner.Scan<long, long>();
                F[i] = (A, B);
            }

            if (N == 1) { Console.WriteLine(1); return; }

            int Battle(int u, int v)
            {
                var (hu, du) = F[u];
                var (hv, dv) = F[v];
                var cu = (hv + du - 1) / du;
                var cv = (hu + dv - 1) / dv;
                if (cu < cv) return u;
                if (cu > cv) return v;
                return -1;
            }

            var p = 0;
            for (var i = 1; i < N; i++)
            {
                var win = Battle(p, i);
                if (win != -1) p = win;
            }

            var answer = p + 1;
            for (var i = 0; i < N; i++)
            {
                if (i == p) continue;
                var win = Battle(p, i);
                if (win != p)
                {
                    answer = -1;
                    break;
                }
            }

            Console.WriteLine(answer);
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
