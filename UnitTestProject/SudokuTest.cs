using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;
using Solver.Constraints;
using Solver.Puzzles;

namespace UnitTestProject
{
    [TestClass]
    public class SudokuTest
    {
        [TestMethod]
        public void CreationTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            Output.Show(sudoku.Values);
            Assert.AreEqual(9, sudoku.Values.GetLength(0));
            Assert.AreEqual(9, sudoku.Values.GetLength(1));
            Assert.AreEqual(3, sudoku.Constraints.Count);
        }

        [TestMethod]
        public void RowConstraintSuccessTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            RowConstraint constraint = new RowConstraint();
            bool result = constraint.Evaluate(sudoku, xCoord: 2, yCoord: 0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RowConstraintFailTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(2, 0, 5);  // Duplicate value in row 0
            Output.Show(sudoku.Values);
            RowConstraint constraint = new RowConstraint();
            bool result = constraint.Evaluate(sudoku, xCoord: 2, yCoord: 0);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void RowConstraintSuccessFullRowTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(2, 0, 2).SetValue(3, 0, 3).SetValue(4, 0, 7).SetValue(6, 0, 8).SetValue(7, 0, 9);
            Output.Show(sudoku.Values);
            RowConstraint constraint = new RowConstraint();
            bool result = constraint.Evaluate(sudoku, xCoord: 2, yCoord: 0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RowConstraintFailureFullRowTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(2, 0, 2).SetValue(3, 0, 3).SetValue(4, 0, 7).SetValue(6, 0, 8).SetValue(7, 0, 4);
            Output.Show(sudoku.Values);
            RowConstraint constraint = new RowConstraint();
            bool result = constraint.Evaluate(sudoku, xCoord: 2, yCoord: 0);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ColumnConstraintSuccessTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            ColumnConstraint constraint = new ColumnConstraint();
            bool result = constraint.Evaluate(sudoku, xCoord: 2, yCoord: 0);
            Assert.IsTrue(result);
            result = constraint.Evaluate(sudoku, xCoord: 1, yCoord: 0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ColumnConstraintFailTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(1, 2, 7);  // Duplicate value in Column 1
            Output.Show(sudoku.Values);
            ColumnConstraint constraint = new ColumnConstraint();
            bool result = constraint.Evaluate(sudoku, xCoord: 1, yCoord: 0);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ColumnConstraintSuccessFullColumnTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(1, 2, 1).SetValue(1, 3, 2).SetValue(1, 5, 3).SetValue(1, 7, 6).SetValue(1, 8, 9);
            Output.Show(sudoku.Values);
            ColumnConstraint constraint = new ColumnConstraint();
            bool result = constraint.Evaluate(sudoku, xCoord:1, yCoord: 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ColumnConstraintFailureFullColumnTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(1, 2, 1).SetValue(1, 3, 2).SetValue(1, 5, 3).SetValue(1, 7, 6).SetValue(1, 8, 6);
            ColumnConstraint constraint = new ColumnConstraint();
            bool result = constraint.Evaluate(sudoku, xCoord: 1, yCoord: 2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SquareBlockConstraintSuccessTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            SquareBlockConstraint constraint = new SquareBlockConstraint(3);
            bool result = constraint.Evaluate(sudoku, xCoord: 0, yCoord: 2);
            Assert.IsTrue(result);
            result = constraint.Evaluate(sudoku, xCoord: 4, yCoord: 3);   // Center block
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SquareBlockConstraintFailTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(4, 4, 7);  // Duplicate value in SquareBlock 1
            SquareBlockConstraint constraint = new SquareBlockConstraint(3);
            bool result = constraint.Evaluate(sudoku, xCoord: 4, yCoord: 3);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void SquareBlockConstraintSuccessFullSquareBlockTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(3, 3, 1).SetValue(4, 3, 4).SetValue(4, 4, 8).SetValue(4, 5, 9).SetValue(5, 5, 5);
            SquareBlockConstraint constraint = new SquareBlockConstraint(3);
            bool result = constraint.Evaluate(sudoku, xCoord: 4, yCoord: 3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SquareBlockConstraintFailureFullSquareBlockTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(3, 3, 1).SetValue(4, 3, 4).SetValue(4, 4, 8).SetValue(4, 5, 9).SetValue(5, 5, 1);  // Two 1's
            SquareBlockConstraint constraint = new SquareBlockConstraint(3);
            bool result = constraint.Evaluate(sudoku, xCoord: 4, yCoord: 3);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateValuesSuccessTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(3, 3, 1).SetValue(4, 3, 4).SetValue(4, 4, 8).SetValue(4, 5, 9).SetValue(5, 5, 5);
            bool result = sudoku.Solver.ValidateValues();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateValuesFailureTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            sudoku.SetValue(3, 3, 1).SetValue(4, 3, 4).SetValue(4, 4, 8).SetValue(4, 5, 9).SetValue(5, 5, 1);
            bool result = sudoku.Solver.ValidateValues();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BasicSolveTest()
        {
            Sudoku sudoku = CreateTestSudoku();
            Output.Show(sudoku.Values);
            sudoku.Solver.Solve();
            Output.Show(sudoku.Values);
            //sudoku.Solver.BasicSolve();
        }

        private Sudoku CreateTestSudoku()
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
    }
}
