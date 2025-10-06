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
    public class D_Tarea
    {
        public DataTable ListarTareas(string busqueda, string idProyecto)
        {
            NpgsqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                string query = @"
            SELECT 
                t.id AS Id,
                t.nombre AS Nombre,
                t.descripcion AS Descripcion,
                t.fecha_limite AS Limite,
                t.prioridad AS Prioridad,
                t.estado AS Estado,
                t.horas AS Horas,
                u.nombre AS Responsable,
                u.id AS ResponsableId,

                -- Costo por tarea
                COALESCE(t.horas * r.salario_hora, 0) AS Costo

            FROM tarea t
            INNER JOIN usuario u ON t.responsable_id = u.id
            LEFT JOIN rol r ON u.rol_id = r.id
            WHERE t.status = true AND t.proyecto_id = '" + idProyecto + "'";

                if (!string.IsNullOrEmpty(busqueda))
                {
                    query += " AND t.nombre ILIKE '%" + busqueda + "%'";
                }

                query += " ORDER BY t.fecha_limite ASC";

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

        public string CrearTarea(E_Tarea oTarea)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCon.Open();

                string Insert = "INSERT INTO tarea (nombre, descripcion, fecha_limite, horas, estado, prioridad, responsable_id, proyecto_id) " +
                                "VALUES (@nombre, @descripcion, @fecha_limite, @horas, @estado, @prioridad, @responsable_id, @proyecto_id)";

                NpgsqlCommand Comando = new NpgsqlCommand(Insert, SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@nombre", oTarea.Nombre);
                Comando.Parameters.AddWithValue("@descripcion", oTarea.Descripcion);
                Comando.Parameters.AddWithValue("@fecha_limite", oTarea.FechaLimite);
                Comando.Parameters.AddWithValue("@horas", oTarea.Horas);
                Comando.Parameters.AddWithValue("@estado", oTarea.Estado);
                Comando.Parameters.AddWithValue("@prioridad", oTarea.Prioridad);
                Comando.Parameters.AddWithValue("@responsable_id", Guid.Parse(oTarea.ResponsableId.ToString()));
                Comando.Parameters.AddWithValue("@proyecto_id", Guid.Parse(oTarea.ProyectoId.ToString()));

                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo crear la tarea";
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

        public string ActualizarTarea(E_Tarea oTarea)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCon.Open();

                string query = "UPDATE tarea SET nombre = @nombre, descripcion = @descripcion, fecha_limite = @fecha_limite, horas = @horas, estado = @estado, prioridad = @prioridad, responsable_id = @responsable_id WHERE id = @id";

                NpgsqlCommand Comando = new NpgsqlCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@nombre", oTarea.Nombre);
                Comando.Parameters.AddWithValue("@descripcion", oTarea.Descripcion);
                Comando.Parameters.AddWithValue("@fecha_limite", oTarea.FechaLimite);
                Comando.Parameters.AddWithValue("@horas", oTarea.Horas);
                Comando.Parameters.AddWithValue("@estado", oTarea.Estado);
                Comando.Parameters.AddWithValue("@prioridad", oTarea.Prioridad);
                Comando.Parameters.AddWithValue("@responsable_id", Guid.Parse(oTarea.ResponsableId.ToString()));
                Comando.Parameters.AddWithValue("@id", Guid.Parse(oTarea.Id.ToString()));

                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo actualizar la tarea";
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

        public string DesactivarTarea(string idTarea)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                string query = "UPDATE tarea SET status = false WHERE id = '" + idTarea + "'";
                SqlCon = Conexion.getInstancia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo desactivar la tarea";
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
