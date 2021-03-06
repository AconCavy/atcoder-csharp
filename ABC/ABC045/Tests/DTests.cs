using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 5 8
1 1
1 4
1 5
2 3
3 1
3 2
3 4
4 4";
            var output = @"0
0
0
2
4
0
0
0
0
0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10 10 20
1 1
1 4
1 9
2 5
3 10
4 2
4 7
5 9
6 4
6 6
6 7
7 1
7 3
7 7
8 1
8 5
8 10
9 2
10 4
10 9";
            var output = @"4
26
22
10
2
0
0
0
0
0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1000000000 1000000000 0";
            var output = @"999999996000000004
0
0
0
0
0
0
0
0
0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
