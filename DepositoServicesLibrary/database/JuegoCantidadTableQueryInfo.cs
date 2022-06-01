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
            get { return "juegos_cantidad"; }
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
            get { return "select * from juegos_cantidad"; }
        }
        public override string InsertString
        {
            get { return "insert into juegos_cantidad (juego_id, cantidad) values (@JuegoId, @Cantidad)"; }
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
            //dictionary.Add("@JuegoId", ubicacionesEstadosJuegosDTO.JuegoId);
            //dictionary.Add("@Cantidad", ubicacionesEstadosJuegosDTO.Cantidad);

            return dictionary;
        }
    }
}
