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

        //---------------------------------------Commands--------------------------------------
        private void ExecutedNewGameCommand(object sender, ExecutedRoutedEventArgs e) {
            this.game = new Game();
        }

        private void ExecutedStartCommand(object sender, ExecutedRoutedEventArgs e) {
            
        }

        private void ExecutedPauseCommand(object sender, ExecutedRoutedEventArgs e) {
            
        }

        private void ExecutedExitCommand(object sender, ExecutedRoutedEventArgs e) {
            if (MessageBox.Show("Are you sure you want to exit?", "Tetris", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void ExecutedAboutCommand(object sender, ExecutedRoutedEventArgs e) {
            
        }

        private void ExecutedRulesCommand(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void ExecutedMoveLeftCommand(object sender, ExecutedRoutedEventArgs e) {

        }

        private void ExecutedMoveRightCommand(object sender, ExecutedRoutedEventArgs e) {

        }

        private void ExecutedRotateClockwiseCommand(object sender, ExecutedRoutedEventArgs e) {

        }

        private void ExecutedRotateCounterClockwiseCommand(object sender, ExecutedRoutedEventArgs e) {

        }

        private void ExecutedDropCommand(object sender, ExecutedRoutedEventArgs e) {

        }

        //---------------------------CanExecute Commands--------------------------------------
        private void CanExecuteNewGameCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CanExecuteStartCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CanExecutePauseCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CanExecuteExitCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CanExecuteAboutCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CanExecuteRulesCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CanExecuteMoveLeftCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteMoveRightCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteRotateClockwiseCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteRotateCounterClockwiseCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteDropCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }
    }
}
