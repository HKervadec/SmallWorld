using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Map
    {
        public Tile[][] world
        {
            get
            {
                return this.world;
            }
            set
            {
            }
        }

        public Tile getTile(int x, int y)
        {
            return this.world[x][y / 2];
        }

        public void setTile(Tile t)
        {
            int x = t.address.x;
            int y = t.address.y;

            this.world[x][y / 2] = t;
        }

        public TileType getType(Coord address)
        {
            throw new System.NotImplementedException();
        }
    }


}
