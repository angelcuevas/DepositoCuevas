using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServicesLibrary.database
{
    class MovimientoTableQueryInfo : TableQueryInfo
    {
        public override string tableName
        {
            get { return "movimientos"; }
        }
        public override string UpdateString
        {
            get { return " Codigo = @Codigo "; }
        }

        public override string SelectOneString
        {
            get { return " Codigo = @Codigo "; }
        }
        public override string SelectString
        {
            get { return "select * from movimientos"; }
        }
        public override string InsertString
        {
            get { return "insert into movimientos (fecha, ubicacion_origen, ubicacion_destino, comentarios) values (@Fecha, @UbicacionOrigen,@UbicacionDestino,@Comentario)"; }
        }
        public override int getId(object juego)
        {
            return ((MovimientoDTO)juego).Id;
        }
        public override string duclicityString
        {
            get { return ""; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            MovimientoDTO movimientoJuegoDTO = obj as MovimientoDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();

            return dictionary;
        }
    }
}
