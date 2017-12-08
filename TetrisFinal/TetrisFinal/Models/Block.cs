using System;
using System.Collections.Generic;
using TetrisFinal.Models;

namespace TetrisFinal.Models {
    public interface Block {
        Colors Color { get; set; }
        int[,,] Grid { get; set; }
        List<Point> Points { get; set; }
        int CurrentRotation { get; set; }
    }
}
