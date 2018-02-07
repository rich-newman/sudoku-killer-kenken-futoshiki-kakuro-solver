using Solver.Puzzles;
using System.Collections.Generic;

namespace Solver.Constraints
{
    // Killer: 'Each set of cells must add up to the target number.  Within each set of cells a digit can't be repeated.'
    // Kakuro has the same constraint, except that the cells are always in a line, not an arbitrarily-shaped block
    // We model this in the Kakuro puzzle class rather than creating a new constraint
    public class BlockSumNoDuplicatesConstraint : Constraint
    {
        private int[] cells;
        public int[] Cells => cells;
        private int sum;
        public BlockSumNoDuplicatesConstraint(int[] cells, int sum) { this.cells = cells; this.sum = sum; }
        public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
        {
            for (int i = 0; i < cells.Length; i+=2)
            {
                if(cells[i] == xCoord && cells[i+1] == yCoord)
                {
                    int localSum = 0;
                    HashSet<int> valuesSeen = new HashSet<int>();
                    bool emptyValue = false; // We need to check for dupes even if all cells aren't populated
                    for (int j = 0; j < cells.Length; j += 2)
                    {
                        int value = puzzle.Values[cells[j], cells[j + 1]];
                        if (value == 0)
                        {
                            emptyValue = true;
                            continue;
                        }
                        localSum += value;
                        if (valuesSeen.Contains(value)) return false;
                        valuesSeen.Add(value);
                    }
                    if (emptyValue) return true;
                    return localSum == sum;
                }
            }
            return true;
        }
    }
}
