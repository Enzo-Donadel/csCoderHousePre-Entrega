namespace Enzo_Donadel
{
    public class Venta
    {
        private uint _id;
        private string _comentarios;
        private uint _idUsuario;

        public Venta()
        {
            this._id = 0;
            this._comentarios = string.Empty;
            this._idUsuario = 0;
        }

        public Venta(uint id, string comentarios, uint idUsuario)
        {
            this._id = id;
            this._comentarios = comentarios;
            this._idUsuario = idUsuario;
        }

        public uint Id { get => _id; set => _id = value; }
        public string Comentarios { get => _comentarios; set => _comentarios = value; }
        public uint IdUsuario { get => _idUsuario; set => _idUsuario = value; }
    }
}