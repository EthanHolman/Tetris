using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisFinal.Models {
    class ZagBlock : Block {
        public SolidColorBrush Color { get; set; }
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
                    { 0, 1, 0 },
                    { 1, 1, 0 },
                    { 1, 0, 0 },
                }
            };

            this.Color = Brushes.Pink;
            this.Points = new List<Point>();
        }
    }
}
