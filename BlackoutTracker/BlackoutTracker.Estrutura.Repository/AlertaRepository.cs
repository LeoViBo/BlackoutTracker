using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackoutTracker.Estrutura.Model;

namespace BlackoutTracker.Estrutura.Repository
{
    public class AlertaRepository
    {
        private readonly string _connectionString = "User Id=RM99500;Password=100504;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));";

        // (MORADOR/TECNICO) Cria um novo alerta
        public bool NewAlerta(string Tipo, string Descricao, string Bairro, string Data, string Hora)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                string query = "INSERT INTO BlackoutTrackerAlertas (Tipo, Descricao, Bairro, Data, Hora) VALUES (:Tipo, :Descricao, :Bairro, :Data, :Hora)";

                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("Tipo", Tipo));
                    command.Parameters.Add(new OracleParameter("Descricao", Descricao));
                    command.Parameters.Add(new OracleParameter("Bairro", Bairro));
                    command.Parameters.Add(new OracleParameter("Data", Data));
                    command.Parameters.Add(new OracleParameter("Hora", Hora));

                    connection.Open();
                    int resultado = command.ExecuteNonQuery();

                    switch (resultado)
                    {
                        case 0:
                            return false;
                        default:
                            return true;
                    }
                }
            }
        }

        // (TECNICO) Deleta um alerta existente
        public bool DeleteAlerta(int ID)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                string query = "DELETE FROM BlackoutTrackerAlertas WHERE ID = :ID";

                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("ID", ID));

                    connection.Open();
                    int resultado = command.ExecuteNonQuery();

                    switch (resultado)
                    {
                        case 0:
                            return false;
                        default:
                            return true;
                    }
                }
            }
        }

        // (TECNICO) Verifica se um alerta existe (ajuda a deletar um alerta)
        public bool AlertaExiste(int ID)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM BlackoutTrackerAlertas WHERE ID = :ID";

                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("ID", ID));

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // (MORADOR) Retorna todos os alertas no bairro do morador
        public List<Alerta> GetAlertasPorBairro(string bairro)
        {
            var alertas = new List<Alerta>();

            using (var connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT ID, Tipo, Bairro, Descricao, Data, Hora FROM BlackoutTrackerAlertas WHERE Bairro = :Bairro";

                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("Bairro", bairro));

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            alertas.Add(new Alerta
                            {
                                ID = reader.GetInt32(0),
                                Tipo = reader.GetString(1),
                                Bairro = reader.GetString(2),
                                Descricao = reader.GetString(3),
                                Data = reader.GetString(4),
                                Hora = reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return alertas;
        }

        // (TECNICO) Retorna todos os alertas
        public List<Alerta> GetAllAlertasPorBairro()
        {
            var alertas = new List<Alerta>();

            using (var connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT * FROM BlackoutTrackerAlertas";

                using (var command = new OracleCommand(query, connection))
                {

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            alertas.Add(new Alerta
                            {
                                ID = reader.GetInt32(0),
                                Tipo = reader.GetString(1),
                                Bairro = reader.GetString(2),
                                Descricao = reader.GetString(3),
                                Data = reader.GetString(4),
                                Hora = reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return alertas;
        }
    }
}
