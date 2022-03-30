using DepositoLib.juegos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServices.database
{
    public class JuegoTableQueryInfo : TableQueryInfo
    {
        public override string SelectString
        {
            get { return "select * from juegos";  }
        }
        public override string InsertString
        {
            get { return "insert into juegos (codigo, descripcion) values (@Codigo, @Descripcion)"; }
        }
        public override int getId(object juego)
        {
            return ((Juego) juego).Id;
        }
        public override string duclicityString
        {
            get { return " codigo = @Codigo "; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            Juego juego = obj as Juego;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();
            dictionary.Add("@Codigo", juego.Codigo);

            return dictionary;
        }
    }
}
