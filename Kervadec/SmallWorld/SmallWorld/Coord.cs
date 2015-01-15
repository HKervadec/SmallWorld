using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Coord
    {
        private int x;
        private int y;

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coord clone() {
            return new Coord(this.x, this.y);
        }

        public Coord() : this(0, 0)
        {
        }
    
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public Boolean NextTo(Coord b)
        {
            return Math.Abs(this.X - b.X) + Math.Abs(this.Y - b.Y) == 2;
        }
    }
}
