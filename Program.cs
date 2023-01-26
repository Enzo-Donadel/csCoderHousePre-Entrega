using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Enzo_Donadel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario pepitoUser = new Usuario(1,"Pepito","Perez","PepitoPerez34","1234","pepito_Perez32@gmail.com");
            Producto martilloRojo = new Producto(1,"Este es un Martillo Rojo", 33.33845f, 75.45877f, 2, 1);
            ProductoVendido esteYaNoEsMiProducto= new ProductoVendido(1, 1, -1, 1);
            Venta Venta1 = new Venta(1,"Vendido 1 Martillo Rojo a Juancito", 1);
            DatabaseConnection();
        }
        static void DatabaseConnection()
        {
            string connectionString = "Data Source=DESKTOP-0CQ30RI\\SQLEXPRESS;Initial Catalog=VETERINARIA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Conexion correcta con la base de datos: " + connection.Database);
            connection.Close();
        }
    }
}