using Solver;
using Solver.Puzzles;
using System.Diagnostics;

namespace Harness
{
    public class Program
    {
        static void Main(string[] args)
        {
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

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Killer killer = CreateKiller();
            System.Console.WriteLine("Killer Tough No 5820 from the Times, 16th Jan 2018: Works but is very slow");
            //Solver.Console.Show(killer.Values);
            killer.Solve();
            Solver.Console.Show(killer.Values);
            sw.Stop();
            System.Console.WriteLine("Killer solution took " + sw.ElapsedMilliseconds / 1000.0 + " seconds");

            System.Console.ReadLine();
        }

        public static Futoshiki CreateFutoshiki()
        {
            Futoshiki futoshiki = new Futoshiki();
            futoshiki.SetValue(4, 0, 3).SetValue(1, 3, 1).SetValue(0, 4, 1);
            futoshiki.AddGreaterThanConstraint(0, 0, 1, 0).AddGreaterThanConstraint(3, 1, 3, 0).AddGreaterThanConstraint(0, 1, 1, 1).
                AddGreaterThanConstraint(2, 1, 3, 1).AddGreaterThanConstraint(0, 3, 0, 2).AddGreaterThanConstraint(2, 4, 2, 3).
                AddGreaterThanConstraint(4, 4, 4, 3);
            return futoshiki;
        }

        public static Killer CreateKiller()
        {
            Killer killer = new Killer();
            killer.AddBlockSumConstraint(new int[] { 0, 0, 0, 1 }, 17)
                .AddBlockSumConstraint(new int[] { 1, 0, 2, 0, 3, 0 }, 12)
                .AddBlockSumConstraint(new int[] { 4, 0, 4, 1, 5, 1 }, 19)
                .AddBlockSumConstraint(new int[] { 5, 0, 6, 0, 7, 0, 8, 0 }, 19)
                .AddBlockSumConstraint(new int[] { 1, 1, 1, 2, 1, 3, 1, 4 }, 19)
                .AddBlockSumConstraint(new int[] { 2, 1, 2, 2 }, 8)
                .AddBlockSumConstraint(new int[] { 3, 1, 3, 2 }, 16)
                .AddBlockSumConstraint(new int[] { 6, 1, 6, 2, 6, 3 }, 19)
                .AddBlockSumConstraint(new int[] { 7, 1, 8, 1 }, 6)
                .AddBlockSumConstraint(new int[] { 0, 2, 0, 3 }, 10)
                .AddBlockSumConstraint(new int[] { 4, 2, 5, 2, 4, 3, 5, 3 }, 15)
                .AddBlockSumConstraint(new int[] { 7, 2, 8, 2, 7, 3, 8, 3 }, 18)
                .AddBlockSumConstraint(new int[] { 2, 3, 3, 3 }, 9)
                .AddBlockSumConstraint(new int[] { 0, 4, 0, 5, 0, 6 }, 9)
                .AddBlockSumConstraint(new int[] { 2, 4, 3, 4, 4, 4, 5, 4 }, 20)
                .AddBlockSumConstraint(new int[] { 6, 4, 7, 4 }, 7)
                .AddBlockSumConstraint(new int[] { 8, 4, 8, 5 }, 7)
                .AddBlockSumConstraint(new int[] { 1, 5, 1, 6 }, 14)
                .AddBlockSumConstraint(new int[] { 2, 5, 3, 5 }, 6)
                .AddBlockSumConstraint(new int[] { 4, 5, 4, 6 }, 9)
                .AddBlockSumConstraint(new int[] { 5, 5, 5, 6, 5, 7 }, 22)
                .AddBlockSumConstraint(new int[] { 6, 5, 7, 5 }, 16)
                .AddBlockSumConstraint(new int[] { 2, 6, 3, 6 }, 13)
                .AddBlockSumConstraint(new int[] { 6, 6, 7, 6 }, 9)
                .AddBlockSumConstraint(new int[] { 8, 6, 8, 7 }, 8)
                .AddBlockSumConstraint(new int[] { 0, 7, 1, 7 }, 5)
                .AddBlockSumConstraint(new int[] { 2, 7, 3, 7 }, 10)
                .AddBlockSumConstraint(new int[] { 4, 7, 2, 8, 3, 8, 4, 8 }, 20)
                .AddBlockSumConstraint(new int[] { 6, 7, 7, 7, 5, 8, 6, 8 }, 21)
                .AddBlockSumConstraint(new int[] { 0, 8, 1, 8 }, 12)
                .AddBlockSumConstraint(new int[] { 7, 8, 8, 8 }, 10);
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

        // public static Sudoku CreateSudoku1Reflection()
        // {
        //     Sudoku sudoku = new Sudoku();
        //     sudoku.SetValue(0, 0, 6)
        //         .SetValue(0, 1, 5)
        //         .SetValue(0, 5, 1)
        //         .SetValue(0, 8, 4)
        //         .SetValue(1, 1, 8)
        //         .SetValue(1, 8, 2)
        //         .SetValue(2, 4, 5)
        //         .SetValue(2, 5, 6)
        //         .SetValue(2, 7, 7)
        //         .SetValue(2, 8, 8)
        //         .SetValue(3, 0, 7)
        //         .SetValue(3, 5, 3)
        //         .SetValue(3, 8, 5)
        //         .SetValue(4, 1, 4)
        //         .SetValue(4, 3, 7)
        //         .SetValue(4, 5, 2)
        //         .SetValue(4, 7, 3)
        //         .SetValue(5, 0, 3)
        //         .SetValue(5, 3, 6)
        //         .SetValue(5, 8, 7)
        //         .SetValue(6, 0, 8)
        //         .SetValue(6, 1, 7)
        //         .SetValue(6, 3, 2)
        //         .SetValue(6, 4, 6)
        //         .SetValue(7, 0, 9)
        //         .SetValue(7, 7, 4)
        //         .SetValue(8, 0, 5)
        //         .SetValue(8, 3, 9)
        //         .SetValue(8, 7, 8)
        //         .SetValue(8, 8, 3);
        //     return sudoku;
        //}
    }
}
