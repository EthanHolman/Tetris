using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    public class GameBoard {

        private Block[][] _Board;

        public GameBoard() {
            _Board = new Block[18][];
            for(int i = 0; i < _Board.Length; i++) {
                _Board[i] = new Block[10];
            }
        }

    }
}
