using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisFinal.Models {
    public class BumpOnALogBlock : Block {

        public int[,,] Grid { get; set; }
        public SolidColorBrush Color { get; set; }
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

            this.Color = Brushes.Black;
            this.Points = new List<Point>();
        }
    }
}
