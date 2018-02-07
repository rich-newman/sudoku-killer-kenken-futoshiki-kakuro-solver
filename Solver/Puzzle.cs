using System.Collections.Generic;

namespace Solver
{
    public class Puzzle
    {
        public int GridSize;
        public int MaxValue;
        public int[,] Values;
        public List<Criterion> Criteria = new List<Criterion>();
        //public void AddCriterion(Criterion criterion) => criteria.Add(criterion);
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

        public void Solve() => Solver.Solve();

    }
}
