using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Game
    {
        public Game(Player[] players, Map map)
        {
            this.players = players;
            this.Map = map;
            this.currentTurn = 0;
            this.currentPlayerId = 0;
        }
    
        public Player[] players
        {
            get
            {
                return this.players;
            }
            set
            {
            }
        }

        public int currentPlayerId
        {
            get
            {
                return this.currentPlayerId;
            }
            set
            {
            }
        }

        public int currentTurn
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
                return this.Map;
            }
            set
            {
            }
        }

        public void save()
        {
            throw new System.NotImplementedException();
        }

        public void nextPlayer()
        {
            this.currentPlayerId = (this.currentPlayerId + 1) % this.players.Length;
        }

        public void bagarre(Unit attacker, Unit defender)
        {
            throw new System.NotImplementedException();
        }
    }
}
