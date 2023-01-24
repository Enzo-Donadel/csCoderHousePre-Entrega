using System.Runtime.CompilerServices;

namespace Enzo_Donadel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Usuario pepitoUser = new Usuario(1,"Pepito","Perez","PepitoPerez34","1234","pepito_Perez32@gmail.com");
            Producto martilloRojo = new Producto(1,"Este es un Martillo Rojo", 33.33845f, 75.45877f, 2, 1);
            ProductoVendido esteYaNoEsMiProducto= new ProductoVendido(1, 1, -1, 1);
            Venta Venta1 = new Venta(1,"Vendido 1 Martillo Rojo a Juancito", 1);
        }
    }
}