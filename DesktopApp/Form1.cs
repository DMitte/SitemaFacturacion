using Entidades;
using Servicios;
using Servicios.Interfaces;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mostrasCategorias();
        }
        ICategoria categoriaSvc = new CategoriaService();

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            //ICategoria categoriaSvc = new CategoriaService();
            Categorium categoria = new();            
            categoria.CatNombre = txtCategoria.Text.Trim();
            categoria.CatDescripcion = txtDescrpcion.Text.Trim();
            await categoriaSvc.CreateCategoria(categoria);            
            mostrasCategorias();
        }

        private async void mostrasCategorias() {
           // ICategoria categoriaSvc = new CategoriaService();
            dgvCategoria.DataSource = await categoriaSvc.GetAllCategorias();
            
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.dgvCategoria.SelectedRows[0].Cells[0].Value);
            await categoriaSvc.DeleteCategoria(id);
            mostrasCategorias();
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCategoria.Text = Convert.ToString(this.dgvCategoria.SelectedRows[0].Cells[1].Value);
            txtDescrpcion.Text = Convert.ToString(this.dgvCategoria.SelectedRows[0].Cells[2].Value);           
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.dgvCategoria.SelectedRows[0].Cells[0].Value);
            string nombre = txtCategoria.Text;
            string descrip = txtDescrpcion.Text;

            Categorium pro = new Categorium();
            pro.CatCodigo = id;
            pro.CatNombre = nombre;
            pro.CatDescripcion = descrip;

            await categoriaSvc.UpdateCategoria(pro);
            mostrasCategorias();
            txtCategoria.Text = "";
            txtDescrpcion.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.Show();
        }
    }
}