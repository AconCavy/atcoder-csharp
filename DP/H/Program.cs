using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace H
{
    public class Program
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
            var HW = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (H, W) = (HW[0], HW[1]);
            var grid = new bool[H][];
            for (var i = 0; i < H; i++)
            {
                var s = Console.ReadLine();
                grid[i] = s.Select(x => x == '#').ToArray();
            }
            const int p = (int)1e9 + 7;

            var dp = new long[H][].Select(x => x = new long[W]).ToArray();
            dp[0][0] = 1;
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (i > 0) dp[i][j] = (dp[i][j] + dp[i - 1][j]) % p;
                    if (j > 0) dp[i][j] = (dp[i][j] + dp[i][j - 1]) % p;
                    if (grid[i][j]) dp[i][j] = 0;
                }
            }

            // Console.WriteLine(string.Join("\n", dp.Select(x => string.Join(" ", x))));
            Console.WriteLine(dp[H - 1][W - 1]);

        }
    }
}
