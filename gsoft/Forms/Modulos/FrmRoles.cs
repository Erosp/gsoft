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
    public partial class FrmRoles : Form
    {
        public FrmRoles()
        {
            InitializeComponent();
        }

        public void limpiarCampos()
        {
            txtNombre.Clear();
            txtSalario.Clear();
        }

        private void ListarRoles(string busqueda)
        {
            try { 
                D_Rol Datos = new D_Rol();
                tablaRoles.DataSource = Datos.ListarRoles(busqueda);
                tablaRoles.Columns["Id"].Visible = false;
                tablaRoles.Columns["Editar"].DisplayIndex = tablaRoles.Columns.Count - 1;
                tablaRoles.Columns["Eliminar"].DisplayIndex = tablaRoles.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {
            ListarRoles("");
        }

        private void tablaRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string columna = tablaRoles.Columns[e.ColumnIndex].Name;

            DataGridViewRow fila = tablaRoles.Rows[e.RowIndex];

            string id = fila.Cells["Id"].Value?.ToString();
            string nombreRol = fila.Cells["Nombre"].Value?.ToString();
            string salario = fila.Cells["Salario"].Value?.ToString();

            if (columna == "Editar")
            {
                txtNombre.Text = nombreRol;
                txtSalario.Text = salario;
                btnCrear.Visible = false;
                btnActualizar.Visible = true;
                btnActualizar.Tag = id; // Guardar el ID del rol en el botón Actualizar
                btnCancelar.Visible = true;
            }
            else if(columna == "Eliminar")
            {
                var result = MessageBox.Show("¿Estás seguro que quieres eliminar el rol '" + nombreRol + "'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    D_Rol Datos = new D_Rol();
                    string resp = Datos.DesactivarRol(id);
                    if (resp.Equals("OK"))
                    {
                        MessageBox.Show("Rol eliminado con éxito", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarRoles("");
                    }
                    else
                    {
                        MessageBox.Show(resp, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtSalario.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string resp = "";
                E_Rol oRol = new E_Rol();
                oRol.Nombre = txtNombre.Text;

                decimal salario;
                if (decimal.TryParse(txtSalario.Text, out salario))
                {
                    oRol.Salario_Hora = salario;
                }
                else
                {
                    MessageBox.Show("Por favor, introduzca un salario correcto.", "Salario invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                D_Rol Datos = new D_Rol();
                resp = Datos.CrearRol(oRol);
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("Rol creado con éxito", "Creación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    ListarRoles("");
                }
                else
                {
                    MessageBox.Show(resp, "Error al crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtNombre.Text == "" || txtSalario.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string resp = "";
                E_Rol oRol = new E_Rol();
                oRol.Nombre = txtNombre.Text;
                oRol.Id = btnActualizar.Tag.ToString();

                decimal salario;
                if (decimal.TryParse(txtSalario.Text, out salario))
                {
                    oRol.Salario_Hora = salario;
                }
                else
                {
                    MessageBox.Show("Por favor, introduzca un salario correcto.", "Salario invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                D_Rol Datos = new D_Rol();
                resp = Datos.ActualizarRol(oRol);
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("Rol actualizado con éxito", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    btnCrear.Visible = true;
                    btnActualizar.Tag = null;
                    btnActualizar.Visible = false;
                    btnCancelar.Visible = false;
                    ListarRoles("");
                }
                else
                {
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            ListarRoles(txtBuscar.Text);
        }
    }
}
