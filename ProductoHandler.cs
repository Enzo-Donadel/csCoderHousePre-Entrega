using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enzo_Donadel
{
    internal class ProductoHandler
    {
        const string connectionString = "Data Source=DESKTOP-0CQ30RI\\SQLEXPRESS;Initial " +
            "Catalog=SistemaGestion;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";

        //Traer Productos (recibe un id de usuario y, devuelve una lista con todos los productos cargado por ese usuario)
        public static List<Producto> getProductByUserId(long userIdToSearch)
        {
            List<Producto> products = new List<Producto>();
            using (SqlConnection SqlDbConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand SqlDbQuery = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario =@parameterToSearch", SqlDbConnection))
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
                                Producto temp = new Producto();
                                temp.Id = DataReader.GetInt64(0);
                                temp.Descripcion = DataReader.GetString(1);
                                temp.Costo = DataReader.GetDecimal(2);
                                temp.PrecioVenta = DataReader.GetDecimal(3);
                                temp.Stock = DataReader.GetInt32(4);
                                temp.IdUsuario = DataReader.GetInt64(5);
                                products.Add(temp);
                            }
                        }
                    }
                    SqlDbConnection.Close();
                }
            }
            return products;
        }
    }
}
