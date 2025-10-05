using gsoft.Forms.Modulos;
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
    public partial class FrmAppBase : Form
    {
        public FrmAppBase()
        {
            InitializeComponent();
        }

        private void imgCerrar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Estás seguro que quieres salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void imgMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            imgMaximizar.Visible = false;
            imgRestaurar.Visible = true;
        }

        private void imgRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            imgRestaurar.Visible = false;
            imgMaximizar.Visible = true;
        }

        private void imgMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void abrirHijo(object formHijo)
        {
            if (this.panelContent.Controls.Count > 0)
                this.panelContent.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(fh);
            this.panelContent.Tag = fh;
            fh.Show();
        }

        private void btnMenuCerrar_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void btnMenuProyecto_Click(object sender, EventArgs e)
        {
            abrirHijo(new FrmProyectos());
        }

        private void btnMenuUsuarios_Click(object sender, EventArgs e)
        {
            abrirHijo(new FrmUsuarios());
        }

        private void btnMenuRoles_Click(object sender, EventArgs e)
        {
            abrirHijo(new FrmRoles());
        }
    }
}
