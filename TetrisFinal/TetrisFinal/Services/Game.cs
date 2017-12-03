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

        public bool GameRunning { get => _GameRunning; }
        public int RowCount { get; set; }
        public double Speed { get; set; }
        public int Points { get; set; }
        public GameBoard Gameboard { get; set; }

        public Game() {
            InitGame();
            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Elapsed += this.OnTimerTick;
        }

        public void InitGame() {
            _GameRunning = false;
            Speed = 1.0;
            Points = 0;
            _currentBlock = null;
            Gameboard = new GameBoard();
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

        public void IncreaseSpeed() { Speed *= 1.25; }

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

                // Try to add the points to gameboard
                // If this fails, they didn't fit on the gameboard, and that game's over
                if(!Gameboard.AddPoints(_currentBlock.Points)) {
                    // Game over
                }

            } else { // Update block positions in grid

                // Check if all points are able to move down without a collision

                // Move all points down, both in points collection and on gameboard

            }

            // Check if there is a line

            // Fire event to have GUI update
            if (_onGameboardUpdate != null) _onGameboardUpdate();
        }

        public void AddGameboardUpdateEventHandler(GameboardUpdateEventHandler blockMove) { _onGameboardUpdate += blockMove; }
    }
}
