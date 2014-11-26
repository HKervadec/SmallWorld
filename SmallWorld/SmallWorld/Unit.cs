using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class Unit
    {
        public static int max_life = 5;
        public static int max_movevement = 2;
        public static int default_mov_cost = 2;

        public Unit(Coord pos)
        {
            this.lifePoints = Unit.max_life;
            this.resetMov();
            this.state = UnitState.Defend;
            this.pos = pos;
        }

        public int lifePoints
        {
            get
            {
                return this.lifePoints;
            }
            set
            {
                this.lifePoints = Math.Max(Unit.max_life, value);
            }
        }

        public int movementPoints
        {
            get
            {
                return this.movementPoints;
            }
            set
            {
                this.movementPoints = Math.Max(Unit.max_movevement, value);
            }
        }

        public Coord pos
        {
            get
            {
                return this.pos;
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
            this.lifePoints = Math.Max(0, this.lifePoints - dmg);

            if (this.lifePoints == 0)
            {
                this.kill();
            }
        }

        public void kill()
        {
            this.state = UnitState.Dead;
        }

        public void resetMov()
        {
            this.movementPoints = Unit.max_movevement;
        }

        public void defend()
        {
            throw new System.NotImplementedException();
        }

        public void move(Tile dest)
        {
            int cost = movement_cost(dest);

            if (cost <= this.movementPoints)
            {
                this.pos = dest.address;
                this.movementPoints -= cost;
            }
        }

        public static int movement_cost(Tile dest)
        {
            throw new System.NotImplementedException();
        }
    }
}
