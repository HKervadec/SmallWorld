using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Coord
    {
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    
        public int x
        {
            get
            {
                return this.x;
            }
            set
            {
            }
        }

        public int y
        {
            get
            {
                return this.y;
            }
            set
            {
            }
        }

        public Boolean NextTo(Coord b)
        {
            return Math.Abs(this.x - b.x) + Math.Abs(this.y - b.y) == 2;
        }
    }
}
