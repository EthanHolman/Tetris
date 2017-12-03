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

        public override bool Equals(object obj) {
            if(obj == null) return false;
            var that = obj as Point;
            return this.x == that.x && this.y == that.y && this.Color == that.Color;
        }

        public override int GetHashCode() {
            return (x.ToString() + y.ToString() + Color).GetHashCode();
        }
    }
}
