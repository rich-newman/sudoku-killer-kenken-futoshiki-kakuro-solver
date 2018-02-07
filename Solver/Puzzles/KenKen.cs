using Solver.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Puzzles
{
    public enum Operator
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
    public class KenKen : Puzzle
    {
        public KenKen()
        {
            GridSize = 6;
            MaxValue = 6;
            Constraints.Add(new RowConstraint());
            Constraints.Add(new ColumnConstraint());
            Values = new int[GridSize, GridSize];
        }

        public KenKen AddBlock(int [] cells, int value, Operator @operator)
        {
            switch (@operator)
            {
                case Operator.Add:
                    Constraints.Add(new BlockAddConstraint(cells, value));
                    break;
                case Operator.Subtract:
                    Constraints.Add(new BlockSubtractConstraint(cells, value));
                    break;
                case Operator.Multiply:
                    Constraints.Add(new BlockMultiplyConstraint(cells, value));
                    break;
                case Operator.Divide:
                    Constraints.Add(new BlockDivideConstraint(cells, value));
                    break;
                default:
                    break;
            }
            return this;
        }
    }
}
