﻿using System;
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

namespace SmallWorldWPF {
    /// <summary>
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page {
        public MainMenu() {
            InitializeComponent();
        }

        private void NewGame(object sender, RoutedEventArgs e) {
            NewGame newgame = new NewGame();
            this.NavigationService.Navigate(newgame);
        }

        private void Exit(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
