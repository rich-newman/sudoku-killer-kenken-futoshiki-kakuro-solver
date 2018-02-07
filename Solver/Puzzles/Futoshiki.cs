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
            Constraints.Add(new RowConstraint());
            Constraints.Add(new ColumnConstraint());
        }

        public Futoshiki AddGreaterThanConstraint(int x, int y, int ox, int oy)
        {
            Constraints.Add(new GreaterThanConstraint(x, y, ox, oy));
            return this;
        }
    }
}
