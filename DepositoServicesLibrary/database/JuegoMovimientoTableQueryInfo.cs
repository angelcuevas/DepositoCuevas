using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServicesLibrary.database
{
    public class JuegoMovimientoTableQueryInfo : TableQueryInfo
    {
        public override string tableName
        {
            get { return "movimientos_juego"; }
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
            get { return "select * from movimientos_juego"; }
        }
        public override string InsertString
        {
            get { return "insert into movimientos_juego (juego_id, movimiento_id, saldo_anterior, cantidad, saldo) values (@JuegoId, @MovimientoId,@SaldoAnterior,@Cantidad,@Saldo)"; }
        }
        public override int getId(object juego)
        {
            return ((MovimientoJuegoDTO)juego).Id;
        }
        public override string duclicityString
        {
            get { return " movimiento_id = @MovimientoId AND cantidad = @Cantidad "; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            MovimientoJuegoDTO movimientoJuegoDTO = obj as MovimientoJuegoDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();
            dictionary.Add("@movimientoId", movimientoJuegoDTO.MovimientoId);
            dictionary.Add("@Cantidad", movimientoJuegoDTO.Cantidad);

            return dictionary;
        }
    }
}
