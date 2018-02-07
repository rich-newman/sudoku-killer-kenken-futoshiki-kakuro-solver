using System.Collections.Generic;

namespace Solver
{
    public class Killer : Puzzle
    {
        public Killer()
        {
            GridSize = 9;
            MaxValue = 9;
            Values = new int[GridSize, GridSize];
            Criteria.Add(new RowCriterion());
            Criteria.Add(new ColumnCriterion());
            Criteria.Add(new SquareBlockCriterion(3));
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
            Criteria.Add(new BlockSumCriterion(cells, sum));

            return this;
        }
    }
}
