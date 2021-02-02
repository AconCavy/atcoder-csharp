using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3 5
#.#
.#.
#.#
";
            const string output = @"1 1 2
3 3 3
4 4 5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 7 7
#...#.#
..#...#
.#..#..
";
            const string output = @"1 1 1 1 2 2 3
4 4 4 4 4 4 5
6 6 6 6 7 7 7
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"13 21 106
.....................
.####.####.####.####.
..#.#..#.#.#....#....
..#.#..#.#.#....#....
..#.#..#.#.#....#....
.####.####.####.####.
.....................
.####.####.####.####.
....#.#..#....#.#..#.
.####.#..#.####.#..#.
.#....#..#.#....#..#.
.####.####.####.####.
.....................
";
            const string output = @"1 1 2 3 4 4 5 6 7 8 8 9 10 11 12 12 13 14 15 16 16
1 1 2 3 4 4 5 6 7 8 8 9 10 11 12 12 13 14 15 16 16
17 17 17 17 18 18 18 19 19 20 20 21 21 21 21 21 22 22 22 22 22
23 23 23 23 24 24 24 25 25 26 26 27 27 27 27 27 28 28 28 28 28
29 29 29 29 30 30 30 31 31 32 32 33 33 33 33 33 34 34 34 34 34
35 35 36 37 38 38 39 40 41 42 42 43 44 45 46 46 47 48 49 50 50
35 35 36 37 38 38 39 40 41 42 42 43 44 45 46 46 47 48 49 50 50
51 51 52 53 54 54 55 56 57 58 58 59 60 61 62 62 63 64 65 66 66
67 67 67 67 67 67 68 68 68 69 69 69 69 69 70 70 71 71 71 72 72
73 73 74 75 76 76 77 77 77 78 78 79 80 81 82 82 83 83 83 84 84
85 85 85 85 85 85 86 86 86 87 87 88 88 88 88 88 89 89 89 90 90
91 91 92 93 94 94 95 96 97 98 98 99 100 101 102 102 103 104 105 106 106
91 91 92 93 94 94 95 96 97 98 98 99 100 101 102 102 103 104 105 106 106
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
