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
            const string input = @"4
4000 4400 5000 3200
3
3312
2992
4229
";
            const string output = @"112
208
171
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
4000
10
3582
3538
3320
3312
3296
3257
3111
3040
3013
2994
";
            const string output = @"418
462
680
688
704
743
889
960
987
1006
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
869120000 998244353 777777777 123456789 100100100 464646464 987654321 252525252 869120001 1000000000
10
4229
20210406
1
268435456
3582
536870912
1000000000
869120
99999999
869120001
";
            const string output = @"100095871
79889694
100100099
15910204
100096518
72224448
0
99230980
100101
0
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"100
298750376 229032640 602876667 944779015 909539868 533609371 231368330 445484152 408704870 850216874 349286798 30417810 807260002 554049450 40706045 380488344 749325840 801881841 459457853 66691229 5235900 8100458 46697277 997429858 827651689 790051948 981897272 271364774 536232393 997361572 449659237 602191750 294800444 346669663 792837293 277667068 997282249 468293808 444906878 702693341 894286137 845317003 27053625 926547765 739689211 447395911 902031510 326127348 582956343 842918193 235655766 844300842 438389323 406413067 862896425 464876303 68833418 76340212 911399808 745744264 551223563 854507876 196296968 52144186 431165823 275217640 424495332 847375861 337078801 83054466 648322745 694789156 301518763 319851750 432518459 772897937 630628124 581390864 313132255 350770227 642944345 677742851 448945480 688009163 160941957 290297295 5532462 823543277 19634445 15791361 193309093 66202596 72364149 743270896 297240520 264035189 898589962 59916738 307942952 403411309
30
930579110
22697034
44652533
280533771
753567118
684927419
923477579
557613803
779616458
389130756
323671659
3117850
408004003
224808850
18421958
359047808
364572866
334631363
854759331
647435074
826055423
668443532
620408208
32237184
67299071
251185742
217292659
16181227
850865411
218577687
";
            const string output = @"4031345
3062589
2044744
2866703
4241278
3081744
3070186
3564353
6718521
8642412
2455689
2118050
700867
4223790
1212487
8277581
13802639
2447438
251455
887671
1596266
9299319
10219916
1819374
607842
12849447
11739981
389866
648537
10454953
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
