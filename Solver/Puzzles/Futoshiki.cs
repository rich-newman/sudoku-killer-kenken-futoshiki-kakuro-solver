using Solver.Constraints;

namespace Solver.Puzzles
{
    /// <summary>
    /// 5x5 grid where every row and column must contain each of values 1-5 and additionally constraints are placed
    /// on pairs of cells such that the value in one cell must be greater than the value in the other.
    /// https://en.wikipedia.org/wiki/Futoshiki
    /// </summary>
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
        /// <summary>
        /// Adds a greater than constraint where the value in cell [x,y] must be greater than the value in cell [ox,oy]
        /// </summary>
        /// <param name="x">x-coordinate of value on left of greater than sign (the bigger value)</param>
        /// <param name="y">-coordinate of value on left of greater than sign (the bigger value)</param>
        /// <param name="ox">x-coordinate of value on right of greater than sign (the smaller value)</param>
        /// <param name="oy">y-coordinate of value on right of greater than sign (the smaller value)</param>
        /// <returns>This puzzle so we can use fluent programming</returns>
        public Futoshiki AddGreaterThan(int x, int y, int ox, int oy)
        {
            Constraints.Add(new GreaterThanConstraint(x, y, ox, oy));
            return this;
        }
    }
}
