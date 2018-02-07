using Solver.Puzzles;
using System.Collections.Generic;

namespace Solver.Constraints
{
    public class SquareBlockConstraint : Constraint
    {
        private int blockSize;
        public SquareBlockConstraint(int blockSize) { this.blockSize = blockSize; }
        private HashSet<int> hashSet = new HashSet<int>();
        public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
        {
            hashSet.Clear();
            int xLower = (xCoord / blockSize) * 3;
            //if (xLower != xCoord) return true;
            int xUpper = xLower + 3;
            int yLower = (yCoord / blockSize) * 3;
            //if (yLower != yCoord) return true;
            int yUpper = yLower + 3;
            for (int y = yLower; y < yUpper; y++)
            {
                for (int x = xLower; x < xUpper; x++)
                {
                    if (puzzle.Values[x, y] < 1) continue;
                    if (hashSet.Contains(puzzle.Values[x, y])) return false;
                    hashSet.Add(puzzle.Values[x, y]);
                }
            }
            return true;
        }
    }
}
