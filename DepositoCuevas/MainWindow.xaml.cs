using DepositoClassLibrary.juegos;
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

namespace DepositoCuevas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;

            viewModel.GoToJuegoPage += onJuegoPage;
        }

        public void onJuegoPage(Juego juego)
        {
            //Console.WriteLine("LCDTM " + juego.getJuego().Descripcion);            
            TabControl myTabControl = navigationDrawer.FindName("mainTabControl") as TabControl;
            myTabControl.SelectedIndex = 2;
        }
    }
}
