namespace Solver
{
    public class Futoshiki : Puzzle
    {
        public Futoshiki()
        {
            GridSize = 5;
            MaxValue = 5;
            Values = new int[GridSize, GridSize];
            Criteria.Add(new RowCriterion());
            Criteria.Add(new ColumnCriterion());
        }

        public Futoshiki AddGreaterThanCriterion(int x, int y, int ox, int oy)
        {
            Criteria.Add(new GreaterThanCriterion(x, y, ox, oy));
            return this;
        }
    }
}
