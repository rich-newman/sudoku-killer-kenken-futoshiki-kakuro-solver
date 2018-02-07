using Solver.Puzzles;
using System.Collections.Generic;

namespace Solver.Constraints
{
    public class ColumnConstraint : Constraint
    {
        private HashSet<int> hashSet = new HashSet<int>();
        public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
        {
            //if (yCoord > 0) return true;
            hashSet.Clear();
            for (int y = 0; y < puzzle.GridSize; y++)
            {
                if (puzzle.Values[xCoord, y] < 1) continue;
                if (hashSet.Contains(puzzle.Values[xCoord, y])) return false;
                hashSet.Add(puzzle.Values[xCoord, y]);
            }
            return true;
        }
    }
}
