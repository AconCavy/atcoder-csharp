using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 3 7 11
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"100 100 1 100
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
