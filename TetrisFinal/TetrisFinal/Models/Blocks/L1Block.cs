﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisFinal.Models;

namespace TetrisFinal.Models {
    [Serializable]
    class L1Block : Block {
        public Colors Color { get; set; }
        public int[,,] Grid { get; set; }
        public List<Point> Points { get; set; }
        public int CurrentRotation { get; set; }

        public L1Block() {
            this.Grid = new int[4, 3, 3] {
                {
                    { 0, 1, 0 },
                    { 0, 1, 0 },
                    { 0, 1, 1 }
                },
                {
                    { 0, 0, 0 },
                    { 1, 1, 1 },
                    { 1, 0, 0 }
                },
                {
                    { 1, 1, 0 },
                    { 0, 1, 0 },
                    { 0, 1, 0 }
                },
                {
                    { 0, 0, 1 },
                    { 1, 1, 1 },
                    { 0, 0, 0 }
                }
            };

            this.Color = Colors.Blue;
            this.Points = new List<Point>();
        }
    }
}
