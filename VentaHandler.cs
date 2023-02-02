using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enzo_Donadel
{
    internal class VentaHandler
    {
        const string connectionString = "Data Source=DESKTOP-0CQ30RI\\SQLEXPRESS;Initial " +
            "Catalog=SistemaGestion;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";

        //Traer Ventas (recibe el id del usuario y devuelve un a lista de Ventas realizadas por ese usuario)
        public static List<Venta> getVentaByUserId(long userIdToSearch)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection SqlDbConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand SqlDbQuery = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario =@parameterToSearch", SqlDbConnection))
                {
                    SqlParameter ParameterID = new SqlParameter("parameterToSearch", System.Data.SqlDbType.BigInt);
                    ParameterID.Value = userIdToSearch;
                    SqlDbQuery.Parameters.Add(ParameterID);
                    SqlDbConnection.Open();
                    using (SqlDataReader DataReader = SqlDbQuery.ExecuteReader())
                    {
                        if (DataReader.HasRows)
                        {
                            while (DataReader.Read())
                            {
                                Venta temp = new Venta();
                                temp.Id = DataReader.GetInt64(0);
                                temp.Comentarios = DataReader.GetString(1);
                                temp.IdUsuario = DataReader.GetInt64(2);
                                ventas.Add(temp);
                            }
                        }
                    }
                    SqlDbConnection.Close();
                }
            }
            return ventas;
        }
    }
}
