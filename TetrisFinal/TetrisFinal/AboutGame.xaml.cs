using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TetrisFinal {
    /// <summary>
    /// Interaction logic for AboutGame.xaml
    /// </summary>
    public partial class AboutGame : Window {
        public AboutGame() {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e) {
            this.Hide();
        }

        public void UpdateHighScore(int newScore) {
            int curHighScore = Int32.Parse(CurHighScore_Label.Content.ToString());
            if (curHighScore < newScore) {
                CurHighScore_Label.Content = newScore;
                MessageBox.Show("New High Score!");
            }
        }
    }
}
