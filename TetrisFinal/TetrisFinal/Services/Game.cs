using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisFinal.Models;

namespace TetrisFinal.Services {
    class Game {

        #region Private property backing fields

        private bool _GameRunning;

        #endregion

        public bool GameRunning { get => _GameRunning; }
        public int Rows { get; set; }
        public double Speed { get; set; }
        public int Points { get; set; }

        public Game() {
            InitGame();
        }

        public void InitGame() {
            _GameRunning = false;
            Speed = 1.0;
            Points = 0;
        }

        public void Start() {
            _GameRunning = true;
        }

        public void Pause() {
            _GameRunning = false;
        }

        public Block GetNextBlock() {
            Random r = new Random();
            Block toReturn = null;
            switch(r.Next(0, 7)) {
                case 0: toReturn = new Block(BlockShapes.Line); break;
                case 1: toReturn = new Block(BlockShapes.L1); break;
                case 2: toReturn = new Block(BlockShapes.L2); break;
                case 3: toReturn = new Block(BlockShapes.Zig); break;
                case 4: toReturn = new Block(BlockShapes.Zag); break;
                case 5: toReturn = new Block(BlockShapes.BumpOnALog); break;
                case 6: toReturn = new Block(BlockShapes.Square); break;
            }

            return toReturn;
        }

        public void IncreaseSpeed() { Speed *= 1.25; }
    }
}
