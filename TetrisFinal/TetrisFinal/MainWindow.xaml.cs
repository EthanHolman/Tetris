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
        private Game game;
        public VisualHost host;
        public MainWindow() {
            InitializeComponent();

            Game tetris = new Game();

            host = new VisualHost(this);
            MyCanvas.Children.Add(host);

            tetris.AddGameboardUpdateEventHandler(OnGameboardUpdate);
        }

        // This method will get called when the GameBoard gets updated (blocks move, line detected, etc)
        private void OnGameboardUpdate() {

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
            game.Move(MoveDirection.Left);
        }

        private void ExecutedMoveRightCommand(object sender, ExecutedRoutedEventArgs e) {
            game.Move(MoveDirection.Right);
        }

        private void ExecutedRotateClockwiseCommand(object sender, ExecutedRoutedEventArgs e) {
            game.RotateCurrentBlock(RotateDirection.ClockWise);
        }

        private void ExecutedRotateCounterClockwiseCommand(object sender, ExecutedRoutedEventArgs e) {
            game.RotateCurrentBlock(RotateDirection.CounterClockWise);
        }

        private void ExecutedDropCommand(object sender, ExecutedRoutedEventArgs e) {
            game.DropBlock();
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
        private MainWindow parent;

        public VisualHost(MainWindow main) {
            this.parent = main;
            children = new VisualCollection(this);
        }

        /*
        public void Draw(Point pt) {
            
        } */

        public DrawingVisual CreateDrawing(int index) {

            // Create an instance of a DrawingVisual.
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext from the DrawingVisual.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            //Point point = game.GetPointAt();
            drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.White, 3), new Rect());

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