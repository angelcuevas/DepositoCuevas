using DepositoClassLibrary.DTO;
using DepositoClassLibrary.juegos;
using DepositoCuevas.Commands;
using DepositoServicesLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace DepositoCuevas.viewmodels
{
    public class MovimientoUbicacionVM :INotifyPropertyChanged
    {
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

        private JuegoDTO juegoBuscado;

        public JuegoDTO JuegoBuscado
        {
            get { return juegoBuscado; }
            set { juegoBuscado = value; NotifyPropertyChanged("JuegoBuscado"); }
        }

        private ObservableCollection<JuegoEstadoCantidad> listaDeJuegos = new ObservableCollection<JuegoEstadoCantidad>();

        public ObservableCollection<JuegoEstadoCantidad> ListaDeJuegos
        {
            get { return listaDeJuegos; }
            set { listaDeJuegos = value; }
        }


        private string codigoTextImput = "";

        public string CodigoTextImput
        {
            get { return codigoTextImput; }
            set { codigoTextImput = value; NotifyPropertyChanged("CodigoTextImput"); }
        }

        Regex digitsOnly = new Regex(@"[^\d]");
        private string cantidad = "";

        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = digitsOnly.Replace(value, ""); NotifyPropertyChanged("Cantidad"); }
        }

        public MovimientoUbicacionVM()
        {

        }

        private void findJuegoByCodigo()
        {
            try
            {
                Juego juego = JuegoController.getOne(CodigoTextImput);
                JuegoBuscado = juego.getJuego();
            }
            catch (Exception)
            {
                JuegoBuscado = null;
            }
        }

        private void addToMovimientoList()
        {
            if(juegoBuscado == null || ListaDeJuegos.ToList().Any(i => i.JuegoDTO.Codigo == juegoBuscado.Codigo))
            {
                return; 
            }

            if(String.IsNullOrEmpty(cantidad.Trim())) 
            {
                return;
            }


            JuegoEstadoCantidad nuevo = new JuegoEstadoCantidad()
            {
                JuegoDTO = JuegoBuscado,
                JuegoCantidadDTO = new JuegoCantidadDTO()
                {
                    Cantidad = int.Parse(Cantidad)
                }

            };

            ListaDeJuegos.Add(nuevo);
            cleanBusquedaDeJuego();
        }

        private void cleanBusquedaDeJuego()
        {
            CodigoTextImput = "";
            Cantidad = "";
            juegoBuscado = null;
        }

        private void removeFromMovimientoList(JuegoEstadoCantidad estado)
        {
            ListaDeJuegos.Remove(estado);
        }

        private void saveMovimiento()
        {
            
            //UbicacionController.moveFromOneUbicacionToAnother()
        }

        public AnotherCommandImplementation searchCodigoCommand
        {
            get
            {
                return new AnotherCommandImplementation(_ =>
                {
                    findJuegoByCodigo();
                });
            }
        }

        public AnotherCommandImplementation addToListCommand
        {
            get
            {
                return new AnotherCommandImplementation(_ =>
                {
                    addToMovimientoList();
                });
            }
        }

        public AnotherCommandImplementation eliminarDeListaCommand
        {
            get
            {
                return new AnotherCommandImplementation( parametro =>
                {
                    JuegoEstadoCantidad p = parametro as JuegoEstadoCantidad;
                    removeFromMovimientoList(p);
                });
            }
        }


        public AnotherCommandImplementation guardarMovimientoCommand
        {
            get
            {
                return new AnotherCommandImplementation(_ =>
                {
                    saveMovimiento();
                });
            }
        }




    }
}
