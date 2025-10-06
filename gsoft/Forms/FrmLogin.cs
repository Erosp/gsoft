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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Estás seguro que quieres salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void labelRegistrarse_Click(object sender, EventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro();
            this.Hide();
            frmRegistro.Show();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtClave.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                E_Usuario oUsuario = new E_Usuario();
                D_Usuario Datos = new D_Usuario();
                oUsuario = Datos.Login(txtUsuario.Text, txtClave.Text);
                if (oUsuario != null)
                {
                    FrmAppBase frmAppBase = new FrmAppBase();
                    this.Hide();
                    frmAppBase.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o clave incorrectos", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
