using Solver.Constraints;

namespace Solver.Puzzles
{
    /// <summary>
    /// The grandaddy of these puzzles: 9x9 grid where every row, column and 3x3 block must contain each of the values 1-9
    /// For a given puzzle some values are given to you to get you going: these can be set up using SetValue
    /// https://en.wikipedia.org/wiki/Sudoku
    /// </summary>
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
