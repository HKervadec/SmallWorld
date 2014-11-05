using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class Unit
    {
        public Boolean alive
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Player owner
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int life
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int mov
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Coord pos
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void hurt(int dmg)
        {
            throw new System.NotImplementedException();
        }

        public void kill()
        {
            throw new System.NotImplementedException();
        }

        public void resetMov()
        {
            throw new System.NotImplementedException();
        }
    }
}
