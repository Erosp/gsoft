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
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCon.Open();

                // 1. Buscar el ID del rol "Estandar"
                string queryRol = "SELECT id FROM rol WHERE nombre = 'Estandar' LIMIT 1";
                NpgsqlCommand cmdRol = new NpgsqlCommand(queryRol, SqlCon);
                object rolIdObj = cmdRol.ExecuteScalar();

                if (rolIdObj == null)
                {
                    resp = "No se encontró el rol 'Estandar'";
                }
                else
                {
                    Guid rolId = (Guid)rolIdObj;

                    // 2. Insertar el usuario con el rol_id
                    string Insert = "INSERT INTO usuario (nombre, usuario, clave, rol_id) " +
                                    "VALUES (@nombre, @usuario, @clave, @rol_id)";

                    NpgsqlCommand Comando = new NpgsqlCommand(Insert, SqlCon);
                    Comando.CommandType = CommandType.Text;
                    Comando.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                    Comando.Parameters.AddWithValue("@usuario", oUsuario.Usuario);
                    Comando.Parameters.AddWithValue("@clave", claveHash);
                    Comando.Parameters.AddWithValue("@rol_id", rolId);

                    resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo registrar el usuario";
                }
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
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

        public DataTable ListarUsuarios(string busqueda)
        {
            NpgsqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            NpgsqlConnection SqlCon = new NpgsqlConnection();
            try
            {
                string query = "SELECT u.id as Id, u.nombre as Nombre, u.usuario AS Usuario, r.nombre AS Rol, r.id AS RolId FROM usuario u INNER JOIN rol r ON u.rol_id = r.id WHERE u.status=true";
                if (!string.IsNullOrEmpty(busqueda))
                {
                    query += " AND u.nombre ILIKE '%" + busqueda + "%'";
                }
                SqlCon = Conexion.getInstancia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public string CrearUsuario(E_Usuario oUsuario)
        {
            string resp = "";
            string claveHash = Seguridad.HashSHA256(oUsuario.Clave);
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCon.Open();

                string Insert = "INSERT INTO usuario (nombre, usuario, clave, rol_id) " +
                                "VALUES (@nombre, @usuario, @clave, @rol_id)";

                NpgsqlCommand Comando = new NpgsqlCommand(Insert, SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                Comando.Parameters.AddWithValue("@usuario", oUsuario.Usuario);
                Comando.Parameters.AddWithValue("@clave", claveHash);
                Comando.Parameters.AddWithValue("@rol_id", Guid.Parse(oUsuario.RolId.ToString()));

                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo crear el usuario";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

        public string ActualizarUsuario(E_Usuario oUsuario)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCon.Open();

                string query = "UPDATE usuario SET nombre = @nombre, rol_id = @rol_id WHERE id = @id";

                NpgsqlCommand Comando = new NpgsqlCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                Comando.Parameters.AddWithValue("@rol_id", Guid.Parse(oUsuario.RolId.ToString()));
                Comando.Parameters.AddWithValue("@id", Guid.Parse(oUsuario.Id.ToString()));

                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo actualizar el usuario";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

        public string DesactivarUsuario(string idUsuario)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                string query = "UPDATE usuario SET status = false WHERE id = '" + idUsuario + "'";
                SqlCon = Conexion.getInstancia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo desactivar el usuario";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

    }

}
