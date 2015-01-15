using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class GameBuilderStrategy
    {
        public static Game buildGame(MapSize ms, String[] playersName, Race[] playersRace)
        {
            throw new System.NotImplementedException();
        }

        public static Game buildGame(int slotId)
        {
            throw new System.NotImplementedException();
        }

        public static Map buildMap(MapSize ms)
        {
            throw new System.NotImplementedException();
        }

        public static void createPlayer(String playerName)
        {
            throw new System.NotImplementedException();
        }
    }
}
