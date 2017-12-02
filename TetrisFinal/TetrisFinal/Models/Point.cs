using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    public class Point {
        public int x { get; set; }
        public int y { get; set; }
        public string Color { get; set; }

        public Point(int x, int y) { this.x = x; this.y = y; }
        public Point(int x, int y, string color) { this.x = x; this.y = y; this.Color = color; }
    }
}
