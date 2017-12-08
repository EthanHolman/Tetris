using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisFinal.Models;

namespace TetrisFinal.Models {
    [Serializable]
    public class BumpOnALogBlock : Block {

        public int[,,] Grid { get; set; }
        public Colors Color { get; set; }
        public List<Point> Points { get; set; }
        public int CurrentRotation { get; set; }

        public BumpOnALogBlock() {
            Grid = new int[4, 3, 3] { 
                {
                    { 0, 1, 0 },
                    { 1, 1, 1 },
                    { 0, 0, 0 }
                },
                {
                    { 0, 1, 0 },
                    { 0, 1, 1 },
                    { 0, 1, 0 }
                },
                {

                    { 0, 0, 0 },
                    { 1, 1, 1 },
                    { 0, 1, 0 }
                },
                {
                    { 0, 1, 0 },
                    { 1, 1, 0},
                    { 0, 1, 0 }
                }
            };

            this.Color = Colors.Black;
            this.Points = new List<Point>();
        }
    }
}
