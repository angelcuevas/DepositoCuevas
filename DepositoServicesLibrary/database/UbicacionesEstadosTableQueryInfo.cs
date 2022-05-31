﻿using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoServicesLibrary.database
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
            get { return "insert into ubicaciones_estados (fecha, movimiento_id, ubicacion_id) values (@Fecha, @MovimientoId, @UbicacionId)"; }
        }
        public override int getId(object ubicacionesEstadosDTO)
        {
            return ((UbicacionesEstadosDTO)ubicacionesEstadosDTO).Id;
        }
        public override string duclicityString
        {
            get { return "fecha = @Fecha AND movimiento_id = @MovimientoId AND ubicacion_id = @UbicacionId"; }
        }
        public override Dictionary<String, object> getDuplicityParameters(object obj)
        {
            UbicacionesEstadosDTO ubicacionesEstadosDTO = obj as UbicacionesEstadosDTO;
            Dictionary<String, object> dictionary = new Dictionary<String, object>();
            dictionary.Add("@Fecha", ubicacionesEstadosDTO.Fecha);
            dictionary.Add("@MovimientoId", ubicacionesEstadosDTO.MovimientoId);
            dictionary.Add("@UbicacionId", ubicacionesEstadosDTO.UbicacionId);


            return dictionary;
        }
    }
}
