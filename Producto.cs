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

        public uint Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public float Costo { get => _costo; set => _costo = value; }
        public float PrecioVenta { get => _precioVenta; set => _precioVenta = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public uint IdUsuario { get => _idUsuario; set => _idUsuario = value; }
    }
}