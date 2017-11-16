using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void IncreaseSpeed() { Speed *= 1.25; }
    }
}
