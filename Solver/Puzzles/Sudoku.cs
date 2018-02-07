using Solver.Constraints;

namespace Solver.Puzzles
{
    public class Sudoku : Puzzle
    {
        public Sudoku()
        {
            GridSize = 9;
            MaxValue = 9;
            Values = new int[GridSize, GridSize];
            Criteria.Add(new RowConstraint());
            Criteria.Add(new ColumnConstraint());
            Criteria.Add(new SquareBlockConstraint(3));
        }
    }
}
