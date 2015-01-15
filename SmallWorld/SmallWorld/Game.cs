using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Game
    {
        private Player[] players;
        private int currentPlayerId;
        private int currentTurn;
        private Map map;
        private Unit selectedUnit;

        public Game(Player[] players, Map map)
        {
            this.players = players;
            this.map = map;
            this.currentTurn = 1;
            this.currentPlayerId = 0;
        }
    
        public Player[] Players
        {
            get
            {
                return this.players;
            }
            set
            {
            }
        }

        public int CurrentPlayerId
        {
            get
            {
                return this.currentPlayerId;
            }
            set
            {
            }
        }

        public int CurrentTurn
        {
            get
            {
                return this.currentTurn;
            }
            set
            {
            }
        }

        public Map Map
        {
            get
            {
                return this.map;
            }
            set
            {
            }
        }

        public Unit SelectedUnit {
            get {
                return this.selectedUnit;
            }
            set {
                this.selectedUnit = value;
            }
        }

        public void save()
        {
            throw new System.NotImplementedException();
        }

        public bool nextTurn() {
            foreach(Player p in players) {
                foreach(Unit u in p.Army) {
                    u.ResetMov();
                }
            }

            updatePoints();
            nextPlayer();

            if(currentPlayerId == 0) {
                this.currentTurn++;
            }

            return gameFinished();
        }

        public bool gameFinished() {
            return players[0].Army.Count == 0 ||
                players[1].Army.Count == 0;
        }

        public String getWinner() {
            if(players[0].Score > players[1].Score) {
                return players[0].Name;
            }
            else {
                return players[1].Name;
            }
        }

        public void nextPlayer()
        {
            this.currentPlayerId = (this.currentPlayerId + 1) % 2;
        }

        public bool bagarre(Unit attacker, Unit defender)
        {
            double val = GameManager.rng.NextDouble();

            bool result = val <= 0.66;

            if(result) {
                players[currentPlayerId].Score += 10;
                attacker.MovementPoints = 0;
            }
            else {
                players[(currentPlayerId + 1) % 2].Score += 10;
                defender.MovementPoints = 0;
            }

            return result;
        }

        public void updatePoints() {
            foreach(Unit u in players[currentPlayerId].Army){
                if(map.getTile(u.Pos.X, u.Pos.Y).Type == u.FavoriteType) {
                    players[currentPlayerId].Score += 4;
                }else{
                    players[currentPlayerId].Score += 2;
                }
            }
        }
    }
}
