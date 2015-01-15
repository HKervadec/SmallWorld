using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class StrategyNewGameBuilder : GameBuilderStrategy
    {
        public static Game buildGame(MapSize ms, List<String> playersName, List<Race> playersRace)
        {
            if(playersName.Count() != playersRace.Count())
            {
                throw new System.Exception("Players size does not match races size");
            }

            int n = playersName.Count();
            Player[] players = new Player[n];

            Map map = new Map(ms);

            for(int i = 0 ; i < n ; i++) {
                players[i] = new Player(playersName[i],
                    playersRace[i],
                    ms,
                    map.getPlayerInitPos(),
                    i);

                foreach(Unit u in players[i].Army) {
                    Coord test = u.Pos;
                    int x = u.Pos.X;
                    int y = u.Pos.Y;

                    map.getTile(x, y).CurrentUnit = u;
                }
            }


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
