using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3 7
1 1 4
1 2 7
2 1 3
2 3 5
3 1 2
3 2 5
3 3 5
";
            const string output = @"1
0
2
0
3
1
0
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 7 20
2 7 8
2 6 4
4 1 9
1 5 4
2 2 7
5 5 2
1 7 2
4 6 6
1 4 1
2 1 10
5 6 9
5 3 3
3 7 9
3 6 3
4 3 4
3 3 10
4 2 1
3 5 4
1 2 6
4 7 9
";
            const string output = @"2
4
1
5
3
6
6
2
7
0
0
4
1
5
3
0
5
2
4
0
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
