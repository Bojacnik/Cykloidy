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
using WpfApp1;

namespace CykloidyWPF
{
    /// <summary>
    /// Interaction logic for CycloidOverview.xaml
    /// </summary>
    public partial class CycloidOverview : Window
    {
        public CycloidOverview()
        {
            InitializeComponent();
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            BasicCycloidWindow bcw = new();
            bcw.Show();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EpicycloidWindow ecw = new();
            ecw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PericycloidWindow pcw = new PericycloidWindow();
            pcw.Show();
        }
    }
}
