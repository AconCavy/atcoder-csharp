using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
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
            var (H, W, N, M) = Scanner.Scan<int, int, int, int>();
            var G = new int[H, W];
            var L = new (int H, int W)[N];
            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--; b--;
                L[i] = (a, b);
                G[a, b] = 2;
            }

            for (var i = 0; i < M; i++)
            {
                var (c, d) = Scanner.Scan<int, int>();
                G[c - 1, d - 1] = -1;
            }

            var delta = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
            foreach (var (h, w) in L)
            {
                foreach (var (dh, dw) in delta)
                {
                    for (var (nh, nw) = (h + dh, w + dw);
                    0 <= nh && nh < H && 0 <= nw && nw < W;
                    nh += dh, nw += dw)
                    {
                        if (G[nh, nw] == 2 || G[nh, nw] == -1) break;
                        G[nh, nw] = 1;
                    }
                }
            }

            var answer = 0;
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (G[i, j] > 0) answer++;
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
