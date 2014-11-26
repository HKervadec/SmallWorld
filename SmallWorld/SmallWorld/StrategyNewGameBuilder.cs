using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class StrategyNewGameBuilder : GameBuilderStrategy
    {
        new public static Game buildGame(MapSize ms, String[] playersName, Race[] playersRace)
        {
            if (playersName.Length != playersRace.Length)
            {
                throw new System.Exception("Players size does not match races size");
            }


            Player[] players = new Player[playersName.Length];
            int army_size = GetArmySize(ms);

            for (int i = 0; i < playersName.Length; i++)
            {
                players[i] = new Player(playersName[i], playersRace[i], i, army_size);
            }


            Map map = buildMap(ms);

            return new Game(players, map);
        }

        private static int GetArmySize(MapSize ms)
        {
            switch (ms)
            {
                case MapSize.SMALL:
                    return 2;
                case MapSize.NORMAL:
                    return 4;
                case MapSize.HUGE:
                    return 8;
            }

            return 1;
        }
    }
}
