using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"abcdef
",
            @"badcfe
",
            TestName = "{m}-1")]
        [TestCase(
            @"aaaa
",
            @"aaaa
",
            TestName = "{m}-2")]
        [TestCase(
            @"atcoderbeginnercontest
",
            @"taocedbrgeniencrnoetts
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
3 1 4 5 4
",
            @"2
2 4
",
            TestName = "{m}-1")]
        [TestCase(
            @"20
9 7 19 7 10 4 13 9 4 8 10 15 16 3 18 19 12 13 2 12
",
            @"10
1 2 5 6 8 11 14 17 18 20
",
            TestName = "{m}-2")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
3 2 2
2 1 3
1 5 4
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"10 10
1 2 3 4 5 6 7 8 9 10
11 12 13 14 15 16 17 18 19 20
21 22 23 24 25 26 27 28 29 30
31 32 33 34 35 36 37 38 39 40
41 42 43 44 45 46 47 48 49 50
51 52 53 54 55 56 57 58 59 60
61 62 63 64 65 66 67 68 69 70
71 72 73 74 75 76 77 78 79 80
81 82 83 84 85 86 87 88 89 90
91 92 93 94 95 96 97 98 99 100
",
            @"48620
",
            TestName = "{m}-2")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 3
3 R 5 B
5 R 3 B
4 R 2 B
",
            @"1 2
",
            TestName = "{m}-1")]
        [TestCase(
            @"7 0
",
            @"0 7
",
            TestName = "{m}-2")]
        [TestCase(
            @"7 6
5 R 3 R
7 R 4 R
4 B 1 R
2 R 3 B
2 B 5 B
1 B 7 B
",
            @"2 1
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4 7
",
            @"5
",
            TestName = "{m}-1")]
        [TestCase(
            @"8 10 9
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"1000000000 1000000000000 998244353
",
            @"919667211
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
