using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class UnitFactory
    {
        public static Unit createUnit(Race race, Coord pos)
        {
            switch (race)
            {
                case Race.Dwarfs:
                    return createDwarf(pos);
                case Race.Elfs:
                    return createElf(pos);
                case Race.Orcs:
                    return createElf(pos);
            }

            throw new System.Exception("Unknown race: " + race);
        }
        public static Dwarf createDwarf(Coord pos)
        {
            return new Dwarf(pos);
        }
        public static  Orc createOrc(Coord pos)
        {
            return new Orc(pos);
        }
        public static Elf createElf(Coord pos)
        {
            return new Elf(pos);
        }
    }
}
