using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisFinal.Models {
    class LineBlock : Block {
        public SolidColorBrush Color { get; set; }
        public int[,,] Grid { get; set; }
        public List<Point> Points { get; set; }
        public int CurrentRotation { get; set; }

        public LineBlock() {
            this.Grid = new int[2, 4, 4] {
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 1, 1, 1, 1 },
                },
                {
                    { 1, 0, 0, 0 },
                    { 1, 0, 0, 0 },
                    { 1, 0, 0, 0 },
                    { 1, 0, 0, 0 },
                }
            };

            this.Color = Brushes.Orange;
            this.Points = new List<Point>();
        }
    }
}
