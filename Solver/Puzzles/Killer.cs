using Solver.Constraints;
using System.Collections.Generic;

namespace Solver.Puzzles
{
    /// <summary>
    /// A sudoku with added constraints that every cell is in a block and the blocks must add up to a given sum
    /// and not contain duplicate individual values.  Blocks can be created with the AddBlock method.
    /// https://en.wikipedia.org/wiki/Killer_sudoku
    /// </summary>
    public class Killer : Puzzle
    {
        public Killer()
        {
            GridSize = 9;
            MaxValue = 9;
            Values = new int[GridSize, GridSize];
            Constraints.Add(new RowConstraint());
            Constraints.Add(new ColumnConstraint());
            Constraints.Add(new SquareBlockConstraint(3));
        }

        /// <summary>
        /// Adds a block definition into the Killer
        /// </summary>
        /// <param name="cells">Integer array of cell coordinates in the block: [x1, y1, x2, y2, ...]</param>
        /// <param name="sum">Integer value the block adds up to</param>
        /// <returns>This puzzle so we can use fluent programming</returns>
        public Killer AddBlock(int[] cells, int sum)
        {
            Constraints.Add(new BlockSumNoDuplicatesConstraint(cells, sum));
            return this;
        }

        public override void Solve()
        {
            CheckSetUp();
            base.Solve();
        }

        // It's very easy to get the setup of a Killer wrong and then it usually won't give any useful info about why
        // it won't solve.  We can at least check that every cell in the grid appears in one and only one block.
        private void CheckSetUp()
        {
            HashSet<int> blockCells = new HashSet<int>();
            foreach (Constraint item in Constraints)
            {
                if (item is BlockSumNoDuplicatesConstraint constraint)
                {
                    for (int i = 0; i < constraint.Cells.Length; i += 2)
                    {
                        int index = constraint.Cells[i + 1] * GridSize + constraint.Cells[i];
                        if (blockCells.Contains(index))
                            throw new System.Exception($"Cell [{constraint.Cells[i]}, {constraint.Cells[i + 1]}] appears twice in the block definitions");
                        blockCells.Add(index);
                    }
                }
            }
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    if (!blockCells.Contains(y * GridSize + x))
                        throw new System.Exception($"Cell [{x}, {y}] does not appear in the block definitions");
                }
            }
        }
    }
}
