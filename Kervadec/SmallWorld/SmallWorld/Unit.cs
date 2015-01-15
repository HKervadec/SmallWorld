using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SmallWorld
{
    public abstract class Unit
    {
        protected int lifePoints;
        protected int movementPoints;
        protected Coord pos;
        protected UnitState state;

        protected TileType favorite_type;

        protected int ownerId;

        public static int max_life = 5;
        public static int max_movevement = 4;
        public static int default_mov_cost = 2;

        public Unit(Coord pos, int ownerId)
        {
            this.lifePoints = Unit.max_life;
            this.ResetMov();
            this.State = UnitState.Defend;
            this.pos = pos;

            this.ownerId = ownerId;

        }

        public int LifePoints
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

        public TileType FavoriteType {
            get {
                return this.favorite_type;
            }
            set {
            }
        }

        public int MovementPoints
        {
            get
            {
                return this.movementPoints;
            }
            set
            {
                this.movementPoints = value;
            }
        }

        public Coord Pos
        {
            get
            {
                return this.pos;
            }
            set
            {
                this.pos = value;
            }
        }

        public UnitState State
        {
            get
            {
                return this.state;
            }
            set
            {
            }
        }

        public int OwnerId {
            get {
                return this.ownerId;
            }
            set {
            }
        }

        public void Hurt(int dmg)
        {
            this.LifePoints = Math.Max(0, this.LifePoints - dmg);

            if(this.LifePoints == 0){
                this.Kill();
            }
        }

        public void Kill()
        {
            this.State = UnitState.Dead;
        }

        public void ResetMov()
        {
            this.movementPoints = Unit.max_movevement;
        }

        public void Defend()
        {
            throw new System.NotImplementedException();
        }

        public virtual bool Move(Tile dest, Map map)
        {
            int cost = movement_cost(dest);

            if (dest.Address.NextTo(Pos) &&
                cost <= this.MovementPoints)
            {
                this.pos = dest.Address;
                this.movementPoints -= cost;

                return true;
            }

            return false;
        }

        public int movement_cost(Tile dest)
        {
            if(dest.Type != favorite_type) {
                return Unit.default_mov_cost;
            }

            return Unit.default_mov_cost / 2;
        }
    }
}
