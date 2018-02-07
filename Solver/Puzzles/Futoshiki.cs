using Solver.Constraints;

namespace Solver.Puzzles
{
    public class Futoshiki : Puzzle
    {
        public Futoshiki()
        {
            GridSize = 5;
            MaxValue = 5;
            Values = new int[GridSize, GridSize];
            Criteria.Add(new RowConstraint());
            Criteria.Add(new ColumnConstraint());
        }

        public Futoshiki AddGreaterThanCriterion(int x, int y, int ox, int oy)
        {
            Criteria.Add(new GreaterThanConstraint(x, y, ox, oy));
            return this;
        }
    }
}
