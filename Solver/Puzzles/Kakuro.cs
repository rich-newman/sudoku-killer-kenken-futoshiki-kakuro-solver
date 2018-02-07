using Solver.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Puzzles
{
    public class Kakuro: Puzzle
    {
        public Kakuro()
        {
            GridSize = 10;
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
                if (item is BlockSumConstraint constraint)
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
                    // We use 0 for an empty cell and -1 for cells that can't take a value
                    if (!blockCells.Contains(y * GridSize + x))
                        SetValue(x, y, -1);
                }
            }
        }

        public Kakuro AddHorizontalBlockSumConstraint(int xCoordLower, int xCoordUpper, int yCoord, int sum)
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
            Constraints.Add(new BlockSumConstraint(cells, sum));
            return this;
        }

        public Kakuro AddVerticalBlockSumConstraint(int xCoord, int yCoordLower, int yCoordUpper, int sum)
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
            Constraints.Add(new BlockSumConstraint(cells, sum));
            return this;
        }
    }
}
