using DepositoClassLibrary.deposito;
using DepositoClassLibrary.DTO;
using DepositoCuevas.Commands;
using DepositoServicesLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DepositoCuevas.viewmodels
{
    public delegate void onIngresar(UbicacionEstadoActual estado);  // delegate
    public class UbicacionContenidoVM
    {
        private UbicacionDTO ubicacion;
        private UbicacionEstadoActual estado;

        public event onIngresar onIngresarClicked; // event

        public UbicacionEstadoActual Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string GetNumeroDeEstadoDescripcion
        {
            get {
                if (Estado == null || Estado.estado == null) return " Estado nº 0";

                return "Estado nº " + Estado.estado.Numero;

            }
        }

        public UbicacionContenidoVM(UbicacionDTO ubicacion)
        {
            if(ubicacion.Id == 0)
            {
                ubicacion = UbicacionController.getUbicacionFromDB(ubicacion);
            }
            this.ubicacion = ubicacion;

            fetchEstadoActual();

        }

        private void fetchEstadoActual()
        {
            Estado = UbicacionController.getUbicacionYEstadoActual(ubicacion);
            
        }

        public ICommand RunExtendedDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);

        private async void ExecuteRunDialog(object _)
        {

            onIngresarClicked.Invoke(estado);
        }

    }
}
