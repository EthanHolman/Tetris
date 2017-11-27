using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    class Block {
        public string Color { get; set; }
        public BlockShapes Shape { get; set; }
        public Block(BlockShapes newShape) {
            Shape = newShape;
        }
    }
}
