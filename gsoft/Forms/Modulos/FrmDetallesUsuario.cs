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
    public partial class FrmDetallesUsuario : Form
    {
        public string idUsuario;
        public string nombreUsuario;

        public FrmDetallesUsuario(string idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmAppBase padre = Application.OpenForms["FrmAppBase"] as FrmAppBase;
            padre?.abrirHijo(new FrmUsuarios());
        }

        private void FrmDetallesUsuario_Load(object sender, EventArgs e)
        {
            labelTitulo.Text = "Detalles de: " + nombreUsuario;
            ListarTotalDetalles();
            ListarDetallesUsuario();
        }

        private void ListarDetallesUsuario()
        {
            try
            {
                D_Usuario Datos = new D_Usuario();
                tablaDetalles.DataSource = Datos.ListarDetallesUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ListarTotalDetalles()
        {
            try
            {
                D_Usuario Datos = new D_Usuario();
                DataTable tabla = Datos.ListarTotalDetalles(idUsuario);

                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];

                    int totalProyectos = Convert.ToInt32(fila["total_proyectos"]);
                    decimal totalHoras = Convert.ToDecimal(fila["total_horas"]);
                    decimal totalIngreso = Convert.ToDecimal(fila["total_ingreso"]);

                    // Aquí puedes usar los valores como quieras:
                    labelTotalProyectos.Text = totalProyectos.ToString();
                    labelTotalHoras.Text = totalHoras.ToString("N2");
                    labelTotalIngresos.Text = "$" + totalIngreso.ToString("N2");
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para este usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
