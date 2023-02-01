using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Enzo_Donadel
{
    internal class Program
    {
        static void Main(string[] args)
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
            Usuario user = UsuarioHandler.getUsuarioByID(2);
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
    }
}