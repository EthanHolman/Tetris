﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    public class BumpOnALog : Block {

        public int[,,] Grid { get; set; }

        public string Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public BumpOnALog() {
            Grid = new int[4, 3, 3] { 
                { { 0, 0, 0 },
                  { 0, 1, 0 },
                  { 1, 1, 1 } },

                { { 1, 0, 0 },
                  { 1, 1, 0 },
                  { 1, 0, 0 } },

                { { 1, 1, 1 },
                  { 0, 1, 0 },
                  { 0, 0, 0 } },

                { { 0, 0, 1 },
                  { 0, 1, 1 },
                  { 0, 0, 1 } }
            };

            this.Color = "Black";
        }
    }
}
