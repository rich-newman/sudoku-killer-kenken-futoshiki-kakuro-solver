using Solver.Puzzles;
using System.Diagnostics;

namespace Harness
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            Sudoku sudoku = CreateSudoku1();
            System.Console.WriteLine("Sudoku Mild No 9596 from the Times, 16th Jan 2018");
            Solver.Console.Show(sudoku.Values);
            sudoku.Solve();
            Solver.Console.Show(sudoku.Values);

            Sudoku sudoku2 = CreateSudoku2();
            System.Console.WriteLine("Sudoku Difficult No 9597 from the Times, 16th Jan 2018");
            Solver.Console.Show(sudoku2.Values);
            sudoku2.Solve();
            Solver.Console.Show(sudoku2.Values);

            Sudoku sudoku3 = CreateSudoku3();
            System.Console.WriteLine("Sudoku Super fiendish No 9598 from the Times, 16th Jan 2018");
            Solver.Console.Show(sudoku3.Values);
            sudoku3.Solve();
            Solver.Console.Show(sudoku3.Values);

            Futoshiki futoshiki = CreateFutoshiki();
            System.Console.WriteLine("Futoshiki No 3087 from the Times, 16th Jan 2018");
            Solver.Console.Show(futoshiki.Values);
            futoshiki.Solve();
            Solver.Console.Show(futoshiki.Values);

            sw.Reset();
            sw.Start();
            Killer killer = CreateKiller();
            System.Console.WriteLine("Killer Tough No 5820 from the Times, 16th Jan 2018");
            killer.Solve();
            Solver.Console.Show(killer.Values);
            sw.Stop();
            System.Console.WriteLine("Killer solution took " + sw.ElapsedMilliseconds / 1000.0 + " seconds");
            System.Console.WriteLine();

            sw.Reset();
            sw.Start();
            Killer wikipediaKiller = CreateWikipediaKiller();
            System.Console.WriteLine("Killer from the Wikipedia page on Killer Sudokus");
            wikipediaKiller.Solve();
            Solver.Console.Show(wikipediaKiller.Values);
            sw.Stop();
            System.Console.WriteLine("Killer solution took " + sw.ElapsedMilliseconds / 1000.0 + " seconds");
            System.Console.WriteLine();

            sw.Reset();
            sw.Start();
            Kakuro kakuro = CreateKakuro();
            System.Console.WriteLine("Kakuro No 2046 from the Times, 16th Jan 2018");
            kakuro.Solve();
            Solver.Console.Show(kakuro.Values);
            sw.Stop();
            System.Console.WriteLine("Kakuro solution took " + sw.ElapsedMilliseconds / 1000.0 + " seconds");
            System.Console.WriteLine();

            sw.Reset();
            sw.Start();
            KenKen kenKen = CreateKenKen();
            System.Console.WriteLine("KenKen Medium No 4226 from the Times, 16th Jan 2018");
            kenKen.Solve();
            Solver.Console.Show(kenKen.Values);
            sw.Stop();
            System.Console.WriteLine("KenKen solution took " + sw.ElapsedMilliseconds / 1000.0 + " seconds");
            System.Console.WriteLine();

            System.Console.ReadLine();
        }

        public static KenKen CreateKenKen()
        {
            KenKen kenKen = new KenKen();
            kenKen.AddBlock(new int[] { 0, 0, 1, 0 }, 1, Operator.Subtract)
                .AddBlock(new int[] { 2, 0, 2, 1 }, 2, Operator.Divide)
                .AddBlock(new int[] { 3, 0, 3, 1 }, 6, Operator.Add)
                .AddBlock(new int[] { 4, 0, 5, 0 }, 20, Operator.Multiply)
                .AddBlock(new int[] { 0, 1, 1, 1 }, 3, Operator.Divide)
                .AddBlock(new int[] { 4, 1, 5, 1, 4, 2 }, 12, Operator.Multiply)
                .AddBlock(new int[] { 0, 2, 1, 2 }, 9, Operator.Add)
                .AddBlock(new int[] { 2, 2, 3, 2 }, 1, Operator.Subtract)
                .AddBlock(new int[] { 5, 2, 5, 3, 5, 4 }, 9, Operator.Add)
                .AddBlock(new int[] { 0, 3, 0, 4 }, 3, Operator.Divide)
                .AddBlock(new int[] { 1, 3, 1, 4 }, 10, Operator.Add)
                .AddBlock(new int[] { 2, 3, 2, 4 }, 1, Operator.Subtract)
                .AddBlock(new int[] { 3, 3, 4, 3, 3, 4 }, 90, Operator.Multiply)
                .AddBlock(new int[] { 0, 5, 1, 5, 2, 5 }, 8, Operator.Add)
                .AddBlock(new int[] { 4, 4, 3, 5, 4, 5, 5, 5 }, 144, Operator.Multiply);
            return kenKen;
        }

        public static Kakuro CreateKakuro()
        {
            Kakuro kakuro = new Kakuro();
            kakuro.AddHorizontalBlock(1, 2, 0, 16)
                .AddHorizontalBlock(6, 9, 0, 29)
                .AddHorizontalBlock(0, 4, 1, 32)
                .AddHorizontalBlock(6, 9, 1, 30)
                .AddHorizontalBlock(0, 1, 2, 9)
                .AddHorizontalBlock(3, 5, 2, 23)
                .AddHorizontalBlock(8, 9, 2, 16)
                .AddHorizontalBlock(0, 1, 3, 6)
                .AddHorizontalBlock(3, 6, 3, 30)
                .AddHorizontalBlock(8, 9, 3, 4)
                .AddHorizontalBlock(2, 3, 4, 17)
                .AddHorizontalBlock(5, 9, 4, 27)
                .AddHorizontalBlock(0, 4, 5, 28)
                .AddHorizontalBlock(6, 7, 5, 14)
                .AddHorizontalBlock(0, 1, 6, 3)
                .AddHorizontalBlock(3, 6, 6, 21)
                .AddHorizontalBlock(8, 9, 6, 13)
                .AddHorizontalBlock(0, 1, 7, 4)
                .AddHorizontalBlock(4, 6, 7, 7)
                .AddHorizontalBlock(8, 9, 7, 8)
                .AddHorizontalBlock(0, 3, 8, 21)
                .AddHorizontalBlock(5, 9, 8, 23)
                .AddHorizontalBlock(0, 3, 9, 19)
                .AddHorizontalBlock(7, 8, 9, 3)
                .AddVerticalBlock(0, 1, 3, 7)
                .AddVerticalBlock(0, 5, 9, 22)
                .AddVerticalBlock(1, 0, 3, 29)
                .AddVerticalBlock(1, 5, 9, 24)
                .AddVerticalBlock(2, 0, 1, 16)
                .AddVerticalBlock(2, 4, 5, 16)
                .AddVerticalBlock(2, 8, 9, 4)
                .AddVerticalBlock(3, 1, 6, 37)
                .AddVerticalBlock(3, 8, 9, 3)
                .AddVerticalBlock(4, 1, 3, 23)
                .AddVerticalBlock(4, 5, 7, 18)
                .AddVerticalBlock(5, 2, 4, 23)
                .AddVerticalBlock(5, 6, 8, 21)
                .AddVerticalBlock(6, 0, 1, 12)
                .AddVerticalBlock(6, 3, 8, 25)
                .AddVerticalBlock(7, 0, 1, 16)
                .AddVerticalBlock(7, 4, 5, 17)
                .AddVerticalBlock(7, 8, 9, 3)
                .AddVerticalBlock(8, 0, 4, 26)
                .AddVerticalBlock(8, 6, 9, 10)
                .AddVerticalBlock(9, 0, 4, 28)
                .AddVerticalBlock(9, 6, 8, 23);
            return kakuro;
        }

        public static Futoshiki CreateFutoshiki()
        {
            Futoshiki futoshiki = new Futoshiki();
            futoshiki.SetValue(4, 0, 3).SetValue(1, 3, 1).SetValue(0, 4, 1);
            futoshiki.AddGreaterThan(0, 0, 1, 0).AddGreaterThan(3, 1, 3, 0).AddGreaterThan(0, 1, 1, 1).
                AddGreaterThan(2, 1, 3, 1).AddGreaterThan(0, 3, 0, 2).AddGreaterThan(2, 4, 2, 3).
                AddGreaterThan(4, 4, 4, 3);
            return futoshiki;
        }

        public static Killer CreateKiller()
        {
            Killer killer = new Killer();
            killer.AddBlock(new int[] { 0, 0, 0, 1 }, 17)
                .AddBlock(new int[] { 1, 0, 2, 0, 3, 0 }, 12)
                .AddBlock(new int[] { 4, 0, 4, 1, 5, 1 }, 19)
                .AddBlock(new int[] { 5, 0, 6, 0, 7, 0, 8, 0 }, 19)
                .AddBlock(new int[] { 1, 1, 1, 2, 1, 3, 1, 4 }, 19)
                .AddBlock(new int[] { 2, 1, 2, 2 }, 8)
                .AddBlock(new int[] { 3, 1, 3, 2 }, 16)
                .AddBlock(new int[] { 6, 1, 6, 2, 6, 3 }, 19)
                .AddBlock(new int[] { 7, 1, 8, 1 }, 6)
                .AddBlock(new int[] { 0, 2, 0, 3 }, 10)
                .AddBlock(new int[] { 4, 2, 5, 2, 4, 3, 5, 3 }, 15)
                .AddBlock(new int[] { 7, 2, 8, 2, 7, 3, 8, 3 }, 18)
                .AddBlock(new int[] { 2, 3, 3, 3 }, 9)
                .AddBlock(new int[] { 0, 4, 0, 5, 0, 6 }, 9)
                .AddBlock(new int[] { 2, 4, 3, 4, 4, 4, 5, 4 }, 20)
                .AddBlock(new int[] { 6, 4, 7, 4 }, 7)
                .AddBlock(new int[] { 8, 4, 8, 5 }, 7)
                .AddBlock(new int[] { 1, 5, 1, 6 }, 14)
                .AddBlock(new int[] { 2, 5, 3, 5 }, 6)
                .AddBlock(new int[] { 4, 5, 4, 6 }, 9)
                .AddBlock(new int[] { 5, 5, 5, 6, 5, 7 }, 22)
                .AddBlock(new int[] { 6, 5, 7, 5 }, 16)
                .AddBlock(new int[] { 2, 6, 3, 6 }, 13)
                .AddBlock(new int[] { 6, 6, 7, 6 }, 9)
                .AddBlock(new int[] { 8, 6, 8, 7 }, 8)
                .AddBlock(new int[] { 0, 7, 1, 7 }, 5)
                .AddBlock(new int[] { 2, 7, 3, 7 }, 10)
                .AddBlock(new int[] { 4, 7, 2, 8, 3, 8, 4, 8 }, 20)
                .AddBlock(new int[] { 6, 7, 7, 7, 5, 8, 6, 8 }, 21)
                .AddBlock(new int[] { 0, 8, 1, 8 }, 12)
                .AddBlock(new int[] { 7, 8, 8, 8 }, 10);
            return killer;
        }

        public static Killer CreateWikipediaKiller()
        {
            // https://en.wikipedia.org/wiki/Killer_sudoku#/media/File:Killersudoku_color.svg
            Killer killer = new Killer();
            killer.AddBlock(new int[] { 0, 0, 1, 0 }, 3)
                .AddBlock(new int[] { 2, 0, 3, 0, 4, 0 }, 15)
                .AddBlock(new int[] { 5, 0, 4, 1, 5, 1, 4, 2 }, 22)
                .AddBlock(new int[] { 6, 0, 6, 1 }, 4)
                .AddBlock(new int[] { 7, 0, 7, 1 }, 16)
                .AddBlock(new int[] { 8, 0, 8, 1, 8, 2, 8, 3 }, 15)
                .AddBlock(new int[] { 0, 1, 1, 1, 0, 2, 1, 2 }, 25)
                .AddBlock(new int[] { 2, 1, 3, 1 }, 17)
                .AddBlock(new int[] { 2, 2, 3, 2, 3, 3 }, 9)
                .AddBlock(new int[] { 5, 2, 5, 3, 5, 4 }, 8)
                .AddBlock(new int[] { 6, 2, 7, 2, 6, 3 }, 20)
                .AddBlock(new int[] { 0, 3, 0, 4 }, 6)
                .AddBlock(new int[] { 1, 3, 2, 3 }, 14)
                .AddBlock(new int[] { 4, 3, 4, 4, 4, 5 }, 17)
                .AddBlock(new int[] { 7, 3, 6, 4, 7, 4 }, 17)
                .AddBlock(new int[] { 1, 4, 2, 4, 1, 5 }, 13)
                .AddBlock(new int[] { 3, 4, 3, 5, 3, 6 }, 20)
                .AddBlock(new int[] { 8, 4, 8, 5 }, 12)
                .AddBlock(new int[] { 0, 5, 0, 6, 0, 7, 0, 8 }, 27)
                .AddBlock(new int[] { 2, 5, 1, 6, 2, 6 }, 6)
                .AddBlock(new int[] { 5, 5, 5, 6, 6, 6 }, 20)
                .AddBlock(new int[] { 6, 5, 7, 5 }, 6)
                .AddBlock(new int[] { 4, 6, 3, 7, 4, 7, 3, 8 }, 10)
                .AddBlock(new int[] { 7, 6, 8, 6, 7, 7, 8, 7 }, 14)
                .AddBlock(new int[] { 1, 7, 1, 8 }, 8)
                .AddBlock(new int[] { 2, 7, 2, 8 }, 16)
                .AddBlock(new int[] { 5, 7, 6, 7 }, 15)
                .AddBlock(new int[] { 4, 8, 5, 8, 6, 8 }, 13)
                .AddBlock(new int[] { 7, 8, 8, 8 }, 17);
            return killer;
        }

        public static Sudoku CreateSudoku1()
        {
            Sudoku sudoku = new Sudoku();
            sudoku.SetValue(0, 0, 6)
                .SetValue(1, 0, 5)
                .SetValue(5, 0, 1)
                .SetValue(8, 0, 4)
                .SetValue(1, 1, 8)
                .SetValue(8, 1, 2)
                .SetValue(4, 2, 5)
                .SetValue(5, 2, 6)
                .SetValue(7, 2, 7)
                .SetValue(8, 2, 8)
                .SetValue(0, 3, 7)
                .SetValue(5, 3, 3)
                .SetValue(8, 3, 5)
                .SetValue(1, 4, 4)
                .SetValue(3, 4, 7)
                .SetValue(5, 4, 2)
                .SetValue(7, 4, 3)
                .SetValue(0, 5, 3)
                .SetValue(3, 5, 6)
                .SetValue(8, 5, 7)
                .SetValue(0, 6, 8)
                .SetValue(1, 6, 7)
                .SetValue(3, 6, 2)
                .SetValue(4, 6, 6)
                .SetValue(0, 7, 9)
                .SetValue(7, 7, 4)
                .SetValue(0, 8, 5)
                .SetValue(3, 8, 9)
                .SetValue(7, 8, 8)
                .SetValue(8, 8, 3);
            return sudoku;
        }

        public static Sudoku CreateSudoku2()
        {
            Sudoku sudoku = new Sudoku();
            sudoku.SetValue(1, 0, 5)
                .SetValue(7, 0, 8)
                .SetValue(3, 1, 5)
                .SetValue(5, 1, 9)
                .SetValue(0, 2, 1)
                .SetValue(2, 2, 4)
                .SetValue(6, 2, 6)
                .SetValue(8, 2, 5)
                .SetValue(1, 3, 4)
                .SetValue(3, 3, 8)
                .SetValue(5, 3, 7)
                .SetValue(7, 3, 6)
                .SetValue(2, 4, 6)
                .SetValue(6, 4, 8)
                .SetValue(1, 5, 7)
                .SetValue(2, 5, 8)
                .SetValue(6, 5, 9)
                .SetValue(7, 5, 3)
                .SetValue(0, 6, 6)
                .SetValue(8, 6, 4)
                .SetValue(0, 7, 4)
                .SetValue(3, 7, 2)
                .SetValue(5, 7, 1)
                .SetValue(8, 7, 8)
                .SetValue(1, 8, 1)
                .SetValue(2, 8, 5)
                .SetValue(6, 8, 3)
                .SetValue(7, 8, 2);
            return sudoku;
        }

        public static Sudoku CreateSudoku3()
        {
            Sudoku sudoku = new Sudoku();
            sudoku.SetValue(3, 1, 4)
                .SetValue(4, 1, 5)
                .SetValue(7, 1, 7)
                .SetValue(2, 2, 8)
                .SetValue(3, 2, 2)
                .SetValue(6, 2, 9)
                .SetValue(7, 2, 4)
                .SetValue(8, 2, 5)
                .SetValue(1, 3, 5)
                .SetValue(2, 3, 6)
                .SetValue(4, 3, 7)
                .SetValue(8, 3, 2)
                .SetValue(0, 4, 7)
                .SetValue(8, 4, 8)
                .SetValue(0, 5, 4)
                .SetValue(4, 5, 8)
                .SetValue(6, 5, 3)
                .SetValue(7, 5, 5)
                .SetValue(0, 6, 3)
                .SetValue(1, 6, 9)
                .SetValue(2, 6, 5)
                .SetValue(5, 6, 7)
                .SetValue(6, 6, 1)
                .SetValue(1, 7, 8)
                .SetValue(4, 7, 6)
                .SetValue(5, 7, 1);
            return sudoku;
        }
    }
}
/*
 * OUTPUT:
Sudoku Mild No 9596 from the Times, 16th Jan 2018
650001004
080000002
000056078
700003005
040702030
300600007
870260000
900000040
500900083

657821394
481379562
239456178
796143825
145782639
328695417
873264951
912538746
564917283

Sudoku Difficult No 9597 from the Times, 16th Jan 2018
050000080
000509000
104000605
040807060
006000800
078000930
600000004
400201008
015000320

253176489
867549213
194382675
941837562
326915847
578624931
682753194
439261758
715498326

Sudoku Super fiendish No 9598 from the Times, 16th Jan 2018
000000000
000450070
008200945
056070002
700000008
400080350
395007100
080061000
000000000

524719863
963458271
178236945
856173492
732594618
419682357
395847126
287961534
641325789

Futoshiki No 3087 from the Times, 16th Jan 2018
00003
00000
00000
01000
10000

54213
32541
25134
41352
13425

Killer Tough No 5820 from the Times, 16th Jan 2018: Works but is very slow
847162359
913785642
625934817
496371528
571298436
382456791
168549273
234617985
759823164

Killer solution took 150.276 seconds

Kakuro No 2046 from the Times, 16th Jan 2018: Works but is very slow
X97XXX5789
48956X7968
27X986XX97
15X7986X13
XX98X97821
24769X59XX
12X2784X49
31XX241X26
9831X92138
7912XXX21X

Kakuro solution took 151.119 seconds

KenKen Medium No 4226 from the Times, 16th Jan 2018
236145
623514
451236
164352
345621
512463

KenKen solution took 0.042 seconds
 */
