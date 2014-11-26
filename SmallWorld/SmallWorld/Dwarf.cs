using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Dwarf : Unit
    {
        public Dwarf(Coord pos) :
            base(pos)
        {
        }

        new public static int movement_cost(Tile dest)
        {
            if (dest.type != TileType.Moutain)
            {
                return Unit.default_mov_cost;
            }

            return Unit.default_mov_cost / 2;
        }
    }
}
