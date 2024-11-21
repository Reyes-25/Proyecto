using Proyecto._2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto._2.Controllers
{
    public class HistorialCalculosRepository
    {
        private readonly string connectionString;

        public HistorialCalculosRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["calculadora"]?.ConnectionString
                                ?? throw new InvalidOperationException("Cadena de conexión no encontrada.");
        }

        public IEnumerable<HistorialCalculos> GetTodos()
        {
            return ExecuteQuery("SELECT * FROM HistorialCalculos");
        }

        public IEnumerable<HistorialCalculos> GetSumas()
        {
            return ExecuteQuery("SELECT * FROM HistorialCalculos WHERE Operacion LIKE '%+%'");
        }

        public IEnumerable<HistorialCalculos> GetRestas()
        {
            return ExecuteQuery("SELECT * FROM HistorialCalculos WHERE Operacion LIKE '%-%'");
        }

        public IEnumerable<HistorialCalculos> GetMultiplicaciones()
        {
            return ExecuteQuery("SELECT * FROM HistorialCalculos WHERE Operacion LIKE '%*%'");
        }

        public IEnumerable<HistorialCalculos> GetDivisiones()
        {
            return ExecuteQuery("SELECT * FROM HistorialCalculos WHERE Operacion LIKE '%/%'");
        }

        private IEnumerable<HistorialCalculos> ExecuteQuery(string query)
        {
            var resultados = new List<HistorialCalculos>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var calculo = new HistorialCalculos
                            {
                                Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                                Valor1 = reader["Valor1"] != DBNull.Value ? Convert.ToInt32(reader["Valor1"]) : 0,
                                Valor2 = reader["Valor2"] != DBNull.Value ? Convert.ToInt32(reader["Valor2"]) : 0,
                                Operacion = reader["Operacion"]?.ToString(),
                                OperacionText = reader["OperacionText"]?.ToString(),
                                Resultado = reader["Resultado"] != DBNull.Value ? Convert.ToInt32(reader["Resultado"]) : 0,
                                FechaRegistro = reader["FechaRegistro"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["FechaRegistro"])
                                    : DateTime.MinValue
                            };

                            resultados.Add(calculo);
                        }
                    }
                }
            }

            return resultados;
        }

    }
}