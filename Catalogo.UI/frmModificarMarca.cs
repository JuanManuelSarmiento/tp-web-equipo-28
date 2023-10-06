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
    public partial class frmModificarMarca : Form
    {
        public frmModificarMarca()
        {
            InitializeComponent();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            marca.Descripcion = cboMarca.Text;
            //MessageBox.Show(" " + marca.Descripcion);

            string NuevaDesc = txtNuevaDescripcion.Text;
            //MessageBox.Show(" " + NuevaDesc);

            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("UPDATE MARCAS SET Descripcion = @nuevaDescripcion WHERE Descripcion = @descripcion");
                datos.SetParametro("@nuevaDescripcion", NuevaDesc);
                datos.SetParametro("@descripcion", marca.Descripcion);

                datos.EjecutarLectura();

                MessageBox.Show("Modificado exitosamente");

                Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        private void frmModificarMarca_Load(object sender, EventArgs e)
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
    }
}
