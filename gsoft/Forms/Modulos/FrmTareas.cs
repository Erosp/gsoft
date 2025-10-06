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
    public partial class FrmTareas : Form
    {
        public string idProyecto;
        public string nombreProyecto;

        public FrmTareas(string idProyecto, string nombreProyecto)
        {
            InitializeComponent();
            this.idProyecto = idProyecto;
            this.nombreProyecto = nombreProyecto;
        }

        public void limpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            dtpFechaLimite.Value = DateTime.Now;
            cbxPrioridad.SelectedIndex = -1; // No seleccionar ninguna prioridad
            cbxEstado.SelectedIndex = -1; // No seleccionar ningún estado
            txtHoras.Clear();
            cbxResponsable.SelectedIndex = -1; // No seleccionar ningún responsable
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

        private void ListarTareas(string busqueda)
        {
            try
            {
                D_Tarea Datos = new D_Tarea();
                tablaTareas.DataSource = Datos.ListarTareas(busqueda, idProyecto);
                tablaTareas.Columns["Id"].Visible = false;
                tablaTareas.Columns["ResponsableId"].Visible = false;
                tablaTareas.Columns["Editar"].DisplayIndex = tablaTareas.Columns.Count - 1;
                tablaTareas.Columns["Eliminar"].DisplayIndex = tablaTareas.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmTareas_Load(object sender, EventArgs e)
        {
            labelTitulo.Text = "Tareas del Proyecto: " + nombreProyecto;
            ListarUsuarios();
            ListarTareas("");
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cbxResponsable.SelectedIndex < 0 || dtpFechaLimite.Text.ToString() == "" || txtDescripcion.Text == "" || txtHoras.Text == "" || cbxEstado.SelectedIndex < 0 || cbxPrioridad.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(Convert.ToInt32(txtHoras.Text) <= 0)
            {
                MessageBox.Show("Por favor, ingrese un número válido de horas.", "Horas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string resp = "";
                E_Tarea oTarea = new E_Tarea();
                oTarea.Nombre = txtNombre.Text;
                oTarea.ResponsableId = cbxResponsable.SelectedValue.ToString();
                oTarea.FechaLimite = dtpFechaLimite.Value;
                oTarea.Horas = Convert.ToInt32(txtHoras.Text);
                oTarea.Estado = cbxEstado.SelectedItem.ToString();
                oTarea.Prioridad = cbxPrioridad.SelectedItem.ToString();
                oTarea.Descripcion = txtDescripcion.Text;
                oTarea.ProyectoId = idProyecto;

                D_Tarea Datos = new D_Tarea();
                resp = Datos.CrearTarea(oTarea);
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("Tarea creada con éxito", "Creación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    ListarTareas("");
                }
                else
                {
                    MessageBox.Show(resp, "Error al crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tablaTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string columna = tablaTareas.Columns[e.ColumnIndex].Name;

            DataGridViewRow fila = tablaTareas.Rows[e.RowIndex];

            string id = fila.Cells["Id"].Value?.ToString();
            string nombreTarea = fila.Cells["Nombre"].Value?.ToString();
            string descripcion = fila.Cells["Descripcion"].Value?.ToString();
            string fechaLimite = fila.Cells["Limite"].Value?.ToString();
            string horas = fila.Cells["Horas"].Value?.ToString();
            string estado = fila.Cells["Estado"].Value?.ToString();
            string prioridad = fila.Cells["Prioridad"].Value?.ToString();
            string responsable = fila.Cells["ResponsableId"].Value?.ToString();

            if (columna == "Editar")
            {
                txtNombre.Text = nombreProyecto;
                txtDescripcion.Text = descripcion;
                dtpFechaLimite.Value = DateTime.Parse(fechaLimite);
                txtHoras.Text = horas;
                cbxEstado.SelectedItem = estado;
                cbxPrioridad.SelectedItem = prioridad;
                cbxResponsable.SelectedValue = responsable;
                btnCrear.Visible = false;
                btnActualizar.Visible = true;
                btnActualizar.Tag = id;
                btnCancelar.Visible = true;
            }
            else if (columna == "Eliminar")
            {
                var result = MessageBox.Show("¿Estás seguro que quieres eliminar la tarea '" + nombreTarea + "'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    D_Tarea Datos = new D_Tarea();
                    string resp = Datos.DesactivarTarea(id);
                    if (resp.Equals("OK"))
                    {
                        MessageBox.Show("Tarea eliminada con éxito", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarTareas("");
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmAppBase padre = Application.OpenForms["FrmAppBase"] as FrmAppBase;
            padre?.abrirHijo(new FrmProyectos());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cbxResponsable.SelectedIndex < 0 || dtpFechaLimite.Text.ToString() == "" || txtDescripcion.Text == "" || txtHoras.Text == "" || cbxEstado.SelectedIndex < 0 || cbxPrioridad.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Convert.ToInt32(txtHoras.Text) <= 0)
            {
                MessageBox.Show("Por favor, ingrese un número válido de horas.", "Horas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string resp = "";
                E_Tarea oTarea = new E_Tarea();
                oTarea.Nombre = txtNombre.Text;
                oTarea.ResponsableId = cbxResponsable.SelectedValue.ToString();
                oTarea.FechaLimite = dtpFechaLimite.Value;
                oTarea.Horas = Convert.ToInt32(txtHoras.Text);
                oTarea.Estado = cbxEstado.SelectedItem.ToString();
                oTarea.Prioridad = cbxPrioridad.SelectedItem.ToString();
                oTarea.Descripcion = txtDescripcion.Text;
                oTarea.Id = btnActualizar.Tag.ToString();

                D_Tarea Datos = new D_Tarea();
                resp = Datos.ActualizarTarea(oTarea);
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("Tarea actualizada con éxito", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    btnCrear.Visible = true;
                    btnActualizar.Tag = null;
                    btnActualizar.Visible = false;
                    btnCancelar.Visible = false;
                    ListarTareas("");
                }
                else
                {
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            ListarTareas(txtBuscar.Text);
        }
    }
}
