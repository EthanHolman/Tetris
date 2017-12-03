﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    class SquareBlock : Block {
        public string Color { get; set; }
        public int[,,] Grid { get; set; }
        public List<Point> Points { get; set; }
        public int CurrentRotation { get; set; }

        public SquareBlock() {
            this.Grid = new int[1, 2, 2] {
                {
                    { 1, 1 },
                    { 1, 1 }
                }
            };

            this.Color = "Green";
            this.Points = new List<Point>();
        }
    }
}