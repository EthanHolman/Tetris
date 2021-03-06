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
using TetrisFinal.Services;
using TetrisFinal.Models;

namespace TetrisFinal {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Game _tetris;
        private AboutGame _about;
        private Rules _rules;

        public MainWindow() {
            InitializeComponent();

            _tetris = new Game();
            _about = new AboutGame();

            _tetris.AddGameboardUpdateEventHandler(OnGameboardUpdate);
            _tetris.AddGameOver(OnGameOver);
        }

        private UIElement Draw(Models.Point point) {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 30;
            rectangle.Height = 30;
            rectangle.Stroke = Brushes.White;
            rectangle.StrokeThickness = 2;
            rectangle.Fill = ConvertToWpfColor(point.Color);
            rectangle.Margin = new Thickness(point.x*30, point.y*30, 0, 0);
            return rectangle;
        }

        private void UpdateGameboard() {
            MainCanvas.Children.Clear();
            for (int row = 0; row < GameBoard.GAMEBOARD_HEIGHT; row++) {
                for (int column = 0; column < GameBoard.GAMEBOARD_WIDTH; column++) {
                    var point = _tetris.GetPointAt(new Models.Point(column, row));
                    if (point != null)
                        MainCanvas.Children.Add(Draw(point));
                }
            }
        }

        private void SetNextBlock() {
            NextBlockCanvas.Children.Clear();
            var blockPoints = _tetris.GetNextBlock().Points;
            foreach (Models.Point pt in blockPoints) {
                if (pt != null)
                    NextBlockCanvas.Children.Add(Draw(pt));
            }
        }

        private void UpdateLevelInfo() {
            CurScore.Content = _tetris.Score;
            CurLevel.Content = _tetris.Level;
            CurLines.Content = _tetris.LineCount;
        }

        // This method will get called when the GameBoard gets updated (blocks move, line detected, etc)
        private void OnGameboardUpdate() {
            // Cross-thread safety
            Action action = () => {
                UpdateGameboard();
                SetNextBlock();
                UpdateLevelInfo();
            };

            var dispatcher = Application.Current.Dispatcher;
            if (dispatcher.CheckAccess())
                action();
            else
                dispatcher.Invoke(action);
        }

        private void OnGameOver() {
            // Cross-thread safety
            Action action = () => {
                GameOver_Label.Visibility = Visibility.Visible;
                _about.UpdateHighScore((int)CurScore.Content);
                Pause_MenuItem.IsEnabled = false;
            };

            var dispatcher = Application.Current.Dispatcher;
            if (dispatcher.CheckAccess())
                action();
            else
                dispatcher.Invoke(action);
        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (GameOver_Label.Visibility == Visibility.Hidden)
                PauseGame();

            if (MessageBox.Show("Are you sure you want to exit?", "Close Tetris", MessageBoxButton.YesNo) != MessageBoxResult.Yes) e.Cancel = true;
            else {
                if (_about != null) _about.Close();
                if (_rules != null) _rules.Close();
            }
        }

        private void PauseGame() {
            this._tetris.Pause();
            IsPaused_Label.Visibility = Visibility.Visible;
            Pause_MenuItem.IsEnabled = false;
            Start_MenuItem.IsEnabled = true;
            Save_MenuItem.IsEnabled = true;
            Load_MenuItem.IsEnabled = true;
        }

        private void StartGame() {
            this._tetris.Start();
            IsPaused_Label.Visibility = Visibility.Hidden;
            Pause_MenuItem.IsEnabled = true;
            Start_MenuItem.IsEnabled = false;
            Save_MenuItem.IsEnabled = false;
            Load_MenuItem.IsEnabled = false;
        }

        private void LoadSavedGame() {
            _tetris = Game.LoadGame();

            if(_tetris == null) {
                MessageBox.Show("Sorry, there was an error loading saved game");
                return;
            }

            _tetris.AddGameboardUpdateEventHandler(OnGameboardUpdate);
            _tetris.AddGameOver(OnGameOver);
            OnGameboardUpdate();
        }

        private void SaveCurrentGame() {
            Game.SaveGame(_tetris);
        }

        private SolidColorBrush ConvertToWpfColor(TetrisFinal.Models.Colors color) {
            switch(color) {
                case Models.Colors.Black: return new SolidColorBrush(System.Windows.Media.Colors.Black);
                case Models.Colors.Blue: return new SolidColorBrush(System.Windows.Media.Colors.Blue);
                case Models.Colors.DarkOrange: return new SolidColorBrush(System.Windows.Media.Colors.DarkOrange);
                case Models.Colors.DarkRed: return new SolidColorBrush(System.Windows.Media.Colors.DarkRed);
                case Models.Colors.DarkTurqoise: return new SolidColorBrush(System.Windows.Media.Colors.DarkTurquoise);
                case Models.Colors.DarkViolet: return new SolidColorBrush(System.Windows.Media.Colors.DarkViolet);
                case Models.Colors.Green: return new SolidColorBrush(System.Windows.Media.Colors.Green);
            }

            return null;
        }

        //---------------------------------------Commands--------------------------------------
        private void ExecutedNewGameCommand(object sender, ExecutedRoutedEventArgs e) {
            this._tetris.InitGame();
            MainCanvas.Children.Clear();
            NextBlockCanvas.Children.Clear();
            Start_MenuItem.IsEnabled = true;
            Pause_MenuItem.IsEnabled = false;
            GameOver_Label.Visibility = Visibility.Hidden;
        }

        private void ExecutedSaveCommand(object sender, ExecutedRoutedEventArgs e) => SaveCurrentGame();

        private void ExecutedLoadCommand(object sender, ExecutedRoutedEventArgs e) => LoadSavedGame();

        private void ExecutedStartCommand(object sender, ExecutedRoutedEventArgs e) => StartGame();

        private void ExecutedPauseCommand(object sender, ExecutedRoutedEventArgs e) => PauseGame();

        private void ExecutedExitCommand(object sender, ExecutedRoutedEventArgs e) => Close();

        // TODO implement about and rules boxes
        private void ExecutedAboutCommand(object sender, ExecutedRoutedEventArgs e) {
            if (_about == null) _about = new AboutGame();
            _about.Show();
        }

        private void ExecutedRulesCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (_rules == null) _rules = new Rules();
            _rules.Show();
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

        private void ExecutedLineCheatCommand(object sender, ExecutedRoutedEventArgs e) {
            _tetris.Cheat_LineBlock();
            SetNextBlock();
        }

        private void ExecutedHomeCheatCommand(object sender, ExecutedRoutedEventArgs e) { _tetris.LevelUp(); UpdateLevelInfo(); }

        //---------------------------CanExecute Commands--------------------------------------
        private void CanExecuteNewGameCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;
            if (target != null) e.CanExecute = true; else e.CanExecute = false;
        }

        private void CanExecuteSaveCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;
            if (target != null) e.CanExecute = true; else e.CanExecute = false;
        }

        private void CanExecuteLoadCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;
            if (target != null) e.CanExecute = true; else e.CanExecute = false;
        }

        private void CanExecuteStartCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;
            if (target != null) e.CanExecute = true; else e.CanExecute = false;
        }

        private void CanExecutePauseCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;
            if (target != null) e.CanExecute = true; else e.CanExecute = false;
        }

        private void CanExecuteExitCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;
            if (target != null) e.CanExecute = true; else e.CanExecute = false;
        }

        private void CanExecuteAboutCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;
            if (target != null) e.CanExecute = true; else e.CanExecute = false;
        }

        private void CanExecuteRulesCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;
            if (target != null) e.CanExecute = true; else e.CanExecute = false;
        }

        private void CanExecuteMoveLeftCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null && _tetris.GameRunning) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteMoveRightCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null && _tetris.GameRunning) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteRotateClockwiseCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null && _tetris.GameRunning) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteRotateCounterClockwiseCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null && _tetris.GameRunning) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteDropCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null && _tetris.GameRunning) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteLineCheatCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null && _tetris.GameRunning) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        private void CanExecuteHomeCheatCommand(object sender, CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null && _tetris.GameRunning) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }
    }
}