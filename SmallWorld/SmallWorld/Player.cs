using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Player
    {
    
        public Player(String name, Race r, int c, int max_unit)
        {
            this.color = c;
            this.race = r;
            this.name = name;

            this.createArmy(max_unit);
        }
    
        public int color
        {
            get
            {
                return this.color;
            }
            set
            {
            }
        }

        public int img
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Unit> army
        {
            get
            {
                return this.army;
            }
            set
            {
            }
        }

        public String name
        {
            get
            {
                return this.name;
            }
            set
            {
            }
        }

        public Race race
        {
            get
            {
                return this.race;
            }
            set
            {
            }
        }

        public void generateImg()
        {
            throw new System.NotImplementedException();
        }

        public void createArmy(int max_unit)
        {
            for (int i = 0; i < max_unit; i++)
            {
                this.army.Add(UnitFactory.createUnit(this.race, new Coord(-1,-1)));
            }
        }
    }
}
