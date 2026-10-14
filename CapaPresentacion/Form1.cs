using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        N_Usuario n_Usuario = new N_Usuario();
        public static E_Usuarios e_Usuario1 = new E_Usuarios();

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load); // Suscripción al evento Load
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código para inicializar el formulario, si es necesario.
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            // Manejo de cambios en el textbox, si es necesario
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El campo Usuario no puede estar vacío");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("El campo Password no puede estar vacío");
                txtPassword.Focus();
                return;
            }

            try
            {
                string usuario = txtUsuario.Text;
                string contrasena = txtPassword.Text;

                // Intentar obtener el usuario desde la base de datos
                e_Usuario1 = n_Usuario.usuarioLoginN(usuario, contrasena);

                if (e_Usuario1 != null && usuario.Equals(e_Usuario1.CodUsuario) && contrasena.Equals(e_Usuario1.Password))
                {
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Las credenciales no son correctas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante el inicio de sesión: " + ex.Message);
            }
        }
    }
}
