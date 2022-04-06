using DepositoClassLibrary.DTO;
using DepositoClassLibrary.juegos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServicesLibrary.database
{
    public class JuegoTableQueryInfo : TableQueryInfo
    {
        public override string tableName
        {
            get { return "juegos"; }
        }
        public override string SelectOneString
        {
            get { return " Coidgo = @Codigo "; }
        }
        public override string SelectString
        {
            get { return "select * from juegos";  }
        }
        public override string InsertString
        {
            get { return "insert into juegos (codigo, descripcion, cantidad) values (@Codigo, @Descripcion, @Cantidad)"; }
        }
        public override string UpdateString
        {
            get { return " update juegos set codigo = @Codigo, descripcion = @Descripcion, cantidad= @Cantidad "; }
        }
        public override int getId(object juego)
        {
            return ((JuegoDTO) juego).Id;
        }
        public override string duclicityString
        {
            get { return " codigo = @Codigo "; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            JuegoDTO juego = obj as JuegoDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();
            dictionary.Add("@Codigo", juego.Codigo);

            return dictionary;
        }
    }
}
