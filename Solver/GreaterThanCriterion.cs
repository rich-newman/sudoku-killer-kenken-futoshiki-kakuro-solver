using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    // Value at [x,y] must be greater than value at [ox,oy]
    public class GreaterThanCriterion : Criterion
    {
        //List<int[]> greaterThans = new List<int[]>();
        //public void AddGreaterThan(int x, int y, int ox, int oy)
        //{
        //    int[] greaterThan = new int[] { x, y, ox, oy };
        //    greaterThans.Add(greaterThan);
        //}
        private int x;
        private int y;
        private int ox;
        private int oy;
        public GreaterThanCriterion(int x, int y, int ox, int oy) { this.x = x; this.y = y; this.ox = ox; this.oy = oy; }
        public override bool Evaluate(Puzzle puzzle, int xCoord, int yCoord)
        {
            if(xCoord == x && yCoord == y)
            {
                int value = puzzle.Values[x, y];
                int oValue = puzzle.Values[ox, oy];
                if (value > 0 && oValue > 0 && value < oValue) return false;
            }
            return true;
        }
    }
}
