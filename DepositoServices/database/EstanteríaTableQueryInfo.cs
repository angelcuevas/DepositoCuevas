using DepositoLib.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServices.database
{
    public class EstanteríaTableQueryInfo : TableQueryInfo
    {
        public override string tableName
        {
            get { return "estanterias"; }
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
            get { return "select * from estanterias"; }
        }
        public override string InsertString
        {
            get { return "insert into estanterias (nombre) values (@Nombre)"; }
        }
        public override int getId(object estanteria)
        {
            return ((EstanteriaDTO)estanteria).Id;
        }
        public override string duclicityString
        {
            get { return " nombre = @Nombre "; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            EstanteriaDTO estanteria = obj as EstanteriaDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();
            dictionary.Add("@Nombre", estanteria.Nombre);

            return dictionary;
        }
    }
}
