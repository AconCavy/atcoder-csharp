using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
3 1 5 4 2
";
            const string output = @"31542
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
1 2 3 4 5 6
";
            const string output = @"123456
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7
7 6 5 4 3 2 1
";
            const string output = @"7654321
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"20
19 11 10 7 8 9 17 18 20 4 3 15 16 1 5 14 6 2 13 12
";
            const string output = @"370453866
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
