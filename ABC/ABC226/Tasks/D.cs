using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            var P = new List<(int X, int Y)>();
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                P.Add((x, y));
            }

            var hashset = new HashSet<Fraction>();
            for (var i = 0; i < N; i++)
            {
                for (var j = i + 1; j < N; j++)
                {
                    var (dx, dy) = (P[i].X - P[j].X, P[i].Y - P[j].Y);
                    hashset.Add(new Fraction(dx, dy));
                    hashset.Add(new Fraction(-dx, -dy));
                }
            }

            var answer = hashset.Count * 2;
            Console.WriteLine(answer);
        }

        public static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);

        public readonly struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
        {
            public readonly long Y;
            public readonly long X;

            public Fraction(long y, long x)
            {
                var g = Gcd(y, x);
                Y = y / g;
                X = x / g;
            }

            public int CompareTo([AllowNull] Fraction other)
            {
                return (Y * other.X).CompareTo(X * other.Y);
            }

            public bool Equals([AllowNull] Fraction other)
            {
                return X == other.X && Y == other.Y;
            }

        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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