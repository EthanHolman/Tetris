using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisFinal.Services;

namespace ConsoleTester {
    class Program {
        static void Main(string[] args) {
            Game g = new Game();
            g.InitGame();

            g.OnTimerTick(null, null);
        }
    }
}
