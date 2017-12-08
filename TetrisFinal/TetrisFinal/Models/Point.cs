using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisFinal.Models;

namespace TetrisFinal.Models {
    [Serializable]
    public class Point : ICloneable {
        public int x { get; set; }
        public int y { get; set; }
        public Colors Color { get; set; }

        public Point(int x, int y) { this.x = x; this.y = y; }
        public Point(int x, int y, Colors color) { this.x = x; this.y = y; this.Color = color; }

        public override bool Equals(object obj) {
            if(obj == null) return false;
            var that = obj as Point;
            return this.x == that.x && this.y == that.y && this.Color == that.Color;
        }

        public override int GetHashCode() {
            return (x.ToString() + y.ToString() + Color).GetHashCode();
        }

        object ICloneable.Clone() {
            return new Point(this.x, this.y, this.Color);
        }
    }
}
