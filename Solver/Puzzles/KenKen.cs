using Solver.Constraints;

namespace Solver.Puzzles
{
    public enum Operator
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    /// <summary>
    /// 6x6 grid (here) where every row and column must contain each of values 1-6 and additionally blocks are 
    /// defined with an arithmetic operation (+ - / +) and a total value.  The total value must be the result
    /// of applying the arithmetic operation to the values in individual cells in the block.
    /// Blocks can be created to set the puzzle up with the AddBlock method.
    /// https://en.wikipedia.org/wiki/KenKen
    /// </summary>
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

        /// <summary>
        /// Adds a block definition into the KenKen
        /// </summary>
        /// <param name="cells">Integer array of cell coordinates in the block: [x1, y1, x2, y2, ...]</param>
        /// <param name="value">Integer total value for the cell values in the block</param>
        /// <param name="operator">Operator to be applied to cell values in the block to get the total value</param>
        /// <returns>This puzzle so we can use fluent programming</returns>
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
