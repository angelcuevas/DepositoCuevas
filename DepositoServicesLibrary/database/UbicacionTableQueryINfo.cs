using DepositoClassLibrary.deposito;
using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServicesLibrary.database
{
    class UbicacionTableQueryINfo : TableQueryInfo
    {

        public override string tableName
        {
            get { return "ubicaciones"; }
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
            get { return "select * from ubicaciones"; }
        }
        public override string InsertString
        {
            get { return "insert into ubicaciones (estanteria, modulo, nivel, bancal, nombre) values (@Estanteria, @Modulo, @Nivel, @Bancal, @Nombre)"; }
        }
        public override int getId(object ubicacion)
        {
            return ((UbicacionDTO)ubicacion).Id;
        }

        public override string duclicityString {
            get { return " estanteria = @Estanteria AND modulo = @Modulo AND nivel = @Nivel AND bancal = @Bancal "; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            UbicacionDTO ubicacion = obj as UbicacionDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();
            dictionary.Add("@Estanteria", ubicacion.Estanteria);
            dictionary.Add("@Modulo", ubicacion.Modulo);
            dictionary.Add("@Nivel", ubicacion.Nivel);
            dictionary.Add("@Bancal", ubicacion.Bancal);
            return dictionary;
        }

    }
}
