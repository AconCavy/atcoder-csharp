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
            if (IsPrime(N)) { Console.WriteLine("impossible"); return; }

            var l = Enumerable.Range(0, N).Select(x => x * 2 + 1).ToArray();
            if (N % 2 == 0)
            {
                Console.WriteLine(N / 2);
                for (var i = 0; i < N / 2; i++)
                {
                    Console.WriteLine($"2 {l[i]} {l[^(i + 1)]}");
                }
            }
            else
            {
                var p = (int)Math.Sqrt(N);
                if (p != N / p && p % 2 == 0)
                {
                    for (var i = p; i >= 3; i--)
                    {
                        if ((N - i * i) % i == 0)
                        {
                            p = i;
                            break;
                        }
                    }
                }
                var answer = new List<int>[p].Select(_ => new List<int>()).ToArray();
                for (var i = 0; i < p; i++)
                {
                    for (var j = 0; j < p; j++)
                    {
                        answer[j].Add(l[i * p + (j - i + p) % p]);
                    }
                }

                l = l.Skip(p * p).ToArray();
                for (var i = 0; i < l.Length; i++)
                {
                    answer[i % p].Add(l[i]);
                }

                Console.WriteLine(p);
                for (var i = 0; i < p; i++)
                {
                    Console.WriteLine($"{answer[i].Count} {string.Join(" ", answer[i])}");
                };
            }
        }

        public static bool IsPrime(long value)
        {
            if (value == 2) return true;
            if (value < 2 || value % 2 == 0) return false;
            for (var i = 3L; i * i <= value; i += 2)
                if (value % i == 0)
                    return false;
            return true;
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
