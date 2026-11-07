using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            ActualizarReloj();
            lblUsuarioSesion.Text = "Usuario: Invitado";
        }
        public frmPrincipal(string nombreUsuario) : this()
        {
            lblUsuarioSesion.Text = "Usuario: " + nombreUsuario;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsmg, int wparam, int lparam);

        private void ActualizarReloj()
        {
            DateTime ahora = DateTime.Now;

            lblHora.Text = ahora.ToString("HH:mm:ss");

            lblFecha.Text = ahora.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy",
                new System.Globalization.CultureInfo("es-PA")
            );
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 250;
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Maximized;
            iconRestaurar.Visible = true;
            iconMaximizar.Visible = false;
        }

        private void iconRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconRestaurar.Visible = false;
            iconMaximizar.Visible = true;
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormInPanel(Form Formhijo)
        {
            // Cerrar los formularios anteriores
            for (int i = panelContenedor.Controls.Count - 1; i >= 0; i--)
            {
                if (panelContenedor.Controls[i] is Form)
                {
                    Form formularioAnterior = (Form)panelContenedor.Controls[i];
                    formularioAnterior.Close();
                }
            }

            // Configurar el formulario hijo
            Formhijo.TopLevel = false;
            Formhijo.FormBorderStyle = FormBorderStyle.None;
            Formhijo.Dock = DockStyle.Fill;

            // Agregarlo al panel
            panelContenedor.Controls.Add(Formhijo);
            panelContenedor.Tag = Formhijo;

            // Mostrarlo
            Formhijo.Show();
            Formhijo.BringToFront();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Productos());
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            ActualizarReloj();
        }
    }
}
