using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class UnitFactory
    {
        public static Unit createUnit(Race race, Coord pos, int id)
        {
            switch (race)
            {
                case Race.Dwarfs:
                    return createDwarf(pos, id);
                case Race.Elfs:
                    return createElf(pos, id);
                case Race.Orcs:
                    return createOrc(pos, id);
            }

            throw new System.Exception("Unknown race: " + race);
        }
        public static Dwarf createDwarf(Coord pos, int id)
        {
            return new Dwarf(pos, id);
        }
        public static Orc createOrc(Coord pos, int id)
        {
            return new Orc(pos, id);
        }
        public static Elf createElf(Coord pos, int id)
        {
            return new Elf(pos, id);
        }
    }
}
