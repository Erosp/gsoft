using gsoft.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsoft.Datos
{
    public class D_Usuario
    {
        public string Registrar(E_Usuario oUsuario)
        {
            string resp = "";
            string claveHash = Seguridad.HashSHA256(oUsuario.Clave);
            string Insert = "INSERT INTO usuario (nombre, usuario, clave) VALUES ('" + oUsuario.Nombre + "','" + oUsuario.Usuario + "','" + claveHash + "')";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand(Insert, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo registrar el usuario";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                //if (SqlCon.State == System.Data.ConnectionState.Open) SqlCon.Close();
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

        public E_Usuario Login(string usuario, string clave)
        {
            E_Usuario oUsuario = null;
            string claveHash = Seguridad.HashSHA256(clave);
            string query = "SELECT id, nombre, usuario FROM usuario WHERE usuario = @usuario AND clave = @clave";

            using (NpgsqlConnection SqlCon = Conexion.getInstancia().CrearConexion())
            {
                try
                {
                    SqlCon.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, SqlCon))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@clave", claveHash);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oUsuario = new E_Usuario
                                {
                                    Id = reader.GetGuid(0).ToString(),
                                    Nombre = reader.GetString(1),
                                    Usuario = reader.GetString(2)
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Puedes loguear el error o lanzar una excepción personalizada
                    throw new Exception("Error al intentar iniciar sesión: " + ex.Message);
                }
            }

            return oUsuario; // Si es null, el login falló
        }

    }
}
