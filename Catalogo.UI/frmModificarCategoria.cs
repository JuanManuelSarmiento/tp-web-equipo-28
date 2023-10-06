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
    public partial class frmModificarCategoria : Form
    {
        public frmModificarCategoria()
        {
            InitializeComponent();
        }
        private void frmModificarCategoria_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                cboCategoria.DataSource = categoriaNegocio.Listar();
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
        private void btnAlta_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            categoria.Descripcion = cboCategoria.Text;
            //MessageBox.Show(" " + marca.Descripcion);

            string NuevaDesc = txtNuevaDescripcion.Text;
            //MessageBox.Show(" " + NuevaDesc);

            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("UPDATE CATEGORIAS SET Descripcion = @nuevaDescripcion WHERE Descripcion = @descripcion");
                datos.SetParametro("@nuevaDescripcion", NuevaDesc);
                datos.SetParametro("@descripcion", categoria.Descripcion);

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
    }
}
