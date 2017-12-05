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
using TetrisFinal.Models;

namespace TetrisFinal {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Game _tetris;

        public MainWindow() {
            InitializeComponent();

            _tetris = new Game();

            _tetris.AddGameboardUpdateEventHandler(OnGameboardUpdate);
        }

        private void Draw(Models.Point point) {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 30;
            rectangle.Height = 30;
            rectangle.Stroke = Brushes.White;
            rectangle.StrokeThickness = 2;
            rectangle.Fill = GetColor(point.Color);
            rectangle.Margin = new Thickness(point.x*30, point.y*30, 0, 0);
            MyCanvas.Children.Add(rectangle);
        }

        private SolidColorBrush GetColor(string color) {
            if (color == "black")
                return Brushes.Black;
            return Brushes.Black;
        }

        private void LoopGrid() {
            // Cross-thread safety
            Action action = () => {
                MyCanvas.Children.Clear();
                for (int row = 0; row < GameBoard.GAMEBOARD_HEIGHT; row++) {
                    for (int column = 0; column < GameBoard.GAMEBOARD_WIDTH; column++) {
                        var point = _tetris.GetPointAt(new Models.Point(column, row));
                        if (point != null)
                            Draw(point);
                    }
                }
            };

            var dispatcher = Application.Current.Dispatcher;
            if (dispatcher.CheckAccess())
                action();
            else
                dispatcher.Invoke(action);
        }

        // This method will get called when the GameBoard gets updated (blocks move, line detected, etc)
        private void OnGameboardUpdate() {
            LoopGrid();
        }

        //---------------------------------------Commands--------------------------------------
        private void ExecutedNewGameCommand(object sender, ExecutedRoutedEventArgs e) {
            this._tetris.InitGame();
        }

        private void ExecutedStartCommand(object sender, ExecutedRoutedEventArgs e) {
            this._tetris.Start();
        }

        private void ExecutedPauseCommand(object sender, ExecutedRoutedEventArgs e) {
            this._tetris.Pause();
        }

        private void ExecutedExitCommand(object sender, ExecutedRoutedEventArgs e) {
            if (MessageBox.Show("Are you sure you want to exit?", "_tetris", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void ExecutedAboutCommand(object sender, ExecutedRoutedEventArgs e) {
            
        }

        private void ExecutedRulesCommand(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void ExecutedMoveLeftCommand(object sender, ExecutedRoutedEventArgs e) {
            _tetris.Move(MoveDirection.Left);
        }

        private void ExecutedMoveRightCommand(object sender, ExecutedRoutedEventArgs e) {
            _tetris.Move(MoveDirection.Right);
        }

        private void ExecutedRotateClockwiseCommand(object sender, ExecutedRoutedEventArgs e) {
            _tetris.RotateCurrentBlock(RotateDirection.ClockWise);
        }

        private void ExecutedRotateCounterClockwiseCommand(object sender, ExecutedRoutedEventArgs e) {
            _tetris.RotateCurrentBlock(RotateDirection.CounterClockWise);
        }

        private void ExecutedDropCommand(object sender, ExecutedRoutedEventArgs e) {
            _tetris.DropBlock();
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