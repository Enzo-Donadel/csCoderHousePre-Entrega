using System.Data.SqlClient;

namespace Enzo_Donadel
{
    internal class ProductoVendidoHandler
    {
        const string connectionString = "Data Source=DESKTOP-0CQ30RI\\SQLEXPRESS;Initial " +
            "Catalog=SistemaGestion;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";

        //Traer ProductosVendidos (recibe el id del usuario y devuelve una lista de productos vendidos por ese usuario)
        private static List<ProductoVendido> getTablaProductoVendido(long sellIdToSearch)
        {
            List<ProductoVendido> productosDeVentaX = new List<ProductoVendido>();
            using (SqlConnection SqlDbConnection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido WHERE IdVenta =@parameterToSearch";
                using (SqlCommand SqlDbQuery = new SqlCommand(query, SqlDbConnection))
                {
                    SqlParameter ParameterID = new SqlParameter("parameterToSearch", System.Data.SqlDbType.BigInt);
                    ParameterID.Value = sellIdToSearch;
                    SqlDbQuery.Parameters.Add(ParameterID);
                    SqlDbConnection.Open();
                    using (SqlDataReader DataReader = SqlDbQuery.ExecuteReader())
                    {
                        if (DataReader.HasRows)
                        {
                            while (DataReader.Read())
                            {
                                ProductoVendido temp = new ProductoVendido();
                                temp.Id = DataReader.GetInt64(0);
                                temp.Stock = Convert.ToInt32(DataReader.GetInt32(1));
                                temp.IdProducto = DataReader.GetInt64(2);
                                temp.IdVenta = DataReader.GetInt64(3);
                                productosDeVentaX.Add(temp);
                            }
                        }
                    }
                    SqlDbConnection.Close();
                }
            }
            return productosDeVentaX;
        }
        public static List<Producto> getProductosInVenta(long idVenta)
        {
            List<Producto> ProductosEnVenta = new List<Producto>();
            List<long> IdProductosEnVenta = new List<long>();
            long temp = 0;
            using (SqlConnection SqlDbConnection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductoVendido.IdProducto FROM ProductoVendido WHERE IdVenta =@parameterToSearch";
                using (SqlCommand SqlDbQuery = new SqlCommand(query, SqlDbConnection))
                {
                    SqlParameter ParameterID = new SqlParameter("parameterToSearch", System.Data.SqlDbType.BigInt);
                    ParameterID.Value = idVenta;
                    SqlDbQuery.Parameters.Add(ParameterID);
                    SqlDbConnection.Open();
                    using (SqlDataReader DataReader = SqlDbQuery.ExecuteReader())
                    {
                        if (DataReader.HasRows)
                        {
                            while (DataReader.Read())
                            {

                                temp = DataReader.GetInt64(0);
                                IdProductosEnVenta.Add(temp);
                            }
                        }
                    }
                    SqlDbConnection.Close();
                }
            }
            foreach (long item in IdProductosEnVenta)
            {
                ProductosEnVenta.Add(ProductoHandler.getProductById(item));
            }
            return ProductosEnVenta;
        }
        public static int getCantidadDeProductosVendidos(long idVenta, long idProducto)
        {
            int result = 0;
            using (SqlConnection SqlDbConnection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductoVendido.Stock FROM ProductoVendido WHERE IdVenta = @parameter1ToSearch AND IdProducto = @parameter2ToSearch";
                using (SqlCommand SqlDbQuery = new SqlCommand(query, SqlDbConnection))
                {
                    SqlParameter Parameter1ID = new SqlParameter("parameter1ToSearch", System.Data.SqlDbType.BigInt);
                    Parameter1ID.Value = idVenta;
                    SqlDbQuery.Parameters.Add(Parameter1ID);
                    SqlParameter Parameter2ID = new SqlParameter("parameter2ToSearch", System.Data.SqlDbType.BigInt);
                    Parameter2ID.Value = idProducto;
                    SqlDbQuery.Parameters.Add(Parameter2ID);
                    SqlDbConnection.Open();
                    using (SqlDataReader DataReader = SqlDbQuery.ExecuteReader())
                    {
                        if (DataReader.HasRows)
                        {
                            DataReader.Read();
                            result += DataReader.GetInt32(0);
                        }
                    }
                    SqlDbConnection.Close();
                }
            }
            return result;
        }
    }
}
