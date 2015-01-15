using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Dwarf : Unit
    {
        public Dwarf(Coord pos, int id) :
            base(pos, id)
        {
            favorite_type = TileType.Moutain;
        }

        public override bool Move(Tile dest, Map map) {
            if(!base.Move(dest, map)) {
                if(map.getType(Pos) == TileType.Moutain &&
                    dest.Type == TileType.Moutain) {
                    this.pos = dest.Address;
                    this.movementPoints = 0;

                    return true;
                }

                return false;
            }

            return true;
        }
    }
}
