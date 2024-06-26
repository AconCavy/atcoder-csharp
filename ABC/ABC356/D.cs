using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

using mint = D.ModuloInteger;

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
        var (N, M) = Scanner.Scan<long, long>();
        var dp = new mint[61];
        dp[0] = 1;
        dp[M & 1]++;
        for (var i = 1; 1L << i <= M; i++)
        {
            var s = (M >> i) & 1;
            for (var j = i; j >= 0; j--)
            {
                dp[j + s] += dp[j];
            }
        }

        mint answer = 0;
        for (var i = 0; i <= 60; i++)
        {
            answer += dp[i] * i;
        }

        Console.WriteLine(answer);
    }

    public static class Printer
    {
        public static void Print<T>(T source) => Console.WriteLine(source);
        public static void Print1D<T>(IEnumerable<T> source, string separator = "") => Console.WriteLine(string.Join(separator, source));
        public static void Print1D<T, U>(IEnumerable<T> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(separator, source.Select(selector)));
        public static void Print2D<T>(IEnumerable<IEnumerable<T>> source, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x))));
        public static void Print2D<T, U>(IEnumerable<IEnumerable<T>> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x.Select(selector)))));
        public static void Print2D<T>(T[,] source, string separator = "")
        {
            var (h, w) = (source.GetLength(0), source.GetLength(1));
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    Console.Write(source[i, j]);
                    Console.Write(j == w - 1 ? Environment.NewLine : separator);
                }
            }
        }
        public static void Print2D<T, U>(T[,] source, Func<T, U> selector, string separator = "")
        {
            var (h, w) = (source.GetLength(0), source.GetLength(1));
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    Console.Write(selector(source[i, j]));
                    Console.Write(j == w - 1 ? Environment.NewLine : separator);
                }
            }
        }
    }

    public readonly struct ModuloInteger : IEquatable<ModuloInteger>,
        IAdditionOperators<ModuloInteger, ModuloInteger, ModuloInteger>,
        IDivisionOperators<ModuloInteger, ModuloInteger, ModuloInteger>,
        IMultiplyOperators<ModuloInteger, ModuloInteger, ModuloInteger>,
        ISubtractionOperators<ModuloInteger, ModuloInteger, ModuloInteger>,
        IEqualityOperators<ModuloInteger, ModuloInteger, bool>
    {
        public long Value { get; }
        // The modulo will be used as an editable property.
        // public static long Modulo { get; set; } = 998244353;
        // The constant modulo will be recommended to use for performances in use cases.
        public const long Modulo = 998244353;
        public ModuloInteger(int value)
        {
            Value = value % Modulo;
            if (Value < 0) Value += Modulo;
        }
        public ModuloInteger(long value)
        {
            Value = value % Modulo;
            if (Value < 0) Value += Modulo;
        }
        public static implicit operator int(ModuloInteger mint) => (int)mint.Value;
        public static implicit operator long(ModuloInteger mint) => mint.Value;
        public static implicit operator ModuloInteger(int value) => new(value);
        public static implicit operator ModuloInteger(long value) => new(value);
        public static ModuloInteger operator +(ModuloInteger left, ModuloInteger right) => left.Value + right.Value;
        public static ModuloInteger operator -(ModuloInteger left, ModuloInteger right) => left.Value - right.Value;
        public static ModuloInteger operator *(ModuloInteger left, ModuloInteger right) => left.Value * right.Value;
        public static ModuloInteger operator /(ModuloInteger left, ModuloInteger right) => left * right.Inverse();
        public static bool operator ==(ModuloInteger left, ModuloInteger right) => left.Equals(right);
        public static bool operator !=(ModuloInteger left, ModuloInteger right) => !left.Equals(right);
        public bool Equals(ModuloInteger other) => Value == other.Value;
        public override bool Equals(object obj) => obj is ModuloInteger other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public ModuloInteger Inverse() => Inverse(Value);
        public static ModuloInteger Inverse(long value)
        {
            if (value == 0) return 0;
            var (s, t, m0, m1) = (Modulo, value, 0L, 1L);
            while (t > 0)
            {
                var u = s / t;
                s -= t * u;
                m0 -= m1 * u;
                (s, t) = (t, s);
                (m0, m1) = (m1, m0);
            }
            if (m0 < 0) m0 += Modulo / s;
            return m0;
        }
        public ModuloInteger Power(long n) => Power(Value, n);
        public static ModuloInteger Power(long value, long n)
        {
            if (n < 0) throw new ArgumentException(nameof(n));
            var result = 1L;
            while (n > 0)
            {
                if ((n & 1) > 0) result = result * value % Modulo;
                value = value * value % Modulo;
                n >>= 1;
            }
            return result;
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
