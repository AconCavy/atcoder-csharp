using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class F
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
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var G = new int[N][].Select(_ => new List<int>()).ToArray();
            for (var i = 0; i < N - 1; i++)
            {
                var (v1, v2) = Scanner.Scan<int, int>();
                v1--; v2--;
                G[v1].Add(v2);
                G[v2].Add(v1);
            }

            var answer = new int[N];
            var stack = new int[N].Select(_ => int.MaxValue).ToArray();
            var length = 0;

            void Dfs(int current, int parent)
            {
                var l = -1;
                var r = length;
                while (r - l > 1)
                {
                    var m = l + (r - l) / 2;
                    if (stack[m] < A[current]) l = m;
                    else r = m;
                }

                var prevLength = length;
                var prev = stack[r];
                if (r >= length) length++;
                stack[r] = Math.Min(stack[r], A[current]);
                answer[current] = length;
                foreach (var child in G[current])
                {
                    if (child == parent) continue;
                    Dfs(child, current);
                }
                length = prevLength;
                stack[r] = prev;
            }

            Dfs(0, -1);

            Console.WriteLine(string.Join("\n", answer));

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
