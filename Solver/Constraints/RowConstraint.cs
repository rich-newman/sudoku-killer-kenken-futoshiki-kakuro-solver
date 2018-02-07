using Solver.Puzzles;
using System.Collections.Generic;

namespace Solver.Constraints
{
    public class RowConstraint : Constraint
    {
        private HashSet<int> hashSet = new HashSet<int>();
        public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
        {
            //if (xCoord > 0) return true;
            hashSet.Clear();
            for (int x = 0; x < puzzle.GridSize; x++)
            {
                if (puzzle.Values[x, yCoord] < 1) continue;
                if (hashSet.Contains(puzzle.Values[x, yCoord])) return false;
                hashSet.Add(puzzle.Values[x, yCoord]);
            }
            return true;
        }
    }
}
