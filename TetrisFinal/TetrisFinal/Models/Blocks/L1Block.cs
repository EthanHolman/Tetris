using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    class L1Block : Block {
        public string Color { get; set; }
        public int[,,] Grid { get; set; }
        public L1Block() {
            this.Grid = new int[4, 3, 3] {
                {
                    { 1, 0, 0 },
                    { 1, 0, 0 },
                    { 1, 1, 0 }
                },
                {
                    { 1, 1, 1 },
                    { 1, 0, 0 },
                    { 0, 0, 0 }
                },
                {
                    { 0, 1, 1 },
                    { 0, 0, 1 },
                    { 0, 0, 1 }
                },
                {
                    { 0, 0, 0 },
                    { 0, 0, 1 },
                    { 1, 1, 1 }
                }
            };

            this.Color = "Blue";
        }
    }
}
