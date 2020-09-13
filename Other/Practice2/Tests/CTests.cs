using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
4 10 6 3
6 5 4 3
1 1 0 0
31415 92653 58979 32384
1000000000 1000000000 999999999 999999999";
            var output = @"3
13
0
314095480
499999999500000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
