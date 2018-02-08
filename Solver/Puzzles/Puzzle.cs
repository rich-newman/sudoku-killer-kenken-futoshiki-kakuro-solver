using Solver.Constraints;
using System.Collections.Generic;

namespace Solver.Puzzles
{
    /// <summary>
    /// The base class for all the puzzle types
    /// </summary>
    public class Puzzle
    {
        public int GridSize;
        public int MaxValue;
        public int[,] Values; // Integer array [x-coord, y-coord]=value containing values currently in the grid
        public List<Constraint> Constraints = new List<Constraint>();
        public Puzzle SetValue(int xCoord, int yCoord, int value)
        {
            Values[xCoord, yCoord] = value;
            return this;
        }

        private Solver solver;
        public Solver Solver
        {
            get
            {
                if (solver == null) solver = new Solver(this);
                return solver;
            }
        }

        public virtual void Solve() => Solver.Solve();

    }
}
