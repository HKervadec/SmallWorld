using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Elf : Unit
    {
        public Elf(Coord pos, int id) 
            : base(pos, id)
        {
            favorite_type = TileType.Forest;
        }
    }
}
