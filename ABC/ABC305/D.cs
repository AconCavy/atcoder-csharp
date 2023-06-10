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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var Q = Scanner.Scan<int>();
            var query = new (int L, int R)[Q];
            var timeline = new HashSet<int>(A.Concat(A));
            for (var i = 0; i < Q; i++)
            {
                var (l, r) = Scanner.Scan<int, int>();
                query[i] = (l, r);
                timeline.Add(l);
                timeline.Add(r);
            }

            var (map, remap) = Compress(timeline);
            var cum = new long[map.Count + 1];
            for (var i = 1; i < N; i += 2)
            {
                var ml = map[A[i]];
                var mr = map[A[i + 1]];
                for (var j = ml; j < mr; j++)
                {
                    var t = remap[j + 1] - remap[j];

                    cum[j + 1] += t;
                }
            }

            for (var i = 0; i + 1 < cum.Length; i++)
            {
                cum[i + 1] += cum[i];
            }

            foreach (var (l, r) in query)
            {
                var ml = map[l];
                var mr = map[r];
                var answer = cum[mr] - cum[ml];
                Console.WriteLine(answer);
            }
        }

        public static (Dictionary<T, int> Map, Dictionary<int, T> ReMap) Compress<T>(IEnumerable<T> source)
        {
            var distinct = source.Distinct().ToArray();
            Array.Sort(distinct);
            var map = new Dictionary<T, int>();
            var remap = new Dictionary<int, T>();
            foreach (var (x, i) in distinct.Select((x, i) => (x, i)))
            {
                map[x] = i;
                remap[i] = x;
            }
            return (map, remap);
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