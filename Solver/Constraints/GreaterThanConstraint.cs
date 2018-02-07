using Solver.Puzzles;

namespace Solver.Constraints
{
    // Value at [x,y] must be greater than value at [ox,oy]
    public class GreaterThanConstraint : Constraint
    {
        private int x;
        private int y;
        private int ox;
        private int oy;
        public GreaterThanConstraint(int x, int y, int ox, int oy) { this.x = x; this.y = y; this.ox = ox; this.oy = oy; }
        public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
        {
            if((xCoord == x && yCoord == y) || (xCoord == ox && yCoord == oy))
            {
                int value = puzzle.Values[x, y];
                int oValue = puzzle.Values[ox, oy];
                if (value > 0 && oValue > 0 && value < oValue) return false;
            }
            return true;
        }
    }
}
