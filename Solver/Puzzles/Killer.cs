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
            Criteria.Add(new RowConstraint());
            Criteria.Add(new ColumnConstraint());
            Criteria.Add(new SquareBlockConstraint(3));
        }

        public Killer AddBlockSumCriterion(int[] cells, int sum)
        {
            //List<Criterion> newList = new List<Criterion>();
            //newList.Add(new BlockSumCriterion(cells, sum));
            //foreach (Criterion criterion in Criteria)
            //{
            //    newList.Add(criterion);
            //}
            //Criteria = newList;
            Criteria.Add(new BlockSumConstraint(cells, sum));

            return this;
        }
    }
}
