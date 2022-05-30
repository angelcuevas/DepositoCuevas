using DepositoCuevas.viewmodels;
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

namespace DepositoCuevas.views
{
    /// <summary>
    /// Lógica de interacción para DepositoMapa.xaml
    /// </summary>
    public partial class DepositoMapa : UserControl
    {
        MapaDepositoViewModel viewModel;
        private Point? mousePos;
        public DepositoMapa()
        {
            InitializeComponent();
            Loaded += onLoaded;

           
        }

        public void onLoaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(myCanvas.Height);
            viewModel = new MapaDepositoViewModel(myCanvas);
            this.DataContext = viewModel;
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
