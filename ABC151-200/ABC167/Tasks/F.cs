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
            var LR = new (int L, int R)[N];
            var answer = true;
            for (var i = 0; i < N; i++)
            {
                var S = Scanner.Scan<string>();
                var l = 0;
                var r = 0;
                for (var j = 0; j < S.Length; j++)
                {
                    if (S[j] == '(') l++;
                    else { if (l > 0) l--; else r++; }
                }
                LR[i] = (l, r);
            }

            var left = 0;
            var right = 0;
            foreach (var item in LR.Where(x => x.L - x.R > 0).OrderBy(x => x.R))
            {
                if (item.R <= left) left += item.L - item.R;
                else answer = false;
            }

            foreach (var item in LR.Where(x => x.R - x.L > 0).OrderBy(x => x.L))
            {
                if (item.L <= right) right += item.R - item.L;
                else answer = false;
            }

            var max = 0L;
            var tmp = LR.Where(x => x.L == x.R);
            if (tmp.Any()) max = tmp.Max(x => x.L);
            if (left != right) answer = false;
            if (left < max) answer = false;

            Console.WriteLine(answer ? "Yes" : "No");
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
