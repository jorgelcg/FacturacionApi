using FacturacionApi.Dtos;
using FacturacionApi.Entities;
using FacturacionApi.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FacturacionApi.services
{
    public class FactService : IFac 
    {
       
        private readonly string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=LabDev;";
      
        public  List<FacturaDTO> GetAllFacts()
        {
            var Facturas = new List<FacturaDTO>();



            string SP = "EXEC ObtenerFactura";
            using (var connection = new SqlConnection(_connectionString))
            {

                using (var command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // 6. Itera sobre los resultados
                        while (reader.Read())
                        {
                            // 7. Lee cada columna y crea un objeto
                            var MiFcatura = new FacturaDTO
                            {
                                // Asume que hay columnas 'Id' y 'Nombre' en el SP
                                NumeroFactura = reader.GetInt32(reader.GetOrdinal("NumeroFactura")),

                            };
                            Facturas.Add(MiFcatura);
                        }
                    }


                    connection.Close();
                }
                return Facturas;
            }
      
        }
    }
}
