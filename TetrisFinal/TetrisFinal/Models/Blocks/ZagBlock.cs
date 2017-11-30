using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    class ZagBlock : Block {
        public string Color { get; set; }
        public int[,,] Grid { get; set; }

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

            this.Color = "Pink";
        }
    }
}
