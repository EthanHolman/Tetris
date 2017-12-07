using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    public class GameBoard {

        public const int GAMEBOARD_HEIGHT = 18;
        public const int GAMEBOARD_WIDTH = 10;

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

        public void ClearAt(Point p) {
            Set(p.x, p.y, null);
        }

        public bool WillPointFit(Point p) {
            return Get(p.x, p.y) == null;
        }

        public bool WillPointsFit(List<Point> points) {
            return WillPointsFit(points, new List<Point>());
        }

        public bool WillPointsFit(List<Point> points, List<Point> exemptPoints) {
            try { 
                foreach (Point p in points) {
                    var temp = Get(p.x, p.y);
                    if (temp != null && !exemptPoints.Contains(temp)) return false;
                }
            } catch(Exception) {
                return false; // In case coordinates fall out of bounds of array/linkedList
            }

            return true;
        }

        public bool AddPoints(List<Point> points) {
            if (WillPointsFit(points)) {
                foreach (Point p in points) Set(p.x, p.y, p);
                return true;
            }

            return false;
        }

        public void MovePoints(List<Point> from, List<Point> to) {
            foreach(Point p in from) {
                ClearAt(p);
            }

            foreach(Point p in to) {
                Set(p.x, p.y, p);
            }
        }
        
        public List<int> FindLines() {
            var lineNumbersWithLines = new List<int>();

            for (int i = 0; i < _board.Count; i++) {
                bool rowFull = true;

                foreach (Point point in _board.ElementAt(i))
                    if (point == null) rowFull = false;

                if (rowFull) lineNumbersWithLines.Add(i);
            }

            return lineNumbersWithLines;
        }

        public void RemoveLine(int index) {
            _board.Remove(_board.ElementAt(index));
            _board.AddFirst(new Point[GAMEBOARD_WIDTH]);
            UpdateBlockCoords(index);
        }

        private void UpdateBlockCoords(int toLineNum) {
            for (int i = 0; i <= toLineNum; i++) {

                foreach (Point point in _board.ElementAt(i))
                    if (point != null) point.y++;
            }
        }
    }
}
