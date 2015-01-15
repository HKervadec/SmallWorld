using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Map
    {
        private Tile[,] world;
        private int size;
        private List<Coord> initPosList;

        public Map(MapSize ms) {
            this.setMapSize(ms);

            this.world = new Tile[size, size];

            this.buildMap(this.genTypes());

            this.genInitPos();
        }

        private void setMapSize(MapSize ms) {
            switch(ms) {
                case MapSize.SMALL:
                    this.size = 6;
                    break;
                case MapSize.NORMAL:
                    this.size = 10;
                    break;
                case MapSize.HUGE:
                    this.size = 16;
                    break;
            }
        }

        private List<TileType> genTypes() {
            List<TileType> result = new List<TileType>();

            int n = (this.size);
            n *= n;
            if(n % 2 == 1) {
                n++;
            }

            foreach(TileType t in Enum.GetValues(typeof(TileType))) {
                for(int i = 0 ; i < n / 4 ; i++) {
                    result.Add(t);
                }
            }

            return this.shuffleList(result);
        }

        private List<TileType> shuffleList(List<TileType> list) {

            int n = list.Count;
            while(n > 1) {
                n--;
                int k = GameManager.rng.Next(n + 1);
                TileType value = list[k];
                list[k] = list[n];
                list[n] = value;
            }  

            return list;
        }

        private void buildMap(List<TileType> types) {
            for(int x = 0 ; x < size ; x++) {
                for(int y = 0 ; y < size ; y++) {
                    if(x % 2 == y % 2) {
                        TileType type = types.First<TileType>();
                        types.RemoveAt(0);

                        Tile t = new Tile(type, new Coord(x, y), 1);

                        this.setTile(t);
                    }
                }
            }
        }

        public int Size {
            get {
                return this.size;
            }
            set {

            }
        }

        public Tile[,] World
        {
            get
            {
                return this.world;
            }
            set
            {
            }
        }

        public Tile getTile(int x, int y)
        {
            return this.world[x, y / 2];
        }

        public void setTile(Tile t)
        {
            int x = t.Address.X;
            int y = t.Address.Y;

            this.world[x, y / 2] = t;
        }

        public TileType getType(Coord address)
        {
            return getTile(address.X, address.Y).Type;
        }

        private void genInitPos() {
            this.initPosList = new List<Coord>();

            this.initPosList.Add(new Coord(3, 1));
            this.initPosList.Add(new Coord(this.size - 4, this.size - 2));
        }

        public Coord getPlayerInitPos() {
            Coord result = this.initPosList.ElementAt<Coord>(0);
            this.initPosList.RemoveAt(0);

            return result;            
        }
    }


}
