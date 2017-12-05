using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisFinal.Models {
    public interface Block {
        SolidColorBrush Color { get; set; }
        int[,,] Grid { get; set; }
        List<Point> Points { get; set; }
        int CurrentRotation { get; set; }
    }
}
