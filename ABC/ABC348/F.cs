using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class F
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
        var (N, M) = Scanner.Scan<int, int>();
        var A = new int[N][];
        for (var i = 0; i < N; i++)
        {
            A[i] = Scanner.ScanEnumerable<int>().ToArray();
        }

        // var D = new Dictionary<int, HashSet<int>>[M];
        // for (var j = 0; j < M; j++)
        // {
        //     D[j] = new Dictionary<int, HashSet<int>>();
        //     var dict = D[j];
        //     for (var i = 0; i < N; i++)
        //     {
        //         var a = A[i][j];
        //         if (!dict.ContainsKey(a)) dict[a] = new HashSet<int>();
        //         dict[a].Add(i);
        //     }
        // }

        // long answer = 0;
        // var count = new int[N];
        // for (var j = 0; j < M; j++)
        // {
        //     foreach (var (_, set) in D[j])
        //     {
        //         var c = set.Count;
        //         foreach (var i in set)
        //         {
        //             count[i] = c - 1;
        //         }
        //     }
        // }

        // Console.WriteLine(answer);
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
