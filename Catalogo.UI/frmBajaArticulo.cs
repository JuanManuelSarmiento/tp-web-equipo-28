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
    public partial class frmBajaArticulo : Form
    {
        public frmBajaArticulo()
        {
            InitializeComponent();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            // string codigoSeleccionado = cboNombre.SelectedItem.ToString());

            Articulo aux = (Articulo)cboNombre.SelectedItem;

            artNegocio.Delete(aux);

            MessageBox.Show("Eliminado exitosamente");
            Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmBajaArticulo_Load(object sender, EventArgs e)
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            try
            {
                cboNombre.DataSource = artNegocio.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
