using Catalogo.Common;
using Catalogo.Dominio;
using Catalogo.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo.UI
{
    public partial class frmAltaMarca : Form
    {
        private Marca marca = null;
        //private OpenFileDialog archivo = null;
        private bool esEdicion;
        private Validar validaciones;
        public frmAltaMarca()
        {
            InitializeComponent();
            esEdicion = false;
            validaciones = new Validar();
        }
        public frmAltaMarca(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
            esEdicion = true;
            Text = "Modificar Marca";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {

                if (marca == null)
                    marca = new Marca();

                marca.Descripcion = txtDescripcion.Text;

                if (esEdicion)
                {
                    marcaNegocio.Update(marca);
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

                    marcaNegocio.Add(marca);
                    marca = marcaNegocio.Listar().First();
                    marcaNegocio.Update(marca);

                    MessageBox.Show("Agregado exitosamente");
                }

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmAltaMarca_Load(object sender, EventArgs e)
        {
            //MarcaNegocio marca = new MarcaNegocio();
            try
            {
                //cboMarca.DataSource = marca.Listar();
                //cboMarca.ValueMember = "Id";
                //cboMarca.DisplayMember = "Descripcion";
                //cboCategoria.DataSource = categoria.Listar();
                //cboCategoria.ValueMember = "Id";
                //cboCategoria.DisplayMember = "Descripcion";

                if (esEdicion)
                {
                    txtDescripcion.Text = marca.Descripcion;
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
    }
}
