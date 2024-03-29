using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ITests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-5;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
5 0
-5 0
-1 3
2 4
";
            const string output = @"1 -3
-2 -4
";
            Tester.InOutTest(Tasks.I.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
4 4
12 10
12 4
8 7
-4 -2
100 10
";
            const string output = @"1.4 -4.8
0 0
-15 0
75.4 -52.8
";
            Tester.InOutTest(Tasks.I.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
-40336 -25353
25518 98473
-66200 57666
23235 -64774
56870 -67151
-99509 73639
39965 -61027
-54385 -34598
-57063 14129
63186 -88708
88770 85106
-92520 69200
";
            const string output = @"-8970.87249328212 61817.21737274555
-75079.28924877638 -74637.35403870217
-61384.55754506934 -105449.9760881721
-10508.55928227892 98726.04733711783
-63915.43362406853 -87648.93490309674
-84883.41976667292 8062.914405771756
-43119.58914921946 33307.21406245974
-77451.63868397648 -121148.543178062
88022.56926540422 -62121.98851386775
-11146.07084342446 90471.08392051774
";
            Tester.InOutTest(Tasks.I.Solve, input, output, RelativeError);
        }
    }
}
