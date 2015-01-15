using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SmallWorld;

namespace SmallWorldWPF {
    /// <summary>
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    public partial class Game : Page {
        public static GameManager game;
        public static UnitCell[,] unitsCells;

        private Image[] tiles;
        private BitmapImage[] tilesImages;
        private int tileWidth;
        private int tileHeight;



        public Game() {
            InitializeComponent();

            this.tilesImages = new BitmapImage[4];
            this.loadTextures();
        }

        private void loadTextures() {
            foreach(TileType t in Enum.GetValues(typeof(TileType))) {
                this.tilesImages[(int)t] = new BitmapImage(new Uri(this.getTilePath(t), UriKind.Absolute));
            }

            this.tileWidth = (int)this.tilesImages[0].Width;
            this.tileHeight = (int)this.tilesImages[0].Height;
        }

        private String getTilePath(TileType t) {
            switch(t) {
                case TileType.Field:
                    return "pack://application:,,,/Resources/Game/field.png";
                case TileType.Moutain:
                    return "pack://application:,,,/Resources/Game/moutain.png";
                case TileType.Forest:
                    return "pack://application:,,,/Resources/Game/forest.png";
                case TileType.Desert:
                    return "pack://application:,,,/Resources/Game/desert.png";
            }

            return "";
        }

        public void LaunchGame(GameManager g) {
            game = g;

            game.launchGame();

            this.drawGame();
        }

        public void drawGame() {
            this.drawMap();
            this.drawUnits();

            updateTurn();
            updateScores();
            updateNames();
            updateOpacity();
        }

        public void drawMap() {
            Map map = game.CurrentGame.Map;
            int size = map.Size;
            unitsCells = new UnitCell[size, size];

            for(int x = 0 ; x < size ; x++) {
                for(int y = 0 ; y < size ; y++) {
                    if(x % 2 == y % 2) {
                        createCell(map, x, y);

                        createUnit(map, x, y);
                    }
                }
            }
        }

        public void createCell(Map map, int x, int y) {
            TileType t = map.getTile(x, y).Type;

            Image img = new Image();
            img.Source = this.tilesImages[(int)t];
            img.Width = this.tilesImages[(int)t].Width;
            img.Height = this.tilesImages[(int)t].Height;

            int decal = tileWidth / 2;
            int X =  genX(x, y, tileWidth, tileHeight);
            int Y = genY(x, y, tileWidth, tileHeight);
            Canvas.SetLeft(img, X);
            Canvas.SetTop(img, Y);
            board.Children.Add(img);
        }

        public void createUnit(Map map, int x, int y) {
            int X = genX(x, y, tileWidth, tileHeight);
            int Y = genY(x, y, tileWidth, tileHeight);

            Tile t = map.getTile(x, y);
            Unit u = t.CurrentUnit;
            UnitCell uc;
            if(u != null) {
                uc = new UnitCell(u, t, x, y);
            }
            else {
                uc = new UnitCell(t, x, y);
            }

            unitsCells[x, y] = uc;
       
            Canvas.SetLeft(uc, X + 25);
            Canvas.SetTop(uc, Y + 16);
            board.Children.Add(uc);
        }

        public static int genX(int x, int y, int tileWidth, int tileHeight) {
            return y / 2 * 3 * tileWidth / 2 + (x % 2) * tileWidth * 3 / 4;
        }

        public static int genY(int x, int y, int tileWidth, int tileHeight) {
            return x * tileHeight / 2;
        }

        public void End_Turn(object sender, RoutedEventArgs e) {
            if(game.CurrentGame.nextTurn()) {
                String winnerName = game.CurrentGame.getWinner();
                Victory vc = new Victory(winnerName);
                this.NavigationService.Navigate(vc);
            }

            updateTurn();
            updateScores();
            updateOpacity();
        }

        public void updateTurn() {
            Turn.Clear();
            Turn.AppendText("Turn " + game.CurrentGame.CurrentTurn);
        }

        public void updateScores() {
            P1Score.Clear();
            P1Score.AppendText(game.CurrentGame.Players[0].Score + " pts");

            P2Score.Clear();
            P2Score.AppendText(game.CurrentGame.Players[1].Score + " pts");
        }

        public void updateNames() {
            P1Name.Clear();
            P1Name.AppendText(game.CurrentGame.Players[0].Name);

            P2Name.Clear();
            P2Name.AppendText(game.CurrentGame.Players[1].Name);
        }

        public void updateOpacity() {
            if(game.CurrentGame.CurrentPlayerId == 0) {
                P2Image.Opacity = 0.5;
                P2Name.Opacity = 0.5;
                P2Score.Opacity = 0.5;

                P1Image.Opacity = 1;
                P1Name.Opacity = 1;
                P1Score.Opacity = 1;
            }
            else {
                P1Image.Opacity = 0.5;
                P1Name.Opacity = 0.5;
                P1Score.Opacity = 0.5;

                P2Image.Opacity = 1;
                P2Name.Opacity = 1;
                P2Score.Opacity = 1;
            }
        }

        public void drawUnits() {

        }
    }
}
