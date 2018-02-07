using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;

namespace UnitTestProject
{
    [TestClass]
    public class SolverTest
    {
        /*
         * I wanted something that would test recursion using the very unrealistic scenario below.  The only way
         * to do this is to invent a puzzle with some truly strange criteria, which is what the test below does.
We solve for forced values and have three empties
We guess 1 in first empty, immediately gives conflict
We guess 2 in first empty, is valid, recurse, we force values, second empty is filled.  We guess 1-9 in third empty get conflict in all - does this work?
We guess 3 in first empty, is valid, we force values, nothing forced, we guess 1 in second empty, valid, force values, nothing (unrealistic!), we guess 1 in third empty, conflict, we guess 2 in third empty, solves
         */
        [TestMethod]
        public void RecursionTest()
        {
            RecursionPuzzle recursionPuzzle = new RecursionPuzzle();
            recursionPuzzle.SetValue(0, 0, 9).SetValue(1, 0, 8).SetValue(2, 0, 7).SetValue(0, 1, 6).SetValue(1, 1, 5).SetValue(2, 1, 4);
            // Three empties are [0,2], [1,2], [2,2].
            recursionPuzzle.Solver.Solve();
            Assert.AreEqual(3, recursionPuzzle.Values[0, 2]);
            Assert.AreEqual(1, recursionPuzzle.Values[1, 2]);
            Assert.AreEqual(2, recursionPuzzle.Values[2, 2]);
        }

        public class RecursionPuzzle : Puzzle
        {
            public RecursionPuzzle()
            {
                GridSize = 3;
                MaxValue = 9;
                Values = new int[GridSize, GridSize];
                Criteria.Add(new Criterion1());
            }
        }

        public class Criterion1 : Criterion
        {
            public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
            {
                // Totally unrealistic puzzle criterion to check the recursion
                // We should: 
                // 1.  Guess 1 in [0, 2] and it should be invalid immediately
                // 2.  Guess 2 in [0, 2] and then iterate over all values for [1, 2] and [2, 2] finding no valid solution
                // 3.  Guess 3 in [0, 2], guess 1 in [1, 2], then guess 1 in [2, 2] which will fail, then guess 2 in [2, 2] which should succeed
                if (puzzle.Values[0, 2] == 1) return false;
                if (puzzle.Values[0, 2] == 2 && puzzle.Values[1,2] != 0 && puzzle.Values[2, 2] != 0) return false;
                if (puzzle.Values[0, 2] == 3 && puzzle.Values[1, 2] == 1 && puzzle.Values[2, 2] == 1) return false;

                return true;
            }
        }

        public class Criterion2 : Criterion
        {
            public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
            {
                return true;
            }
        }
    }
}
