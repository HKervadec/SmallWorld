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
    /// Logique d'interaction pour UnitCell.xaml
    /// </summary>
    public partial class UnitCell : UserControl {
        private int x;
        private int y;

        Tile tile;
        Unit currentUnit;
        public UnitCell(Tile t, int x, int y) {
            InitializeComponent();

            this.x = x;
            this.y = y;

            tile = t;
        }

        public UnitCell(Unit u, Tile t, int x, int y) :
            this(t, x, y) {
            currentUnit = u;

            drawUnit();
        }

        public void drawUnit() {
            if(currentUnit != null) {
                if(currentUnit.GetType() == typeof(Dwarf)){
                    draw("dwarf");
                    return;
                }
                if(currentUnit.GetType() == typeof(Elf)) {
                    draw("elf");
                    return;
                }
                if(currentUnit.GetType() == typeof(Orc)) {
                    draw("orc");
                    return;
                }
            }
            else{
                draw("blank");
            }
        }

        public void draw(String race){
            this.button.Background = (Brush)button.Resources[race];
        }


        public void clic(object sender, RoutedEventArgs e) {
            Unit su = Game.game.CurrentGame.SelectedUnit;

            if(this.currentUnit != null) {
                if(this.currentUnit.OwnerId == Game.game.CurrentGame.CurrentPlayerId) {
                    Game.game.CurrentGame.SelectedUnit = this.currentUnit;
                    return;
                }
                else if(su != null){
                    // bagarre
                    if(su.Pos.NextTo(this.currentUnit.Pos) &&
                        su.MovementPoints >= 2) {
                        if(Game.game.CurrentGame.bagarre(su, this.currentUnit)) {
                            this.kill();
                        }
                        else {
                            Game.unitsCells[su.Pos.X, su.Pos.Y].kill();
                        }

                        return;
                    }
                }
            }

            
            if(su != null) {
                // Move the selected unit here
                Coord oldPos = su.Pos;
                
                if(!su.Move(this.tile, Game.game.CurrentGame.Map)) {
                    return;
                }
                Game.unitsCells[oldPos.X, oldPos.Y].eraseUnit();
                
                this.currentUnit = su;
                this.tile.CurrentUnit = su;
                drawUnit();

                Game.game.CurrentGame.SelectedUnit = null;

                return;
            }
        }

        public void eraseUnit() {
            this.currentUnit = null;
            this.tile.CurrentUnit = null;
            this.drawUnit();
        }

        public void kill() {
            Game.game.CurrentGame.Players[this.currentUnit.OwnerId].killUnit(this.currentUnit);
            this.eraseUnit();
        }
    }
}
