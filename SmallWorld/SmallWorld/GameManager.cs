using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class GameManager
    {
        private List<String> players_name;
        private List<Race> players_race;
        private MapSize ms;

        public GameManager()
        {
            throw new System.NotImplementedException();
        }

        public Game currentGame
        {
            get
            {
                return this.currentGame;
            }
            set
            {
                this.currentGame = value;
            }
        }

        public void launchGame()
        {
            this.currentGame = StrategyNewGameBuilder.buildGame(ms, players_name.ToArray(), players_race.ToArray());
        }

        public void loadGame()
        {
            throw new System.NotImplementedException();
        }

        public void setupGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
