﻿using DepositoLib.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServices.database
{
    public class UbicacionesEstadosTableQueryInfo : TableQueryInfo
    {
        public override string tableName
        {
            get { return "ubicaciones_estados"; }
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
            get { return "select * from ubicaciones_estados"; }
        }
        public override string InsertString
        {
            get { return "insert into ubicaciones_estados (fecha, movimiento_id) values (@Fecha, @movimiento_id)"; }
        }
        public override int getId(object movimiento)
        {
            return ((MovimientoDTO)movimiento).Id;
        }
        public override string duclicityString
        {
            get { return "fecha = @Fecha AND movimiento_id = @MovimientoId"; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            UbicacionesEstadosDTO ubicacionesEstadosDTO = obj as UbicacionesEstadosDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();
            dictionary.Add("@Fecha", ubicacionesEstadosDTO.Fecha);
            dictionary.Add("@Movimiento_id", ubicacionesEstadosDTO.Movimiento_id);
         

            return dictionary;
        }
    }
}
