using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TetrisFinal.Models;

namespace TetrisFinal.Services {
    public delegate void GameboardUpdateEventHandler();
    public class Game {

        private bool _GameRunning;
        private Timer _timer;
        private event GameboardUpdateEventHandler _onGameboardUpdate;
        private Block _currentBlock;
        private double _speed;

        public bool GameRunning { get => _GameRunning; }
        public Block CurrentBlock { get; }
        public int RowCount { get; set; }
        public int Points { get; set; }
        public GameBoard Gameboard { get; set; }

        public Game() {
            _timer = new Timer();
            _timer.Elapsed += this.OnTimerTick;
            InitGame();
        }

        public void InitGame() {
            Gameboard = new GameBoard();
            _GameRunning = false;
            _timer.Interval = _speed = 500;
            Points = 0;
            _currentBlock = null;
        }

        public void Start() {
            _GameRunning = true;
            _timer.Enabled = true;
        }

        public void Pause() {
            _GameRunning = false;
            _timer.Enabled = false;
        }

        public Block GetNextBlock() {
            Random r = new Random();
            Block toReturn = null;
            switch(r.Next(0, 7)) {
                case 0: toReturn = new BumpOnALogBlock(); break;
                case 1: toReturn = new L1Block(); break;
                case 2: toReturn = new L2Block(); break;
                case 3: toReturn = new LineBlock(); break;
                case 4: toReturn = new SquareBlock(); break;
                case 5: toReturn = new ZigBlock(); break;
                case 6: toReturn = new ZagBlock(); break;
            }

            return toReturn;
        }

        public void IncreaseSpeed() {
            _speed *= 0.75; // this increases speed by 25%
            _timer.Interval = _speed;
        }

        // This method will get called each time a block moves downward via timer
        public void OnTimerTick(object source, ElapsedEventArgs e) {
            
            if(_currentBlock == null) { // If there is no current block, get new block and insert it on the gameboard

                // Get new block
                _currentBlock = GetNextBlock();

                // Create initial points for this block, in reference to the gameboard
                for(int i = 0; i < _currentBlock.Grid.GetLength(1); i++) {
                    for(int j = 0; j < _currentBlock.Grid.GetLength(2); j++) {
                        if(_currentBlock.Grid[_currentBlock.CurrentRotation, i, j] == 1) {
                            // (j, i) == (x, y)
                            _currentBlock.Points.Add(new Point(j + 4, i, _currentBlock.Color));
                        }
                    }
                }

                // If there's no space to add a new block then gameboard is full and game is over
                if(!Gameboard.AddPoints(_currentBlock.Points)) {
                    // TODO Game over
                }

            } else { // Update block positions in grid

                if (!MoveCurrentBlock(MoveDirection.Down)) {
                    // Block can't move down, so it's hit bottom
                    _currentBlock = null;
                }

            }

            // Check if there is a line

            // Fire event to have GUI update
            if (_onGameboardUpdate != null) _onGameboardUpdate();
        }

        public bool MoveCurrentBlock(MoveDirection direction) {
            var movedPoints = TranslatePoints(_currentBlock.Points, direction);

            if (Gameboard.WillPointsFit(movedPoints, _currentBlock.Points)) {
                Gameboard.MovePoints(_currentBlock.Points, movedPoints);
                _currentBlock.Points = movedPoints;
                return true;
            }

            return false;
        }

        // TODO this method needs to work with a copy of points
        public List<Point> TranslatePoints(List<Point> points, MoveDirection direction) {
            var modifiedPoints = new List<Point>(points);
            int xMoveAmount = 0;
            int yMoveAmount = 0;

            switch (direction) {
                case MoveDirection.Down: yMoveAmount = 1; break;
                case MoveDirection.Left: xMoveAmount = -1; break;
                case MoveDirection.Right: xMoveAmount = 1; break;
                case MoveDirection.Up: yMoveAmount = -1; break;
            }

            foreach (Point p in modifiedPoints) {
                p.x += xMoveAmount;
                p.y += yMoveAmount;
            }

            return modifiedPoints;
        }

        public void AddGameboardUpdateEventHandler(GameboardUpdateEventHandler blockMove) { _onGameboardUpdate += blockMove; }
    }
}
