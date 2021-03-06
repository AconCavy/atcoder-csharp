using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 8 2";
            var output = @"3
4
7
8";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 8 3";
            var output = @"4
5
6
7
8";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2 9 100";
            var output = @"2
3
4
5
6
7
8
9";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
