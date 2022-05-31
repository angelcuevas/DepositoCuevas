using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoServicesLibrary.database
{
    internal class JuegoCantidadTableQueryInfo : TableQueryInfo
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
            get { return "insert into ubicaciones_estados_juegos (juego_id, cantidad) values (@JuegoId, @Cantidad)"; }
        }
        public override int getId(object ubicacionesEstadosJuegosDTO)
        {
            return ((JuegoCantidadDTO)ubicacionesEstadosJuegosDTO).Id;
        }
        public override string duclicityString
        {
            get { return ""; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            JuegoCantidadDTO ubicacionesEstadosJuegosDTO = obj as JuegoCantidadDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();


            return dictionary;
        }
    }
}
