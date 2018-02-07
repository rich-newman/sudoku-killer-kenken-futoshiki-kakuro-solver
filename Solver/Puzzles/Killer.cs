using Solver.Constraints;
using System.Collections.Generic;

namespace Solver.Puzzles
{
    public class Killer : Puzzle
    {
        public Killer()
        {
            GridSize = 9;
            MaxValue = 9;
            Values = new int[GridSize, GridSize];
            Constraints.Add(new RowConstraint());
            Constraints.Add(new ColumnConstraint());
            Constraints.Add(new SquareBlockConstraint(3));
        }

        public Killer AddBlock(int[] cells, int sum)
        {
            Constraints.Add(new BlockSumNoDuplicatesConstraint(cells, sum));
            return this;
        }
    }
}
