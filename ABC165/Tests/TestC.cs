using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 4 3
        1 3 3 100
        1 2 2 10
        2 3 2 10";
            var output = @"110";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 6 10
        2 4 1 86568
        1 4 0 90629
        2 3 0 90310
        3 4 1 29211
        3 4 3 78537
        3 4 2 8580
        1 2 1 96263
        1 4 2 2156
        1 2 0 94325
        1 4 3 94328";
            var output = @"357500";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 10 1
        1 10 9 1";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}