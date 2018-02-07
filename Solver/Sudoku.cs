namespace Solver
{
    public class Sudoku : Puzzle
    {
        public Sudoku()
        {
            GridSize = 9;
            MaxValue = 9;
            Values = new int[GridSize, GridSize];
            Criteria.Add(new RowCriterion());
            Criteria.Add(new ColumnCriterion());
            Criteria.Add(new SquareBlockCriterion(3));
        }
    }
}
