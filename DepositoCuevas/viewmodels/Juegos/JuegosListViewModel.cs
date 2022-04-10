using DepositoClassLibrary.DTO;
using DepositoClassLibrary.juegos;
using DepositoCuevas.Commands;
using DepositoCuevas.views;
using DepositoCuevas.views.common;
using DepositoCuevas.views.Juegos;
using DepositoServicesLibrary.Controllers;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DepositoCuevas.viewmodels.Juegos
{

    public delegate void Notify(Juego juego);  // delegate
    internal class JuegosListViewModel : INotifyPropertyChanged
    {
        private string searchString = "";
        private JuegoDTO newJuegoDTO = new JuegoDTO();

        private string mensaje = "Hello world";
        private ObservableCollection<Juego> lista;

        #region InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public event Notify GoToJuegoPage; // event

        #region

        #endregion


        public ObservableCollection<Juego> Lista
        {
            get { return lista; }
            set { lista = value; NotifyPropertyChanged("Lista"); }
        }
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; NotifyPropertyChanged("Mensaje"); }
        }

        public string SearchString { get { return this.searchString;  } set { this.searchString = value; } }


        public JuegosListViewModel()
        {
            actualizarLista(this.SearchString);
        }

        private void actualizarLista(string filter = "")
        {
            Lista = new ObservableCollection<Juego>(JuegoController.getAll(filter));
        }

        public ICommand RunSearchOnKeyDownCommand => new AnotherCommandImplementation(ExecuteSearchOnKeyDownCommand);

        private void ExecuteSearchOnKeyDownCommand(object _)
        {
            actualizarLista(SearchString);
        }

        public ICommand RunVerJuegoCommand => new AnotherCommandImplementation(ExecuteVerJuego);

        private async void ExecuteVerJuego(object _)
        {
            Juego juego = _ as Juego;

            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            GoToJuegoPage?.Invoke(juego);
            
        }


        #region SAMPLE 3

        public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);

        public ICommand RunExtendedDialogCommand => new AnotherCommandImplementation(ExecuteRunExtendedDialog);

        private async void ExecuteRunDialog(object _)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new NewJuegoForm()
            {
                DataContext = new JuegoDTO()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);

            //check the result...
            Debug.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
            => Debug.WriteLine("You can intercept the closing event, and cancel here.");

        private  void ExecuteRunExtendedDialog(object _)
        {

            openNewJuegoDialog();

        }
        private async void openNewJuegoDialog()
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new NewJuegoForm
            {
                DataContext = newJuegoDTO
            };
            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Debug.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }
        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Debug.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

        private void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) {
                newJuegoDTO = new JuegoDTO();
                return;
            }

            if (newJuegoDTO.Codigo.Trim() == "" || newJuegoDTO.Descripcion.Trim() == "")
            {
                eventArgs.Cancel();
                return;
            }


            //OK, lets cancel the close...
            eventArgs.Cancel();
            eventArgs.Session.UpdateContent(new Loading());
            try
            {
                JuegoController.saveAndGet(this.newJuegoDTO);
            }
            catch (Exception)
            {

            }
            finally{

                
                //eventArgs.Session.Close(false);
                Task.Delay(TimeSpan.FromSeconds(1))
                 .ContinueWith((t, _) => { if (!eventArgs.Session.IsEnded) { eventArgs.Session.Close(false); } }, null,
                     TaskScheduler.FromCurrentSynchronizationContext());
                actualizarLista();
            }


            //lets run a fake operation for 3 seconds then close this baby.

        }

        #endregion
    }
}
