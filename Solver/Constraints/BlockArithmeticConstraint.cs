using Solver.Puzzles;

namespace Solver.Constraints
{
    // Used in KenKens where we need all arithmetic operators on our blocks but, unlike the BlockSumNoDuplicatesConstraint,
    // don't explicitly need to check for duplicates in the block
    public abstract class BlockArithmeticConstraint : Constraint
    {
        private int[] cells;
        public int[] Cells => cells;
        private int value;
        public BlockArithmeticConstraint(int[] cells, int value) { this.cells = cells; this.value = value; }
        public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
        {
            for (int i = 0; i < cells.Length; i += 2)
            {
                if (cells[i] == xCoord && cells[i + 1] == yCoord)
                {
                    int localCalc = puzzle.Values[cells[0], cells[1]];
                    if (localCalc == 0) return true;
                    for (int j = 2; j < cells.Length; j += 2)
                    {
                        int cellValue = puzzle.Values[cells[j], cells[j + 1]];
                        if (cellValue == 0) return true;
                        localCalc = DoArithmetic(localCalc, cellValue);
                    }
                    return TestResult(localCalc, value);
                }
            }
            return true;
        }

        public abstract int DoArithmetic(int localCalc, int cellValue);
        public abstract bool TestResult(int localCalc, int value);
    }

    public class BlockAddConstraint : BlockArithmeticConstraint
    {
        public BlockAddConstraint(int[] cells, int value) : base(cells, value) { }
        public override int DoArithmetic(int localCalc, int cellValue) => localCalc + cellValue;
        public override bool TestResult(int localCalc, int value) => localCalc == value;
    }

    public class BlockSubtractConstraint : BlockArithmeticConstraint
    {
        public BlockSubtractConstraint(int[] cells, int value) : base(cells, value) { }
        public override int DoArithmetic(int localCalc, int cellValue) => localCalc - cellValue;
        public override bool TestResult(int localCalc, int value) => localCalc == value || localCalc == -value;
    }

    public class BlockMultiplyConstraint : BlockArithmeticConstraint
    {
        public BlockMultiplyConstraint(int[] cells, int value) : base(cells, value) { }
        public override int DoArithmetic(int localCalc, int cellValue) => localCalc * cellValue;
        public override bool TestResult(int localCalc, int value) => localCalc == value;
    }

    public class BlockDivideConstraint : BlockArithmeticConstraint
    {
        public BlockDivideConstraint(int[] cells, int value) : base(cells, value) { }
        public override int DoArithmetic(int localCalc, int cellValue)
        {
            bool isValid = localCalc > cellValue ? localCalc % cellValue == 0 : cellValue % localCalc == 0;
            if (!isValid) return -1;
            return localCalc > cellValue ? localCalc / cellValue : cellValue / localCalc;
        }
        public override bool TestResult(int localCalc, int value) => localCalc != -1 && localCalc == value;
    }
}
