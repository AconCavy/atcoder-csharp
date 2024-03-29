using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
3
1 3 2
2
5 4
2
1 2
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
8
16 6 15 10 18 13 17 11
13
4 10 6 4 14 17 13 9 3 9 4 8 14
11
11 17 12 3 13 8 10 11 18 2 19
10
18 11 16 19 4 17 7 3 5 8
3
3 10 9
13
8 17 20 8 20 1 5 17 4 16 18 20 4
15
11 2 1 16 8 17 4 7 3 6 4 13 16 16 16
2
12 12
8
7 14 7 5 8 17 19 4
15
3 6 1 16 11 5 3 15 9 15 12 15 5 19 7
20
4 3 7 6 1 8 2 3 9 8 6 3 10 9 7 7 3 2 2 10
";
            const string output = @"12430
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }
    }
}
