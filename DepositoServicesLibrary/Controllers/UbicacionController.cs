using Dapper;
using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoServicesLibrary.Controllers
{
    public static class UbicacionController
    {
        private static SqliteDataAccess<UbicacionesEstadosJuegosDTO> dataAccess = new SqliteDataAccess<UbicacionesEstadosJuegosDTO>();

        public static UbicacionesEstadosJuegosDTO saveAndGet(UbicacionesEstadosJuegosDTO ubicacionesEstadosJuegosDTO)
        {
            int id = dataAccess.save(ubicacionesEstadosJuegosDTO);
            return getOne(id);
        }

        public static UbicacionesEstadosJuegosDTO getOne(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            UbicacionesEstadosJuegosDTO ubicacionesEstadosJuegosDTO = dataAccess.getOne("id = @Id", parameters);
            if (ubicacionesEstadosJuegosDTO == null)
            {
                throw new Exception("No existe");
            }

            return ubicacionesEstadosJuegosDTO;
        }
    }
}
