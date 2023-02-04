namespace Enzo_Donadel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            while (n != -1)
            {
                Console.Clear();
                Console.WriteLine("------------------------- Tests de Ejercicio Entregable -------------------------");
                Console.WriteLine("¿De qué ejercicio desea obtener solucion? (-1 para salir)");
                Console.WriteLine("1 _ Ejercicio 1: Traer usuario (recibe un long)");
                Console.WriteLine("2 _ Ejercicio 2: Traer Productos (recibe un id de usuario y, devuelve una lista con todos los productos cargado por ese usuario)");
                Console.WriteLine("3 _ Ejercicio 3: Traer ProductosVendidos (recibe el id del usuario y devuelve una lista de productos vendidos por ese usuario)");
                Console.WriteLine("4 _ Ejercicio 4: Traer Ventas (recibe el id del usuario y devuelve un a lista de Ventas realizadas por ese usuario)");
                Console.WriteLine("5 _ Ejercicio 5: Inicio de sesión (recibe un usuario y contraseña y devuelve un objeto Usuario)");
                n = Convert.ToInt32(Console.ReadLine());
                Menu(n);
                Console.WriteLine("\n\nIngrese -1 para Salir., 1 para continuar.");
                Console.WriteLine("Desea Continuar? ");
                n = Convert.ToInt32(Console.ReadLine());
            }
        }
        static void Menu(int n)
        {
            long userID = 0;
            string userName = String.Empty;
            string userPass = String.Empty;
            switch (n)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Ejercicio 1: Traer usuario (recibe un int)");
                    Console.Write("Inserte ID de usuario a buscar: ");
                    userID = Convert.ToInt64(Console.ReadLine());
                    testGetUsuario(userID);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Ejercicio 2: Traer Productos (recibe un id de usuario y, devuelve una lista con todos los productos cargado por ese usuario)");
                    Console.Write("Inserte ID de usuario a buscar: ");
                    userID = Convert.ToInt64(Console.ReadLine());
                    testGetProductsByUserID(userID);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Ejercicio 3: Traer ProductosVendidos (recibe el id del usuario y devuelve una lista de productos vendidos por ese usuario)");
                    Console.Write("Inserte ID de usuario a buscar: ");
                    userID = Convert.ToInt64(Console.ReadLine());
                    testGetProductosVendidosByUser(userID);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Ejercicio 4: Traer Ventas (recibe el id del usuario y devuelve un a lista de Ventas realizadas por ese usuario)");
                    Console.Write("Inserte ID de usuario a buscar: ");
                    userID = Convert.ToInt64(Console.ReadLine());
                    testGetVentaByUserID(userID);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Ejercicio 5: Inicio de sesión (recibe un usuario y contraseña y devuelve un objeto Usuario)");
                    Console.Write("Usuario: ");
                    userName = Console.ReadLine();
                    Console.Write("Contraseña: ");
                    userPass = Console.ReadLine();
                    testUserLogIn(userName, userPass);
                    break;
                default:
                    Console.WriteLine("Inserte una eleccion Correcta.");
                    break;
            }
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
            Console.WriteLine("Datos del usuario solicitado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Id: " + user.Id.ToString());
            Console.WriteLine("Nombre: " + user.Nombre);
            Console.WriteLine("Apellido: " + user.Apellido);
            Console.WriteLine("Nombre de Usuario: " + user.NombreUsuario);
            Console.WriteLine("Contraseña: " + user.Contraseña);
            Console.WriteLine("Mail: " + user.Mail);
        }
        static void testGetProductsByUserID(long id)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Lista de Productos cargados por el Usuario solicitado.");
            Console.WriteLine("---------------------------------");
            List<Producto> products = ProductoHandler.getProductByUserId(id);
            foreach (Producto product in products)
            {
                Console.WriteLine("Id: " + product.Id.ToString());
                Console.WriteLine("Producto: " + product.Descripcion);
                Console.WriteLine("Costo: " + product.Costo.ToString());
                Console.WriteLine("Precio de Venta: " + product.PrecioVenta.ToString());
                Console.WriteLine("Cantidad de Stock: " + product.Stock.ToString());
                Console.WriteLine("IdUsuario: " + product.IdUsuario.ToString());
                Console.WriteLine("---------------------------------");
            }
        }
        static void testGetVentaByUserID(long id)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Lista de Ventas realizadas por el Usuario solicitado.");
            Console.WriteLine("---------------------------------");
            List<Venta> ventas = VentaHandler.getVentaByUserId(id);
            foreach (Venta venta in ventas)
            {
                Console.WriteLine("Id: " + venta.Id.ToString());
                Console.WriteLine("Comentarios: " + venta.Comentarios);
                Console.WriteLine("IdUsuario: " + venta.IdUsuario.ToString());
                Console.WriteLine("---------------------------------");
            }
        }
        static void testGetProductosVendidosByUser(long userId)
        {
            Dictionary<Producto, int> productosVendidos = ProductoHandler.getProductosVendidoPorUsuario(userId);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Diccionario de Productos Vendidos por el usuario solicitado, {0}:", UsuarioHandler.getUsuarioByID(userId).Nombre);
            Console.WriteLine("---------------------------------");
            foreach (Producto product in productosVendidos.Keys)
            {
                Console.WriteLine("Producto: " + product.Descripcion);
                Console.WriteLine("Cantidad Vendida: " + Convert.ToString(productosVendidos[product]));
                Console.WriteLine("---------------------------------");
            }
        }
        static void testUserLogIn(string user, string password)
        {
            Usuario testUser = UsuarioHandler.userLogIn(user, password);
            if (testUser.Id == 0)
            {

                Console.WriteLine("---------------------------------");
                Console.WriteLine("El Usuario o Contraseña ingresados no se corresponden con la base de datos.");
                Console.WriteLine("---------------------------------");
                return;
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Usuario Logeado Exitosamente");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(testUser.Id.ToString());
            Console.WriteLine(testUser.Nombre);
            Console.WriteLine(testUser.Apellido);
            Console.WriteLine(testUser.NombreUsuario);
            Console.WriteLine(testUser.Contraseña);
            Console.WriteLine(testUser.Mail);

        }
        #endregion
    }
}