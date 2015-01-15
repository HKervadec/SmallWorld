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
        private Game currentGame;
        public static Random rng = new Random(); 

        public GameManager()
        {
            this.players_name = new List<string>();
            //this.players_name.Add("Ratus");
            //this.players_name.Add("Narouteau");

            this.players_race = new List<Race>();
            //this.players_race.Add(Race.Dwarfs);
            //this.players_race.Add(Race.Elfs);

            this.ms = MapSize.HUGE;
        }

        public void launchGame() {
            this.CurrentGame = StrategyNewGameBuilder.buildGame(this.ms, this.players_name, this.players_race);
        }

        public Game CurrentGame
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

        public MapSize MS {
            get {
                return this.ms;
            }
            set {
                this.ms = value;
            }
        }

        public void addRace(Race r) {
            this.players_race.Add(r);
        }

        public void addName(String n) {
            this.players_name.Add(n);
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
