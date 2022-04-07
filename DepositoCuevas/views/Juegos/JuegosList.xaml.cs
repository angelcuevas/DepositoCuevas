using DepositoCuevas.viewmodels.Juegos;
using DepositoCuevas.Windows;
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

namespace DepositoCuevas.views.Juegos
{
    /// <summary>
    /// Lógica de interacción para JuegosList.xaml
    /// </summary>
    public partial class JuegosList : UserControl
    {
        JuegosListViewModel viewModel = new JuegosListViewModel(); 
        public JuegosList()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JuegoForm formulario = new JuegoForm();

            formulario.Owner = Application.Current.MainWindow;
            formulario.Show();
            
        }
    }
}
