using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class BlockSumCriterion : Criterion
    {
        private int[] cells;
        private int sum;
        public BlockSumCriterion(int[] cells, int sum) { this.cells = cells; this.sum = sum; }
        public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
        {
            for (int i = 0; i < cells.Length; i+=2)
            {
                if(cells[i] == xCoord && cells[i+1] == yCoord)
                {
                    int localSum = 0;
                    HashSet<int> valuesSeen = new HashSet<int>();
                    bool emptyValue = false; // We need to check for dupes even if all cells aren't populated
                    for (int j = 0; j < cells.Length; j += 2)
                    {
                        int value = puzzle.Values[cells[j], cells[j + 1]];
                        if (value == 0)
                        {
                            emptyValue = true;
                            continue;
                        }
                        localSum += value;
                        if (valuesSeen.Contains(value)) return false;
                        valuesSeen.Add(value);
                    }
                    if (emptyValue) return true;
                    return localSum == sum;
                }
            }
            return true;
        }
    }
}
