using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var (H, W) = Scanner.Scan<int, int>();
            var G = new int[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = Scanner.Scan<string>().Select(x => F(x)).ToArray();
            }

            int F(char c)
            {
                return c switch
                {
                    's' => 0,
                    'n' => 1,
                    'u' => 2,
                    'k' => 3,
                    'e' => 4,
                    _ => -1,
                };
            }

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };


            var go = new bool[H, W];
            var queue = new Queue<(int H, int W, int S)>();
            if (G[0][0] == 0)
            {
                go[0, 0] = true;
                queue.Enqueue((0, 0, 0));
            }
            while (queue.Count > 0)
            {
                var (ch, cw, cs) = queue.Dequeue();
                foreach (var (dh, dw) in D4)
                {
                    var (nh, nw) = (ch + dh, cw + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    var ns = G[nh][nw];
                    if (ns == (cs + 1) % 5 && !go[nh, nw])
                    {
                        go[nh, nw] = true;
                        queue.Enqueue((nh, nw, ns));
                    }
                }
            }

            var answer = go[H - 1, W - 1];
            Console.WriteLine(answer ? "Yes" : "No");
        }

        public static class Scanner
        {
            public static T Scan<T>() where T : IConvertible => Convert<T>(ScanStringArray()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]), Convert<T6>(input[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanStringArray().Select(Convert<T>);
            private static string[] ScanStringArray()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
