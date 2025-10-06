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
    public class D_Proyecto
    {
        public DataTable ListarProyectos(string busqueda)
        {
            NpgsqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                string query = @"
            SELECT 
                p.id AS Id,
                p.nombre AS Nombre,
                p.descripcion AS Descripcion,
                p.fecha_inicio AS Inicio,
                p.fecha_fin AS Fin,
                u.nombre AS Responsable,
                u.id AS ResponsableId,

                -- Costo total del proyecto (solo tareas activas)
                COALESCE(SUM(
                    CASE WHEN t.status = true THEN t.horas * r.salario_hora ELSE 0 END
                ), 0) AS Costo,

                -- Porcentaje de tareas completadas (solo tareas activas)
                COALESCE(
                    ROUND(
                        COUNT(*) FILTER (WHERE t.status = true AND t.estado = 'Completado')::decimal 
                        / NULLIF(COUNT(*) FILTER (WHERE t.status = true), 0) * 100, 2
                    ), 0
                ) AS Porcentaje_Completado

            FROM proyecto p
            INNER JOIN usuario u ON p.responsable_id = u.id
            LEFT JOIN tarea t ON t.proyecto_id = p.id
            LEFT JOIN usuario ut ON t.responsable_id = ut.id
            LEFT JOIN rol r ON ut.rol_id = r.id
            WHERE p.status = true";

                if (!string.IsNullOrEmpty(busqueda))
                {
                    query += " AND p.nombre ILIKE '%" + busqueda + "%'";
                }

                query += @"
            GROUP BY p.id, p.nombre, p.descripcion, p.fecha_inicio, p.fecha_fin, u.nombre, u.id
            ORDER BY p.fecha_inicio DESC";

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

        public string CrearProyecto(E_Proyecto oProyecto)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCon.Open();

                string Insert = "INSERT INTO proyecto (nombre, descripcion, fecha_inicio, fecha_fin, responsable_id) " +
                                "VALUES (@nombre, @descripcion, @fecha_inicio, @fecha_fin, @responsable_id)";

                NpgsqlCommand Comando = new NpgsqlCommand(Insert, SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@nombre", oProyecto.Nombre);
                Comando.Parameters.AddWithValue("@descripcion", oProyecto.Descripcion);
                Comando.Parameters.AddWithValue("@fecha_inicio", oProyecto.FechaInicio);
                Comando.Parameters.AddWithValue("@fecha_fin", oProyecto.FechaFin);
                Comando.Parameters.AddWithValue("@responsable_id", Guid.Parse(oProyecto.ResponsableId.ToString()));

                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo crear el proyecto";
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

        public string ActualizarProyecto(E_Proyecto oProyecto)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCon.Open();

                string query = "UPDATE proyecto SET nombre = @nombre, descripcion = @descripcion, fecha_inicio = @fecha_inicio, fecha_fin = @fecha_fin, responsable_id = @responsable_id WHERE id = @id";

                NpgsqlCommand Comando = new NpgsqlCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@nombre", oProyecto.Nombre);
                Comando.Parameters.AddWithValue("@descripcion", oProyecto.Descripcion);
                Comando.Parameters.AddWithValue("@fecha_inicio", oProyecto.FechaInicio);
                Comando.Parameters.AddWithValue("@fecha_fin", oProyecto.FechaFin);
                Comando.Parameters.AddWithValue("@responsable_id", Guid.Parse(oProyecto.ResponsableId.ToString()));
                Comando.Parameters.AddWithValue("@id", Guid.Parse(oProyecto.Id.ToString()));

                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo actualizar el proyecto";
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

        public string DesactivarProyecto(string idProyecto)
        {
            string resp = "";
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                string query = "UPDATE proyecto SET status = false WHERE id = '" + idProyecto + "'";
                SqlCon = Conexion.getInstancia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                resp = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo desactivar el proyecto";
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
