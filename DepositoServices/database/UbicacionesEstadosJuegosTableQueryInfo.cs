using DepositoLib.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServices.database
{
    public class UbicacionesEstadosJuegosTableQueryInfo :  TableQueryInfo
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
            get { return "insert into ubicaciones_estados_juegos (ubicaciones_estados_id, juegos_id, cantidad) values (@Ubicaciones_estados_id, @Juegos_id, @Cantidad)"; }
        }
        public override int getId(object juegos)
        {
            return ((JuegoDTO)juegos).Id;
        }
        public override string duclicityString
        {
            get { return "ubicaciones_estados_id = @Ubicaciones_estados_id AND juegos_id = @Juegos_id AND cantidad = @Cantidad"; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            UbicacionesEstadosJuegosDTO ubicacionesEstadosJuegosDTO = obj as UbicacionesEstadosJuegosDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();
            dictionary.Add("@Ubicaciones_estados_id", ubicacionesEstadosJuegosDTO.Ubicaciones_estados_id);
            dictionary.Add("@Juegos_id", ubicacionesEstadosJuegosDTO.Juegos_id);
            dictionary.Add("@Cantidad", ubicacionesEstadosJuegosDTO.Cantidad); ;


            return dictionary;
        }
    }
}
