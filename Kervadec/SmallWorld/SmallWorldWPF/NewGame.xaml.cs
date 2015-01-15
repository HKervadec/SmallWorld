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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class NewGame : Page {
        private GameManager gm;
        public NewGame() {
            InitializeComponent();

            this.gm = new GameManager();
        }

        private void Launch_Game(object sender, RoutedEventArgs e) {
            if(check_races()) {
                gm.addName(P1Name.Text);
                gm.addName(P2Name.Text);

                gm.addRace(convertIndex(P1Race.SelectedIndex));
                gm.addRace(convertIndex(P2Race.SelectedIndex));

                Game game = new Game();
                this.NavigationService.Navigate(game);

                setMapSize();
                game.LaunchGame(this.gm);
            }
        }

        private bool check_races() {
            return P1Race.SelectedIndex != P2Race.SelectedIndex;
        }

        private void setMapSize() {
            switch(SizeBox.SelectedIndex) {
                case 0:
                    gm.MS = MapSize.SMALL;
                    break;
                case 1:
                    gm.MS = MapSize.NORMAL;
                    break;
                case 2:
                    gm.MS = MapSize.HUGE;
                    break;
            }
        }

        private Race convertIndex(int i) {
            switch(i) {
                case 0:
                    return Race.Dwarfs;
                case 1:
                    return Race.Elfs;
                case 2:
                    return Race.Orcs;
            }

            return Race.Dwarfs;
        }
    }
}
