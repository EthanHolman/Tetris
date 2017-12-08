using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisFinal.Models;

namespace TetrisFinal.Models {
    [Serializable]
    class SquareBlock : Block {
        public Colors Color { get; set; }
        public int[,,] Grid { get; set; }
        public List<Point> Points { get; set; }
        public int CurrentRotation { get; set; }

        public SquareBlock() {
            this.Grid = new int[1, 4, 4] {
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 0, 0 }
                }
            };

            this.Color = Colors.Green;
            this.Points = new List<Point>();
        }
    }
}
