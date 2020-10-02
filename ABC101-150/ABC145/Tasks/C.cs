using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var N = Scanner.Scan<int>();
            var P = new (int X, int Y)[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                P[i] = (x, y);
            }
            var answer = 0.0;
            var used = new bool[N];
            var frac = 1;
            for (var i = 1; i <= N; i++) frac *= i;

            void Dfs(int current, double sum)
            {
                if (used.All(x => x)) { answer += sum; return; }
                used[current] = true;

                for (var i = 0; i < N; i++)
                {
                    if (used[i]) continue;
                    var dx = P[current].X - P[i].X;
                    var dy = P[current].Y - P[i].Y;
                    used[i] = true;
                    var distance = Math.Sqrt(dx * dx + dy * dy);
                    Dfs(i, sum + distance);
                    used[i] = false;
                }
                used[current] = false;
            }

            for (var i = 0; i < N; i++) Dfs(i, 0);
            answer /= frac;

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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
