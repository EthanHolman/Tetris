using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal.Models {
    public interface Block {
        string Color { get; set; }
        int[,,] Grid { get; set; }
        List<Point> Points { get; set; }
        int CurrentRotation { get; set; }
    }
}
