namespace Enzo_Donadel
{
    public class ProductoVendido
    {
        private uint _id;
        private uint _idProducto;
        private int _stock;
        private uint _idVenta;

        public ProductoVendido()
        {
            this._id = 0;
            this._idProducto = 0;
            this._stock = 0;
            this._idVenta = 0;
        }

        public ProductoVendido(uint id, uint idProducto, int stock, uint idVenta)
        {
            this._id = id;
            this._idProducto = idProducto;
            this._stock = stock;
            this._idVenta = idVenta;
        }

        public uint Id { get => _id; set => _id = value; }
        public uint IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public uint IdVenta { get => _idVenta; set => _idVenta = value; }
    }
}