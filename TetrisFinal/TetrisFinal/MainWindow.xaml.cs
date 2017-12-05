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
        private Game tetris;
        public VisualHost host;

        public MainWindow() {
            InitializeComponent();

            tetris = new Game();

            host = new VisualHost(tetris);
            MyCanvas.Children.Add(host);

            tetris.AddGameboardUpdateEventHandler(OnGameboardUpdate);
        }

        // This method will get called when the GameBoard gets updated (blocks move, line detected, etc)
        private void OnGameboardUpdate() {
            host.CreateDrawing();
        }

        //---------------------------------------Commands--------------------------------------
        private void ExecutedNewGameCommand(object sender, ExecutedRoutedEventArgs e) {
            this.tetris.InitGame();
        }

        private void ExecutedStartCommand(object sender, ExecutedRoutedEventArgs e) {
            this.tetris.Start();
        }

        private void ExecutedPauseCommand(object sender, ExecutedRoutedEventArgs e) {
            this.tetris.Pause();
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
            tetris.Move(MoveDirection.Left);
        }

        private void ExecutedMoveRightCommand(object sender, ExecutedRoutedEventArgs e) {
            tetris.Move(MoveDirection.Right);
        }

        private void ExecutedRotateClockwiseCommand(object sender, ExecutedRoutedEventArgs e) {
            tetris.RotateCurrentBlock(RotateDirection.ClockWise);
        }

        private void ExecutedRotateCounterClockwiseCommand(object sender, ExecutedRoutedEventArgs e) {
            tetris.RotateCurrentBlock(RotateDirection.CounterClockWise);
        }

        private void ExecutedDropCommand(object sender, ExecutedRoutedEventArgs e) {
            tetris.DropBlock();
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

    public class VisualHost : UIElement {
        public VisualCollection children;
        public Game game;

        public VisualHost(Game tetris) {
            game = tetris;
            children = new VisualCollection(this);
        }

        /*
        public void Draw(Point pt) {
            
        } */

        public DrawingVisual CreateDrawing() {

            // Create an instance of a DrawingVisual.
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext from the DrawingVisual.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            Models.Point point = null;
            for (int row = 0; row < GameBoard.GAMEBOARD_HEIGHT; row++) {
                for (int column = 0; column < GameBoard.GAMEBOARD_WIDTH; column++) {
                    point = game.GetPointAt(new Models.Point(column, row));
                    if (point != null)
                        drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.White, 2), new Rect(new System.Windows.Point(point.x, point.y), new Size(30, 30)));
                }
            }

            drawingContext.Close();
            return drawingVisual;
        }

            // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount {
            get { return children.Count; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index) {
            if (index < 0 || index >= children.Count) {
                throw new ArgumentOutOfRangeException();
            }

            return children[index];
        }
    }
}