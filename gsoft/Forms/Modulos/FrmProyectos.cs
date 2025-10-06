using gsoft.Datos;
using gsoft.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsoft.Forms.Modulos
{
    public partial class FrmProyectos : Form
    {
        public FrmProyectos()
        {
            InitializeComponent();
        }

        public void limpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            cbxResponsable.SelectedIndex = -1; // No seleccionar ningún responsable
        }

        private void ListarProyectos(string busqueda)
        {
            try
            {
                D_Proyecto Datos = new D_Proyecto();
                tablaProyectos.DataSource = Datos.ListarProyectos(busqueda);
                tablaProyectos.Columns["Id"].Visible = false;
                tablaProyectos.Columns["ResponsableId"].Visible = false;
                tablaProyectos.Columns["Tareas"].DisplayIndex = tablaProyectos.Columns.Count - 1;
                tablaProyectos.Columns["Editar"].DisplayIndex = tablaProyectos.Columns.Count - 1;
                tablaProyectos.Columns["Eliminar"].DisplayIndex = tablaProyectos.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ListarUsuarios()
        {
            try
            {
                D_Usuario Datos = new D_Usuario();
                cbxResponsable.DataSource = Datos.ListarUsuarios("");
                cbxResponsable.ValueMember = "Id";
                cbxResponsable.DisplayMember = "Nombre";
                cbxResponsable.SelectedIndex = -1; // No seleccionar ningún usuario por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmProyectos_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
            ListarProyectos("");
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cbxResponsable.SelectedIndex < 0 || dtpFechaInicio.Text.ToString() == "" || dtpFechaFin.Text.ToString() == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (dtpFechaFin.Value < dtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string resp = "";
                E_Proyecto oProyecto = new E_Proyecto();
                oProyecto.Nombre = txtNombre.Text;
                oProyecto.ResponsableId = cbxResponsable.SelectedValue.ToString();
                oProyecto.FechaInicio = dtpFechaInicio.Value;
                oProyecto.FechaFin = dtpFechaFin.Value;
                oProyecto.Descripcion = txtDescripcion.Text;

                D_Proyecto Datos = new D_Proyecto();
                resp = Datos.CrearProyecto(oProyecto);
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("Proyecto creado con éxito", "Creación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    ListarProyectos("");
                }
                else
                {
                    MessageBox.Show(resp, "Error al crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tablaProyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string columna = tablaProyectos.Columns[e.ColumnIndex].Name;

            DataGridViewRow fila = tablaProyectos.Rows[e.RowIndex];

            string id = fila.Cells["Id"].Value?.ToString();
            string nombreProyecto = fila.Cells["Nombre"].Value?.ToString();
            string descripcion = fila.Cells["Descripcion"].Value?.ToString();
            string fechaInicio = fila.Cells["Inicio"].Value?.ToString();
            string fechaFin = fila.Cells["Fin"].Value?.ToString();
            string responsable = fila.Cells["ResponsableId"].Value?.ToString();

            if (columna == "Editar")
            {
                txtNombre.Text = nombreProyecto;
                txtDescripcion.Text = descripcion;
                dtpFechaInicio.Value = DateTime.Parse(fechaInicio);
                dtpFechaFin.Value = DateTime.Parse(fechaFin);
                cbxResponsable.SelectedValue = responsable;
                btnCrear.Visible = false;
                btnActualizar.Visible = true;
                btnActualizar.Tag = id;
                btnCancelar.Visible = true;
            }
            else if (columna == "Tareas")
            {
                FrmAppBase padre = Application.OpenForms["FrmAppBase"] as FrmAppBase;
                padre?.abrirHijo(new FrmTareas(id, nombreProyecto));
            }
            else if (columna == "Eliminar")
            {
                var result = MessageBox.Show("¿Estás seguro que quieres eliminar el proyecto '" + nombreProyecto + "'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    D_Proyecto Datos = new D_Proyecto();
                    string resp = Datos.DesactivarProyecto(id);
                    if (resp.Equals("OK"))
                    {
                        MessageBox.Show("Proyecto eliminado con éxito", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarProyectos("");
                    }
                    else
                    {
                        MessageBox.Show(resp, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            btnCrear.Visible = true;
            btnActualizar.Tag = null;
            btnActualizar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cbxResponsable.SelectedIndex < 0 || dtpFechaInicio.Text.ToString() == "" || dtpFechaFin.Text.ToString() == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (dtpFechaFin.Value < dtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string resp = "";
                E_Proyecto oProyecto = new E_Proyecto();
                oProyecto.Nombre = txtNombre.Text;
                oProyecto.Descripcion = txtDescripcion.Text;
                oProyecto.FechaInicio = dtpFechaInicio.Value;
                oProyecto.FechaFin = dtpFechaFin.Value;
                oProyecto.ResponsableId = cbxResponsable.SelectedValue.ToString();
                oProyecto.Id = btnActualizar.Tag.ToString();

                D_Proyecto Datos = new D_Proyecto();
                resp = Datos.ActualizarProyecto(oProyecto);
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("Proyecto actualizado con éxito", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    btnCrear.Visible = true;
                    btnActualizar.Tag = null;
                    btnActualizar.Visible = false;
                    btnCancelar.Visible = false;
                    ListarProyectos("");
                }
                else
                {
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            ListarProyectos(txtBuscar.Text);
        }
    }
}
