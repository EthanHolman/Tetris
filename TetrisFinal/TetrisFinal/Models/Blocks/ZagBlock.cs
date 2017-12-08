using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisFinal.Models;

namespace TetrisFinal.Models {
    [Serializable]
    class ZagBlock : Block {
        public Colors Color { get; set; }
        public int[,,] Grid { get; set; }
        public List<Point> Points { get; set; }
        public int CurrentRotation { get; set; }

        public ZagBlock() {
            this.Grid = new int[2, 3, 3] {
                {
                    { 0, 0, 0 },
                    { 1, 1, 0 },
                    { 0, 1, 1 },
                },
                {
                    { 0, 0, 1 },
                    { 0, 1, 1 },
                    { 0, 1, 0 },
                }
            };

            this.Color = Colors.DarkTurqoise;
            this.Points = new List<Point>();
        }
    }
}
