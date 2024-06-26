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
        var N = Scanner.Scan<long>();
        var K = 60;
        var dp = new mint[K + 1];
        dp[0] = N;
        var p10 = new mint[K + 1];
        p10[0] = mint.Power(10, N.ToString().Length);
        for (var i = 1; i <= K; i++)
        {
            dp[i] = dp[i - 1] * p10[i - 1] + dp[i - 1];
            p10[i] = p10[i - 1] * p10[i - 1];
        }

        mint answer = 0;
        for (var i = 0; i <= K; i++)
        {
            if ((N >> i & 1) == 1)
            {
                answer = answer * p10[i] + dp[i];
            }
        }

        Console.WriteLine(answer);
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
