using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 3
1 2 3
8 9 10
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 1
1
2
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 4
1346 1347 1348 1349
1353 1354 1355 1356
1360 1361 1362 1363
1367 1368 1369 1370
1374 1375 1376 1377
1381 1382 1383 1384
1388 1389 1390 1391
1395 1396 1397 1398
1402 1403 1404 1405
1409 1410 1411 1412
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}