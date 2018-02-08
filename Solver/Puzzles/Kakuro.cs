using Solver.Constraints;
using System.Collections.Generic;

namespace Solver.Puzzles
{
    /// <summary>
    /// A puzzle on a grid of any size.  The grid has some cells filled in (unavailable) and some cells empty.
    /// The empty cells form horizontal and vertical blocks, and must be filled with the values 1-9 such that the blocks 
    /// sum to specified values.  One block cannot contain the same value twice.
    /// https://en.wikipedia.org/wiki/Kakuro
    /// </summary>
    public class Kakuro: Puzzle
    {
        public Kakuro(int gridSize)
        {
            GridSize = gridSize;
            MaxValue = 9;
            Values = new int[GridSize, GridSize];
        }

        public override void Solve()
        {
            SetAllFilledInCells();
            base.Solve();
        }

        private void SetAllFilledInCells()
        {
            HashSet<int> blockCells = new HashSet<int>();
            foreach (Constraint item in Constraints)
            {
                if (item is BlockSumNoDuplicatesConstraint constraint)
                {
                    for (int i = 0; i < constraint.Cells.Length; i += 2)
                    {
                        int index = constraint.Cells[i + 1] * GridSize + constraint.Cells[i];  // 0 -> 99
                        if (!blockCells.Contains(index)) blockCells.Add(index);
                    }
                }
            }
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    // We use 0 for an empty cell and -1 for cells that can't take a value (= are filled in)
                    if (!blockCells.Contains(y * GridSize + x))
                        SetValue(x, y, -1);
                }
            }
        }

        /// <summary>
        /// Adds a Kakuro block in a column
        /// </summary>
        /// <param name="xCoordLower">Lower x-coordinate of the block</param>
        /// <param name="xCoordUpper">Upper x-coordinate of the block</param>
        /// <param name="yCoord">y-coordinate of the column the block is in</param>
        /// <param name="sum">Sum of the values in the block</param>
        /// <returns>This puzzle so we can use fluent programming</returns>
        public Kakuro AddHorizontalBlock(int xCoordLower, int xCoordUpper, int yCoord, int sum)
        {
            // If our block goes from, say, [3,3] to [6,3] we want to create a cells array with
            // cells[0]=3,cells[1]=3; cells[2]=4,cells[3]=3; cells[4]=5,cells[5]=3; cells[6]=6,cells[7]=3;
            int numberOfCells = 1 + xCoordUpper - xCoordLower;
            int[] cells = new int[numberOfCells * 2];
            for (int i = 0; i < numberOfCells; i++)
            {
                cells[i * 2] = xCoordLower + i;
                cells[i * 2 + 1] = yCoord;
            }
            Constraints.Add(new BlockSumNoDuplicatesConstraint(cells, sum));
            return this;
        }

        /// <summary>
        /// Adds a Kakuro block in a row
        /// </summary>
        /// <param name="xCoord">x-coordinate of the row the block is in</param>
        /// <param name="yCoordLower">Lower y-coordinate of the block</param>
        /// <param name="yCoordUpper">Upper y-coordinate of the block</param>
        /// <param name="sum">Sum of the values in the block</param>
        /// <returns>This puzzle so we can use fluent programming</returns>
        public Kakuro AddVerticalBlock(int xCoord, int yCoordLower, int yCoordUpper, int sum)
        {
            // If our block goes from, say, [8,6] to [8,9] we want to create a cells array with
            // cells[0]=8,cells[1]=6; cells[2]=8,cells[3]=7; cells[4]=8,cells[5]=8; cells[6]=8,cells[7]=9;
            int numberOfCells = 1 + yCoordUpper - yCoordLower;
            int[] cells = new int[numberOfCells * 2];
            for (int i = 0; i < numberOfCells; i++)
            {
                cells[i * 2] = xCoord;
                cells[i * 2 + 1] = yCoordLower + i;
            }
            Constraints.Add(new BlockSumNoDuplicatesConstraint(cells, sum));
            return this;
        }
    }
}
