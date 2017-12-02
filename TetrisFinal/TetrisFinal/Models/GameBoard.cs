using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    public class GameBoard {

        const int GAMEBOARD_HEIGHT = 18;
        const int GAMEBOARD_WIDTH = 10;

        private LinkedList<Point[]> _board;

        public GameBoard() {
            _board = new LinkedList<Point[]>();
            for(int i = 0; i < GAMEBOARD_HEIGHT; i++) _board.AddFirst(new Point[GAMEBOARD_WIDTH]);
        }

        public Point Get(int x, int y) {
            return _board.ElementAt(y)[x];
        }

        public void Set(int x, int y, Point p) {
            _board.ElementAt(y)[x] = p;
        }

        public void RemoveLine(int index) {
            _board.Remove(_board.ElementAt(index));
            _board.AddFirst(new Point[GAMEBOARD_WIDTH]);
        }

    }
}
