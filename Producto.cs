namespace Enzo_Donadel
{
    public class Producto
    {
        private uint _id;
        private string _descripcion;
        private float _costo;
        private float _precioVenta;
        private int _stock;
        private uint _idUsuario;

        public Producto()
        {
            this._id = 0;
            this._descripcion = string.Empty;
            this._costo = 0;
            this._precioVenta = 0;
            this._stock = 0;
            this._idUsuario = 0;
        }

        public Producto(uint id, string descripcion, float costo, float precioVenta, int stock, uint idUsuario)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._costo = costo;
            this._precioVenta = precioVenta;
            this._stock = stock;
            this._idUsuario = idUsuario;
        }
    }
}