using Catalogo.Common;
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
    public partial class frmAltaCategoria : Form
    {
        private Categoria categoria = null;
        //private OpenFileDialog archivo = null;
        private bool esEdicion;
        private Validar validaciones;
        public frmAltaCategoria()
        {
            InitializeComponent();
            esEdicion = false;
            validaciones = new Validar();
        }
        public frmAltaCategoria(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            esEdicion = true;
            Text = "Modificar Categoria";
        }
        private void frmAltaCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                if (esEdicion)
                {
                    txtDescripcion.Text = categoria.Descripcion;
                }
                else
                {
                    txtDescripcion.Text = " ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {

                if (categoria == null)
                    categoria = new Categoria();

                categoria.Descripcion = txtDescripcion.Text;

                if (esEdicion)
                {
                    categoriaNegocio.Update(categoria);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    //-------------
                    //COMPROBAR!!!
                    if (string.IsNullOrEmpty(txtDescripcion.Text))
                    {
                        MessageBox.Show("El campo Descripcion no puede quedar vacio");
                        return;
                    }
                    //-------------

                    categoriaNegocio.Add(categoria);
                    categoria = categoriaNegocio.Listar().First();
                    categoriaNegocio.Update(categoria);

                    MessageBox.Show("Agregado exitosamente");
                }

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
