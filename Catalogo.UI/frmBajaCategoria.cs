using Catalogo.Dominio;
using Catalogo.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo.UI
{
    public partial class frmBajaCategoria : Form
    {
        public frmBajaCategoria()
        {
            InitializeComponent();
        }
        private void frmBajaCategoria_Load(object sender, EventArgs e)
        {
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
            try
            {
                cboCategoria.DataSource = CategoriaNegocio.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Categoria aux = (Categoria)cboCategoria.SelectedItem;

            categoriaNegocio.Delete(aux);

            MessageBox.Show("Eliminado exitosamente");
            Close();
        }
    }
}
