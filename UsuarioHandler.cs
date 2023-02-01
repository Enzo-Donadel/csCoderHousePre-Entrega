using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enzo_Donadel
{
    internal static class UsuarioHandler
    {
        const string connectionString = "Data Source=DESKTOP-0CQ30RI\\SQLEXPRESS;Initial " +
            "Catalog=SistemaGestion;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";

        public static List<Usuario> getAllUsuario()
        {
            List<Usuario> userList = new List<Usuario>();
            using (SqlConnection SqlDbConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand SqlDbQuery = new SqlCommand("SELECT * FROM Usuario", SqlDbConnection))
                {
                    SqlDbConnection.Open();
                    using (SqlDataReader DataReader = SqlDbQuery.ExecuteReader())
                    {
                        if (DataReader.HasRows)
                        {
                            while (DataReader.Read())
                            {
                                Usuario temp = new Usuario();
                                temp.Id = DataReader.GetInt64(0);
                                temp.Nombre = DataReader.GetString(1);
                                temp.Apellido = DataReader.GetString(2);
                                temp.NombreUsuario = DataReader.GetString(3);
                                temp.Contraseña = DataReader.GetString(4);
                                temp.Mail = DataReader.GetString(5);

                                userList.Add(temp);
                            }
                        }
                    }
                    SqlDbConnection.Close();
                }
            }
            return userList;
        }
        public static Usuario getUsuarioByID(long idToSearch)
        {
            Usuario user = new Usuario();
            using (SqlConnection SqlDbConnection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuario WHERE Id=@parameterToSearch";
                using (SqlCommand SqlDbQuery = new SqlCommand(query, SqlDbConnection))
                {
                    SqlParameter ParameterID = new SqlParameter("parameterToSearch", System.Data.SqlDbType.BigInt);
                    ParameterID.Value = idToSearch;
                    SqlDbQuery.Parameters.Add(ParameterID);
                    SqlDbConnection.Open();
                    using (SqlDataReader DataReader = SqlDbQuery.ExecuteReader())
                    {
                        if (DataReader.HasRows)
                        {
                            DataReader.Read();
                            Usuario temp = new Usuario();
                            user.Id = Convert.ToInt64(DataReader.GetInt64(0));
                            user.Nombre = DataReader.GetString(1);
                            user.Apellido = DataReader.GetString(2);
                            user.NombreUsuario = DataReader.GetString(3);
                            user.Contraseña = DataReader.GetString(4);
                            user.Mail = DataReader.GetString(5);
                        }
                    }
                    SqlDbConnection.Close();
                }

            }
            return user;
        }
    }
}
