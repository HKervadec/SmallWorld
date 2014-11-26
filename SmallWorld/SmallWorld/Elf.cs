using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Elf : Unit
    {
        public Elf(Coord pos) 
            : base(pos)
        {

        }

        new static int movement_cost(Tile dest)
        {
            if (dest.type != TileType.Forest)
            {
                return Unit.default_mov_cost;
            }

            return Unit.default_mov_cost / 2;
        }
    }
}
