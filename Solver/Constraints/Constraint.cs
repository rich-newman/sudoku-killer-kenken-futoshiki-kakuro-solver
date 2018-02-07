using Solver.Puzzles;

namespace Solver.Constraints
{
    public abstract class Constraint
    {
        public abstract bool Evaluate(Puzzle puzzle, int xCoord, int yCoord);
    }
}
