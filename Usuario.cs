namespace Enzo_Donadel
{
    public class Usuario
    {
        private uint _id;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contraseña;
        private string _mail;

        public Usuario()
        {
            this._id = 0;
            this._nombre = string.Empty;
            this._apellido = string.Empty;
            this._nombreUsuario = string.Empty;
            this._contraseña = string.Empty;
            this._mail = string.Empty;
        }

        public Usuario(uint id, string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._nombreUsuario = nombreUsuario;
            this._contraseña = contraseña;
            this._mail = mail;
        }
    }
}