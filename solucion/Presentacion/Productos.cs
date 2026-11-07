using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            CargarProductos();
        }
        private void CargarProductos()
        {
            dgvProductos.AutoGenerateColumns = true;

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = N_Producto.ListarProductos();

            if (dgvProductos.Columns["imagen"] != null)
            {
                dgvProductos.Columns["imagen"].Visible = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
