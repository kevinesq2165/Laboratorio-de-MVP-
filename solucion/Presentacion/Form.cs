
using Entidades;
using Negocio;
using Presentacion.Interfaces;
using Presentacion.Presentadores;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmlogin : Form, ILoginView
    {
        private P_Login presenter;

        public frmlogin()
        {
            InitializeComponent();

            presenter = new P_Login(this);

            
        }

        public string Usuario
        {
            get { return txtUsuario.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            presenter.IniciarSesion();
        }

        public void MostrarBienvenida(string nombreUsuario)
        {
            frmPrincipal principal = new frmPrincipal(nombreUsuario);

            principal.FormClosed += (s, e) => this.Close();

            this.Hide();
            principal.Show();
        }

        public void MostrarErrorLogin()
        {
            MessageBox.Show(
                "Usuario o contraseña incorrectos.",
                "Error de Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }
    }
}
