using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BLTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3
1 2 3
2 3 1
1 2 -1
1 3 2
";
            const string output = @"3
4
4
";
            Tester.InOutTest(Tasks.BL.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"20 10
61 51 92 -100 -89 -65 -89 -64 -74 7 87 -2 51 -39 -50 63 -23 36 74 37
2 2 -45
6 19 82
2 9 36
7 13 71
16 20 90
18 20 -24
14 17 -78
10 11 -55
7 19 -26
20 20 -7
";
            const string output = @"1164
1328
1256
1350
1440
1416
1572
1482
1430
1437
";
            Tester.InOutTest(Tasks.BL.Solve, input, output);
        }
    }
}
