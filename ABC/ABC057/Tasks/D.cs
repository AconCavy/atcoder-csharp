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
            var (N, A, B) = Scanner.Scan<int, int, int>();
            var V = Scanner.ScanEnumerable<long>().ToArray();
            Array.Sort(V, (x, y) => y.CompareTo(x));
            Console.WriteLine(V.Take(A).Average());

            var C = new long[N + 1][].Select(_ => new long[N + 1]).ToArray();
            for (var i = 0; i <= N; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i) C[i][j] = 1;
                    else C[i][j] = C[i - 1][j - 1] + C[i - 1][j];
                }
            }
            var count = 0;
            var position = 0;
            for (var i = 0; i < N; i++)
            {
                if (V[i] != V[A - 1]) continue;
                count++;
                if (i < A) position++;
            }
            var answer = 0L;
            if (position == A)
            {
                for (var i = A; i <= B; i++) answer += C[count][i];
            }
            else answer += C[count][position];

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
