using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
    {
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var G = new bool[N][];
            for (var i = 0; i < N; i++)
            {
                var S = Scanner.Scan<string>();
                G[i] = S.Select(x => x == 'Y').ToArray();
            }

            const long inf = (long)1e18;
            var values = new long[N, N];
            var counts = new long[N, N];

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    values[i, j] = G[i][j] ? A[i] + A[j] : -inf;
                    counts[i, j] = G[i][j] ? 1 : inf;
                }

                values[i, i] = 0;
                counts[i, i] = 0;
            }

            for (var k = 0; k < N; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        var count = counts[i, k] + counts[k, j];
                        var value = values[i, k] + values[k, j] - A[k];
                        if (count == counts[i, j])
                        {
                            values[i, j] = Math.Max(values[i, j], value);
                        }
                        else if (count < counts[i, j])
                        {
                            counts[i, j] = count;
                            values[i, j] = value;
                        }
                    }
                }
            }

            var Q = Scanner.Scan<int>();
            while (Q-- > 0)
            {
                var (u, v) = Scanner.Scan<int, int>();
                u--; v--;
                var count = counts[u, v];
                var value = values[u, v];
                if (count == inf)
                {
                    Console.WriteLine("Impossible");
                }
                else
                {
                    Console.WriteLine($"{count} {value}");
                }
            }
        }

        public static class Scanner
        {
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]), Convert<T6>(buffer[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static string[] Scan()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
