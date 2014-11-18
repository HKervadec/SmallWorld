using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class GameBuilderStrategy
    {
        public Game buildGame(MapSize ms, List<String> playersName)
        {
            throw new System.NotImplementedException();
        }

        public Game buildGame(int slotId)
        {
            throw new System.NotImplementedException();
        }

        public void buildMap(MapSize ms)
        {
            throw new System.NotImplementedException();
        }

        public void createPlayer(String playerName)
        {
            throw new System.NotImplementedException();
        }
    }
}
