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

namespace gsoft.Forms
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtNombre.Text == "" || txtClave.Text == "")
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

                D_Usuario Datos = new D_Usuario();
                resp = Datos.Registrar(oUsuario);
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("Usuario registrado con éxito", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Text = "";
                    txtUsuario.Text = "";
                    txtClave.Text = "";
                }
                else
                {
                    MessageBox.Show(resp, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Estás seguro que quieres salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.Show();
        }
    }
}
