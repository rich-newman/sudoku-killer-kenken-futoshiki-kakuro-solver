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

        public Killer AddBlockSumConstraint(int[] cells, int sum)
        {
            //List<Constraint> newList = new List<Constraint>();
            //newList.Add(new BlockSumConstraint(cells, sum));
            //foreach (Constraint constraint in Constraints)
            //{
            //    newList.Add(constraint);
            //}
            //Constraints = newList;
            Constraints.Add(new BlockSumConstraint(cells, sum));

            return this;
        }
    }
}
