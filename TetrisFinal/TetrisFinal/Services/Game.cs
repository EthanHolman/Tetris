using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TetrisFinal.Models;

namespace TetrisFinal.Services {
    public delegate void GameboardUpdateEventHandler(List<Point> oldPoints, List<Point> newPoints);
    public class Game {

        const int BASE_POINTS = 100;


        private bool _GameRunning;
        private Timer _timer;
        private event GameboardUpdateEventHandler _onGameboardUpdate;
        private Block _currentBlock;
        private double _speed;
        private int _linesThisLevel;


        public bool GameRunning { get => _GameRunning; }
        public Block CurrentBlock { get; }
        public int LineCount { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
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
            Score = 0;
            _currentBlock = null;
            LineCount = 0;
            Level = 1;
            _linesThisLevel = 0;
            _timer.Enabled = false;
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

        public void LevelUp() {
            _speed *= 0.75; // this increases speed by 25%
            _timer.Interval = _speed;

            Level++;
            _linesThisLevel = 0;
        }

        // This method will get called every time the timer "ticks" (when game is started/running)
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

                // If block can't move down, then it's hit bottom
                if (!MoveCurrentBlock(MoveDirection.Down)) {
                    _currentBlock = null; // time for a new block

                    //TODO update line counts, level and score
                    // Check for and clear any lines, updating line counts, level & score
                    ClearLines();
                }
            }
            
        }

        public Point GetPointAt(Point p) {
            return this.Gameboard.Get(p.x, p.y);
        }

        public void UpdateScore(int lineCount) {
            Score += ((BASE_POINTS * lineCount) + (50 * (lineCount - 1))) * Level;
        }

        public void ClearLines() {
            var lines = Gameboard.FindLines();

            if (lines.Count > 0) {
                LineCount += lines.Count;
                _linesThisLevel += lines.Count;
                UpdateScore(lines.Count);

                if (_linesThisLevel > 9) LevelUp();

                foreach (int lineNumber in lines)
                    Gameboard.RemoveLine(lineNumber);
            }
            // TODO the gui will need to know about this event separate from the "oldPoints" "newPoints" system already in place
        }

        public void DropBlock() {
            while(MoveCurrentBlock(MoveDirection.Down)) { }
            _currentBlock = null; // time for a new block
            // Check for and clear any lines, updating line counts, level & score
            ClearLines();
        }

        public void RotateCurrentBlock(RotateDirection direction) {
            if(_currentBlock == null) return;


            if (direction == RotateDirection.ClockWise) {
                _currentBlock.CurrentRotation++;
                if (_currentBlock.CurrentRotation >= _currentBlock.Grid.GetLength(0)) _currentBlock.CurrentRotation = 0;
            } else { 
                _currentBlock.CurrentRotation--;
                if (_currentBlock.CurrentRotation < 0) _currentBlock.CurrentRotation = (_currentBlock.Grid.GetLength(0) - 1);
            }

            var oldPoints = _currentBlock.Points;
            int xMinVal = Int32.MaxValue;
            int yMinVal = Int32.MaxValue;

            foreach(Point point in oldPoints) {
                if(point.x < xMinVal) xMinVal = point.x;
                if(point.y < yMinVal) yMinVal = point.y;
            }

            var newPoints = new List<Point>();

            for (int i = 0; i < _currentBlock.Grid.GetLength(1); i++) {
                for (int j = 0; j < _currentBlock.Grid.GetLength(2); j++) {
                    if (_currentBlock.Grid[_currentBlock.CurrentRotation, i, j] == 1) {
                        // (j, i) == (x, y)
                        newPoints.Add(new Point(xMinVal + j, yMinVal + i, _currentBlock.Color));
                    }
                }
            }

            _currentBlock.Points = newPoints;
            
            CallUpdateGUI(oldPoints, newPoints);
        }

        public bool MoveCurrentBlock(MoveDirection direction) {
            var oldPoints = _currentBlock.Points;
            var movedPoints = TranslatePoints(_currentBlock.Points, direction);

            if (Gameboard.WillPointsFit(movedPoints, _currentBlock.Points)) {
                Gameboard.MovePoints(_currentBlock.Points, movedPoints);
                _currentBlock.Points = movedPoints;
                CallUpdateGUI(oldPoints, movedPoints);
                return true;
            }

            return false;
        }
        
        public void Move(MoveDirection direction) {
            MoveCurrentBlock(direction);
        }

        public List<Point> TranslatePoints(List<Point> points, MoveDirection direction) {
            // TODO see if this works using ICloneable instead?
            var modifiedPoints = points.Select(p => new Point(p.x, p.y, p.Color)).ToList();
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

        public void CallUpdateGUI(List<Point> oldPoints, List<Point> newPoints) {
            if (_onGameboardUpdate != null) _onGameboardUpdate(oldPoints, newPoints);
        }

        public void AddGameboardUpdateEventHandler(GameboardUpdateEventHandler blockMove) { _onGameboardUpdate += blockMove; }
    }
}
