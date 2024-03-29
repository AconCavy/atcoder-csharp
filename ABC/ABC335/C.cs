using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class C
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
        var (N, Q) = Scanner.Scan<int, int>();
        var P = new (int X, int Y)[Q + 1];
        P[0] = (1, 0);
        var q = 0;

        for (var i = 1; i <= Q; i++)
        {
            var query = Scanner.ScanEnumerable<string>().ToArray();
            if (query[0] == "1")
            {
                var (cx, cy) = P[q];
                q++;
                var (dx, dy) = (0, 0);
                switch (query[1])
                {
                    case "R": dx++; break;
                    case "L": dx--; break;
                    case "U": dy++; break;
                    case "D": dy--; break;
                    default: break;
                }

                P[q] = (cx + dx, cy + dy);
            }
            else
            {
                var p = int.Parse(query[1]);
                var d = q - p + 1;
                if (d >= 0)
                {
                    var (x, y) = P[d];
                    Console.WriteLine($"{x} {y}");
                }
                else
                {
                    var (x, y) = (1 - d, 0);
                    Console.WriteLine($"{x} {y}");
                }
            }
        }
    }

    public class FenwickTree<T>
        where T : struct, IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    {
        public int Length { get; }
        private readonly T[] _data;
        public FenwickTree(int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
            Length = length;
            _data = new T[length];
        }
        public void Add(int index, T value)
        {
            if (index < 0 || Length <= index) throw new ArgumentOutOfRangeException(nameof(index));
            index++;
            while (index <= Length)
            {
                _data[index - 1] += value;
                index += index & -index;
            }
        }
        public T Sum(int length)
        {
            if (length < 0 || Length < length) throw new ArgumentOutOfRangeException(nameof(length));
            T s = default;
            while (length > 0)
            {
                s += _data[length - 1];
                length -= length & -length;
            }
            return s;
        }
        public T Sum(int left, int right)
        {
            if (left < 0 || right < left || Length < right) throw new ArgumentOutOfRangeException();
            return Sum(right) - Sum(left);
        }
        public int LowerBound(T value) => Bound(value, (x, y) => x <= y);
        public int UpperBound(T value) => Bound(value, (x, y) => x < y);
        private int Bound(T value, Func<T, T, bool> compare)
        {
            if (Length == 0 || compare(value, _data[0])) return 0;
            var x = 0;
            var r = 1;
            while (r < Length) r <<= 1;
            for (var k = r; k > 0; k >>= 1)
            {
                if (x + k - 1 >= Length || compare(value, _data[x + k - 1])) continue;
                value -= _data[x + k - 1];
                x += k;
            }
            return x;
        }
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
