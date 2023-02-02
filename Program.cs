using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Enzo_Donadel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //testGetAllUsuario();
            //testGetUsuario(1);
            //testGetProductsByUserID(2);
            testGetVentaByUserID(1);
        }
        #region Tests Unitarios
        static void testGetAllUsuario()
        {
            List<Usuario> list = UsuarioHandler.getAllUsuario();
            foreach (Usuario usuario in list)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(usuario.Id.ToString());
                Console.WriteLine(usuario.Nombre);
                Console.WriteLine(usuario.Apellido);
                Console.WriteLine(usuario.NombreUsuario);
                Console.WriteLine(usuario.Contraseña);
                Console.WriteLine(usuario.Mail);
            }
        }
        static void testGetUsuario(long id)
        {
            Usuario user = UsuarioHandler.getUsuarioByID(id);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Datos de query");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(user.Id.ToString());
            Console.WriteLine(user.Nombre);
            Console.WriteLine(user.Apellido);
            Console.WriteLine(user.NombreUsuario);
            Console.WriteLine(user.Contraseña);
            Console.WriteLine(user.Mail);
        }
        static void testGetProductsByUserID(long id)
        {
            List<Producto> products = ProductoHandler.getProductByUserId(id);
            foreach (Producto product in products)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(product.Id.ToString());
                Console.WriteLine(product.Descripcion);
                Console.WriteLine(product.Costo.ToString());
                Console.WriteLine(product.PrecioVenta.ToString());
                Console.WriteLine(product.Stock.ToString());
                Console.WriteLine(product.IdUsuario.ToString());
            }
        }
        static void testGetVentaByUserID(long id)
        {
            List<Venta> ventas = VentaHandler.getVentaByUserId(id);
            foreach (Venta venta in ventas)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(venta.Id.ToString());
                Console.WriteLine(venta.Comentarios);
                Console.WriteLine(venta.IdUsuario.ToString());
            }
        }
        #endregion
    }
}