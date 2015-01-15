using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Tile
    {
        private TileType type;
        private Coord address;
        private int textureId;
        private Unit currentUnit;

        public Tile(TileType t, Coord address, int tid) {
            this.type = t;
            this.address = address.clone();
            this.textureId = tid;

            this.currentUnit = null;
        }


        public TileType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public int TextureId
        {
            get
            {
                return this.textureId;
            }
            set
            {
            }
        }

        public Coord Address
        {
            get
            {
                return this.address;
            }
            set
            {
            }
        }

        public Unit CurrentUnit
        {
            get
            {
                return this.currentUnit;
            }
            set
            {
                this.currentUnit = value;
            }
        }
    }
}
