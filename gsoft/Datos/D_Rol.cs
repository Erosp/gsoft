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
    public class D_Rol
    {
        public DataTable ListarRoles(string busqueda)
        {
            NpgsqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            NpgsqlConnection SqlCon = new NpgsqlConnection();
            try
            {
                string query = "SELECT id as Id, nombre as Nombre, salario_hora AS Salario FROM rol WHERE status=true";
                if (!string.IsNullOrEmpty(busqueda))
                {
                    query += " AND nombre ILIKE '%" + busqueda + "%'";
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

        public string CrearRol(E_Rol oRol)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCon.Open();

                string Insert = "INSERT INTO rol (nombre, salario_hora) " +
                                "VALUES (@nombre, @salario)";

                NpgsqlCommand Comando = new NpgsqlCommand(Insert, SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@nombre", oRol.Nombre);
                Comando.Parameters.AddWithValue("@salario", oRol.Salario_Hora);

                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo registrar el usuario";
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

        public string ActualizarRol(E_Rol oRol)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                string query = "UPDATE rol SET nombre = @nombre, salario_hora = @salario WHERE id = @id";
                SqlCon = Conexion.getInstancia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand(query, SqlCon);
                Comando.Parameters.AddWithValue("@nombre", oRol.Nombre);
                Comando.Parameters.AddWithValue("@salario", oRol.Salario_Hora);
                Comando.Parameters.AddWithValue("@id", Guid.Parse(oRol.Id.ToString()));
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo desactivar el rol";
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

        public string DesactivarRol(string idRol)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                string query = "UPDATE rol SET status = false WHERE id = '" + idRol + "'";
                SqlCon = Conexion.getInstancia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo desactivar el rol";
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
