using Catalogo.Dominio;
using Catalogo.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo.UI
{
    public partial class frmBajaMarca : Form
    {
        public frmBajaMarca()
        {
            InitializeComponent();
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca aux = (Marca)cboMarca.SelectedItem;

            marcaNegocio.Delete(aux);

            MessageBox.Show("Eliminado exitosamente");
            Close();
        }
        private void frmBajaMarca_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.Listar();
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
    }
}
