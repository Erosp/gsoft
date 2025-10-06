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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        public void limpiarCampos()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            cbxRol.SelectedIndex = -1; // No seleccionar ningún rol
        }

        private void ListarUsuarios(string busqueda)
        {
            try
            {
                D_Usuario Datos = new D_Usuario();
                tablaUsuarios.DataSource = Datos.ListarUsuarios(busqueda);
                tablaUsuarios.Columns["Id"].Visible = false;
                tablaUsuarios.Columns["RolId"].Visible = false;
                tablaUsuarios.Columns["Editar"].DisplayIndex = tablaUsuarios.Columns.Count - 1;
                tablaUsuarios.Columns["Eliminar"].DisplayIndex = tablaUsuarios.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ListarRoles()
        {
            try
            {
                D_Rol Datos = new D_Rol();
                cbxRol.DataSource = Datos.ListarRoles("");
                cbxRol.ValueMember = "Id";
                cbxRol.DisplayMember = "Nombre";
                cbxRol.SelectedIndex = -1; // No seleccionar ningún rol por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            ListarRoles();
            ListarUsuarios("");
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtUsuario.Text == "" || txtClave.Text == "" || cbxRol.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string resp = "";
                E_Usuario oUsuario = new E_Usuario();
                oUsuario.Nombre = txtNombre.Text;
                oUsuario.Usuario = txtUsuario.Text;
                oUsuario.Clave = txtClave.Text;
                oUsuario.RolId = cbxRol.SelectedValue.ToString();

                D_Usuario Datos = new D_Usuario();
                resp = Datos.CrearUsuario(oUsuario);
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("Usuario creado con éxito", "Creación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    ListarUsuarios("");
                }
                else
                {
                    MessageBox.Show(resp, "Error al crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tablaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string columna = tablaUsuarios.Columns[e.ColumnIndex].Name;

            DataGridViewRow fila = tablaUsuarios.Rows[e.RowIndex];

            string id = fila.Cells["Id"].Value?.ToString();
            string nombreUsuario = fila.Cells["Nombre"].Value?.ToString();
            string usuario = fila.Cells["Usuario"].Value?.ToString();
            string rol = fila.Cells["RolId"].Value?.ToString();

            if (columna == "Editar")
            {
                txtNombre.Text = nombreUsuario;
                txtUsuario.Text = usuario;
                cbxRol.SelectedValue = rol;
                txtClave.Clear();
                txtClave.Enabled = false;
                txtUsuario.Enabled = false;
                btnCrear.Visible = false;
                btnActualizar.Visible = true;
                btnActualizar.Tag = id;
                btnCancelar.Visible = true;
            }
            else if (columna == "Eliminar")
            {
                var result = MessageBox.Show("¿Estás seguro que quieres eliminar el usuario '" + nombreUsuario + "'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    D_Usuario Datos = new D_Usuario();
                    string resp = Datos.DesactivarUsuario(id);
                    if (resp.Equals("OK"))
                    {
                        MessageBox.Show("Usuario eliminado con éxito", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarUsuarios("");
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
            txtClave.Enabled = true;
            txtUsuario.Enabled = true;
            btnCrear.Visible = true;
            btnActualizar.Tag = null;
            btnActualizar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cbxRol.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string resp = "";
                E_Usuario oUsuario = new E_Usuario();
                oUsuario.Nombre = txtNombre.Text;
                oUsuario.RolId = cbxRol.SelectedValue.ToString();
                oUsuario.Id = btnActualizar.Tag.ToString();

                D_Usuario Datos = new D_Usuario();
                resp = Datos.ActualizarUsuario(oUsuario);
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("Usuario actualizado con éxito", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    txtClave.Enabled = true;
                    txtUsuario.Enabled = true;
                    btnCrear.Visible = true;
                    btnActualizar.Tag = null;
                    btnActualizar.Visible = false;
                    btnCancelar.Visible = false;
                    ListarUsuarios("");
                }
                else
                {
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            ListarUsuarios(textBuscar.Text);
        }
    }
}
