using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    class ZigBlock : Block {
        public string Color { get; set; }
        public int[,,] Grid { get; set; }

        public ZigBlock() {
            this.Grid = new int[2, 3, 3] {
                {
                    { 0, 0, 0 },
                    { 0, 1, 1 },
                    { 1, 1, 0 },
                },
                {
                    { 1, 0, 0 },
                    { 1, 1, 0 },
                    { 0, 1, 0 },
                }
            };

            this.Color = "Purple";
        }
    }
}
