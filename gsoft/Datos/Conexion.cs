using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsoft.Datos
{
    public class Conexion
    {
        private string BaseDatos;
        private string Servidor;
        private string Puerto;
        private string Usuario;
        private string Clave;

        private static Conexion Con = null;

        public Conexion()
        {
            this.BaseDatos = "gsoft";
            this.Servidor = "localhost";
            this.Puerto = "5432";
            this.Usuario = "postgres";
            this.Clave = "fff256";
        }

        public NpgsqlConnection CrearConexion()
        {
            NpgsqlConnection Cadena = new NpgsqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + ";Port=" + this.Puerto + ";User Id=" + this.Usuario + ";Password=" + this.Clave + ";Database=" + this.BaseDatos + ";";
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
