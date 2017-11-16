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
using TetrisFinal.Services;

namespace TetrisFinal {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Game game;
        public MainWindow() {
            InitializeComponent();
        }

        private void StartNewGame() {
            this.game = new Game();
        }

        private void CloseGame() {
            var result = MessageBox.Show("Are you sure you want to quit?", "Tetris", MessageBoxButton.YesNo);
            if(result.Equals(MessageBoxResult.Yes)) this.Close();
        }

        private void Start() {
            
        }

        private void Pause() {

        }

        private void MenuItem_NewGame(object sender, RoutedEventArgs e) => StartNewGame();
        private void MenuItem_ExitGame(object sender, RoutedEventArgs e) => CloseGame();
        private void MenuItem_Start(object sender, RoutedEventArgs e) => Start();
        private void MenuItem_Pause(object sender, RoutedEventArgs e) => Pause();
    }
}
