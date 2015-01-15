using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Player
    {

        private int img;
        private List<Unit> army;
        private String name;
        private Race race;
        public int id;
        private int score;

        public Player(String name, Race r, MapSize ms, Coord initPos, int id)
        {
            this.race = r;
            this.name = name;
            this.id = id;
            this.score = 0;

            this.createArmy(this.armyInitialSize(ms), initPos);
        }

        private int armyInitialSize(MapSize ms) {
            switch(ms) {
                case MapSize.SMALL:
                    return 2;
                case MapSize.NORMAL:
                    return 4;
                case MapSize.HUGE:
                    return 6;
            }

            return 0;
        }
    

        public int Img
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Unit> Army
        {
            get
            {
                return this.army;
            }
            set
            {
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
            }
        }

        public Race Race
        {
            get
            {
                return this.race;
            }
            set
            {
            }
        }

        public int Score {
            get {
                return this.score;
            }
            set {
                this.score = value;
            }
        }

        public void generateImg()
        {
            throw new System.NotImplementedException();
        }

        public void createArmy(int max_unit, Coord initPos)
        {
            this.army = new List<Unit>();

            this.army.Add(UnitFactory.createUnit(this.race, new Coord(initPos.X - 2, initPos.Y), id));
            this.army.Add(UnitFactory.createUnit(this.race, new Coord(initPos.X + 2, initPos.Y), id));
            if(this.army.Count() >= max_unit) { return;}

            this.army.Add(UnitFactory.createUnit(this.race, new Coord(initPos.X - 1, initPos.Y - 1), id));
            this.army.Add(UnitFactory.createUnit(this.race, new Coord(initPos.X + 1, initPos.Y - 1), id));
            if(this.army.Count() >= max_unit) { return; }

            this.army.Add(UnitFactory.createUnit(this.race, new Coord(initPos.X - 1, initPos.Y + 1), id));
            this.army.Add(UnitFactory.createUnit(this.race, new Coord(initPos.X + 1, initPos.Y + 1), id));
            if(this.army.Count() >= max_unit) { return; }
        }

        public void killUnit(Unit u) {
            this.Army.Remove(u);
        }
    }
}
