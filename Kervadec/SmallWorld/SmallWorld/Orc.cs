using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Orc : Unit
    {
        public Orc(Coord pos, int id)
            : base(pos, id)
        {
            favorite_type = TileType.Desert;
        }
    }
}
