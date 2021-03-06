using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var (A, B) = Scanner.Scan<long, long>();
            long BitDp(string n)
            {
                var dp = new long[n.Length + 1, 2, 2];
                dp[0, 0, 0] = 1;
                for (var i = 0; i < n.Length; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        for (var k = 0; k < 2; k++)
                        {
                            var bit = j == 1 ? 9 : n[i] - '0';
                            for (var l = 0; l <= bit; l++)
                            {
                                var ni = i + 1;
                                var nj = j == 1 || l < bit ? 1 : 0;
                                var nk = (k == 1 || l == 4 || l == 9 ? 1 : 0);
                                dp[ni, nj, nk] += dp[i, j, k];
                            }
                        }
                    }
                }
                var ret = 0L;
                for (var i = 0; i < 2; i++)
                {
                    ret += dp[n.Length, i, 1];
                }
                return ret;
            }

            Console.WriteLine(BitDp(B.ToString()) - BitDp((A - 1).ToString()));
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
