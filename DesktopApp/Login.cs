using Servicios;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        IAutenticacion autenticacion = new AutenticacionService();        

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var entrar = await autenticacion.Login(textBox1.Text, textBox2.Text);
            if (entrar != null)
            {
                index form = new();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
