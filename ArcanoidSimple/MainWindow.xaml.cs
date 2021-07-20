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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArcanoidSimple
{
   
    public partial class MainWindow : Window
    {
        GameEndgine gameEndgine = new GameEndgine();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWin_Loaded(object sender, RoutedEventArgs e)
        {
            
            gameEndgine.Init(ref MapSpace);
            gameEndgine.Draw();

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            gameEndgine.KeyDown(e.Key);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
           
        }
    }
}
