using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;





namespace ProjetoConsole
{
    class ClasseBanco : IDisposable
    {
        private readonly MySqlConnection connection;

        public ClasseBanco()
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
        }

        /* public void Dispose()
        {
        throw new NotImplementedException();
        } */

        public void ExecutaComando(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = connection
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader RetornaComando(string StrQuery)
        {
            var comando = new MySqlCommand(StrQuery, connection);
            return comando.ExecuteReader();
        }

        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}
