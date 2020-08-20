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
            var (N, K) = Scanner.Scan<int, int>();
            var p = (int)1e9 + 7;
            var answer = 0L;
            var factors = new List<long>();
            for (var i = 1; i * i <= K; i++)
            {
                if (K % i != 0) continue;
                factors.Add(i);
                if (i * i != K) factors.Add(K / i);
            }
            factors = factors.OrderByDescending(x => x).ToList();
            var sum = new long[factors.Count];
            for (var i = 0; i < sum.Length; i++)
            {
                var factor = factors[i];
                sum[i] = (factor + (N - (N % factor))) * (N / factor) / 2;
                sum[i] %= p;
                for (var j = 0; j < i; j++)
                {
                    if (factors[j] % factors[i] == 0) sum[i] -= sum[j];
                }
                sum[i] %= p;
                answer += sum[i] * K / factor;
            }

            answer = (answer % p + p) % p;

            Console.WriteLine(answer);
        }

        static long LCM(long a, long b) => a * b / GCD(a, b);
        static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);

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
        }
    }
}
