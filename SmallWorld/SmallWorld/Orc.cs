﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Orc : Unit
    {
        public Orc(Coord pos)
            : base(pos)
        {

        }
        new public static int movement_cost(Tile dest)
        {
            if (dest.type != TileType.Desert)
            {
                return Unit.default_mov_cost;
            }

            return Unit.default_mov_cost / 2;
        }
    }
}
