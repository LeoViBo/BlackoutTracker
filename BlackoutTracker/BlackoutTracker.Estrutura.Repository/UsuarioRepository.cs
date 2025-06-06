using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackoutTracker.Estrutura.Repository
{
    public class UsuarioRepository
    {
        private readonly string _connectionString = "User Id=RM99500;Password=100504;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));";
        private int UsuarioID = 0;
        public bool validarLogin(string Nome, string Senha)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT ID FROM BlackoutTrackerUsuario WHERE Nome = :nome AND Senha = :senha";
                connection.Open();

                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("nome", Nome));
                    cmd.Parameters.Add(new OracleParameter("senha", Senha));

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        UsuarioID = Convert.ToInt32(resultado);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public int GetID()
        {
            return UsuarioID;
        }

        public string GetBairro(int ID)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT Bairro FROM BlackoutTrackerUsuario WHERE ID = :ID";
                connection.Open();

                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("ID", ID));

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        string Bairro = Convert.ToString(resultado);
                        return Bairro;
                    }
                    else
                    {
                        return "Bairro não encontrado";
                    }
                }
            }
        }

        public string GetTipo(int ID)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT Tipo FROM BlackoutTrackerUsuario WHERE ID = :ID";
                connection.Open();

                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("ID", ID));

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        string Tipo = Convert.ToString(resultado);
                        return Tipo;
                    }
                    else
                    {
                        return "Tipo não encontrado";
                    }
                }
            }
        }
    }
}