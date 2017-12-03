﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    class L2Block : Block {
        public string Color { get; set; }
        public int[,,] Grid { get; set; }
        public List<Point> Points { get; set; }
        public int CurrentRotation { get; set; }

        public L2Block() {
            this.Grid = new int[4, 3, 3] {
                {
                    { 0, 0, 1 },
                    { 0, 0, 1 },
                    { 0, 1, 1 }
                },
                {
                    { 0, 0, 0 },
                    { 1, 0, 0 },
                    { 1, 1, 1 }
                },
                {
                    { 1, 1, 0 },
                    { 1, 0, 0 },
                    { 1, 0, 0 }
                },
                {
                    { 1, 1, 1 },
                    { 0, 0, 1 },
                    { 0, 0, 0 }
                }
            };

            this.Color = "Tan";
            this.Points = new List<Point>();
        }
    }
}
