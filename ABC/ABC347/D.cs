using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

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
        var (A, B, C) = Scanner.Scan<int, int, long>();
        var N = 60;
        var dp = new long[N + 1, A + 2, B + 2];
        for (var i = 0; i <= N; i++)
        {
            for (var a = 0; a <= A; a++)
            {
                for (var b = 0; b <= B; b++)
                {
                    dp[i, a, b] = -1;
                }
            }
        }

        if ((C & 1) == 0)
        {
            dp[0, 0, 0] = 0;
            dp[0, 1, 1] = 1;
        }
        else
        {
            dp[0, 1, 0] = 1;
            dp[0, 0, 1] = 0;
        }

        for (var i = 1; i <= N; i++)
        {
            for (var a = 0; a <= A; a++)
            {
                for (var b = 0; b <= B; b++)
                {
                    if (dp[i - 1, a, b] == -1) continue;
                    var bit = (C >> i) & 1;
                    if (bit == 0)
                    {
                        dp[i, a, b] = dp[i - 1, a, b];
                        dp[i, a + 1, b + 1] = dp[i - 1, a, b] | (1L << i);
                    }
                    else
                    {
                        dp[i, a + 1, b] = dp[i - 1, a, b] | (1L << i);
                        dp[i, a, b + 1] = dp[i - 1, a, b];
                    }
                }
            }
        }

        if (dp[N, A, B] >= 0)
        {
            var x = dp[N, A, B];
            var y = C ^ x;
            Console.WriteLine($"{x} {y}");
            return;
        }

        Console.WriteLine(-1);
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
