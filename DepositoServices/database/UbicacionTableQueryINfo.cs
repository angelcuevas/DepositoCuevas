using DepositoLib.deposito;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServices.database
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
            get { return "insert into ubicaciones (nivel, columna, fila, nombre) values (@Nivel, @Columna, @Fila, @Nombre)"; }
        }
        public override int getId(object ubicacion)
        {
            return ((Ubicacion)ubicacion).Id;
        }

        public override string duclicityString {
            get { return " nivel = @Nivel AND columna = @columna AND fila = @Fila "; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            Ubicacion ubicacion = obj as Ubicacion;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();
            dictionary.Add("@Nivel", ubicacion.Nivel );
            dictionary.Add("@Columna", ubicacion.Columna);
            dictionary.Add("@Fila", ubicacion.Fila);
            return dictionary;
        }

    }
}
