using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TetrisFinal
{
    public static class Commands {
        public static readonly RoutedCommand NewGame = new RoutedCommand();
        public static readonly RoutedCommand Start = new RoutedCommand();
        public static readonly RoutedCommand Pause = new RoutedCommand();
        public static readonly RoutedCommand Exit = new RoutedCommand();
        public static readonly RoutedCommand About = new RoutedCommand();
        public static readonly RoutedCommand Rules = new RoutedCommand();
        public static readonly RoutedCommand MoveLeft = new RoutedCommand();
        public static readonly RoutedCommand MoveRight = new RoutedCommand();
        public static readonly RoutedCommand RotateClockwise = new RoutedCommand();
        public static readonly RoutedCommand RotateCounterClockwise = new RoutedCommand();
        public static readonly RoutedCommand Drop = new RoutedCommand();
    }
}
