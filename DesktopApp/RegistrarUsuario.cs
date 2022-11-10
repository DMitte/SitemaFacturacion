using Entidades;
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
    public partial class RegistrarUsuario : Form
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        ICliente clienteService = new ClienteService();
        private async void button1_Click(object sender, EventArgs e)
        {
            Cliente client = new();
            client.CliCedula = textBox1.Text;
            client.CliApellidos = textBox2.Text;
            client.CliNombres = textBox3.Text;
            client.CliDireccion = textBox4.Text;
            client.CliFechaNacimiento = dateTimePicker1.Text;
            client.CliTelefono = textBox5.Text;
            client.CliMail = textBox6.Text;
            client.CliPassword = textBox7.Text;

            await clienteService.CreateClient(client);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= 32 && e.KeyChar <= 47) ||(e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se aceptan numeros", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }
    }
}
