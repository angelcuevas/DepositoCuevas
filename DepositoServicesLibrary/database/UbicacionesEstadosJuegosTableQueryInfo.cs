using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoServicesLibrary.database
{
    public class UbicacionesEstadosJuegosTableQueryInfo : TableQueryInfo
    {
        public override string tableName
        {
            get { return "ubicaciones_estados_juegos"; }
        }
        public override string UpdateString
        {
            get { return " Coidgo = @Codigo "; }
        }
        public override string SelectOneString
        {
            get { return " Coidgo = @Codigo "; }
        }
        public override string SelectString
        {
            get { return "select * from ubicaciones_estados_juegos"; }
        }
        public override string InsertString
        {
            get { return "insert into ubicaciones_estados_juegos (ubicaciones_estados_id, juegos_cantidad_id) values (@UbicacionesEstadosId, @JuegosCantidadId)"; }
        }
        public override int getId(object ubicacionesEstadosJuegosDTO)
        {
            return ((JuegoDTO)ubicacionesEstadosJuegosDTO).Id;
        }
        public override string duclicityString
        {
            get { return ""; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            UbicacionesEstadosJuegosDTO ubicacionesEstadosJuegosDTO = obj as UbicacionesEstadosJuegosDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();


            return dictionary;
        }
    }
}
