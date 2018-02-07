namespace Solver
{
    public abstract class Criterion
    {
        public abstract bool Evaluate(Puzzle puzzle, int xCoord, int yCoord);
    }
}
