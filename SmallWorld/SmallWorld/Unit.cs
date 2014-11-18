using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class Unit
    {

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

        public int movementPoints
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

        public UnitState state
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

        public void defend()
        {
            throw new System.NotImplementedException();
        }

        public void move(Coord dest)
        {
            throw new System.NotImplementedException();
        }
    }
}
