using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1
869
120
";
            const string output = @"749
";
            Tester.InOutTest(Tasks.N.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
8 6 9 1 2 0
1 5 7 2 3 9
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.N.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
31 41 59 26 53 58 97 93 23 84
17 32 5 8 7 56 88 77 29 35
";
            const string output = @"211
";
            Tester.InOutTest(Tasks.N.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"20
804289382 846930886 681692776 714636914 957747792 424238335 719885386 649760491 596516649 189641420 25202361 350490026 783368690 102520058 44897761 967513925 365180539 540383425 304089172 303455735
35005211 521595368 294702567 726956428 336465782 861021530 278722862 233665123 145174065 468703135 101513928 801979801 315634021 635723058 369133068 125898166 59961392 89018454 628175011 656478041
";
            const string output = @"2736647674
";
            Tester.InOutTest(Tasks.N.Solve, input, output);
        }
    }
}
