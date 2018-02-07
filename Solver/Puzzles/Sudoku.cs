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
            Constraints.Add(new RowConstraint());
            Constraints.Add(new ColumnConstraint());
            Constraints.Add(new SquareBlockConstraint(3));
        }
    }
}
