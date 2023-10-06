
using Catalogo.Dominio;
using Catalogo.Negocio;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Catalogo.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Catalogo.UI
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        private bool esEdicion;
        private Validar validaciones;
        public frmAltaArticulo()
        {
            InitializeComponent();
            esEdicion = false;
            validaciones = new Validar();
            cbxImagen.Visible = false;
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            ImagenNegocio imagen = new ImagenNegocio();
            this.articulo = articulo;
            esEdicion = true;
            Text = "Modificar Artículo";
            txtImagen.Visible = false;
            btnAgregarImagen.Visible = false;
            
        }
        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            ImagenNegocio imagen = new ImagenNegocio();
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = marca.Listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoria.Listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                
                if (esEdicion)
                {
                    cbxImagen.DataSource = imagen.Listar(articulo);
                    cbxImagen.ValueMember = "ImagenUrl";
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    CargarImagen(cbxImagen.SelectedValue.ToString());
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    txtPrecio.Text = articulo.Precio.ToString();
                }
                else
                {
                    cboMarca.SelectedValue = -1;
                    cboCategoria.SelectedValue = -1;
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

        private bool validarAlta()
        {
            if(txtCodigo.Text.Length > 50) 
            {
                MessageBox.Show("El código puede tener un maximo de 50 caractéres.");
                return true;
            }
            if(txtNombre.Text.Length > 50) 
            {
                MessageBox.Show("El nombre puede tener un maximo de 50 caractéres.");
                return true;
            }
            if(txtDescripcion.Text.Length > 150)
            {
                MessageBox.Show("La descripción puede tener un maximo de 150 caractéres.");
                return true;
            }
            if(txtImagen.Text.Length > 1000)
            {
                MessageBox.Show("La ruta de la imagen puede tener un maximo de 1000 caractéres.");
                return true;
            }
            if (txtPrecio.Text.Length > 38)
            {
                MessageBox.Show("El precio puede tener un máximo de 38 dígitos.");
                return true;
            }

            return false;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            ImagenNegocio imgNegocio = new ImagenNegocio();
            if (validarAlta())
                return;
            try
            {
                
                if(articulo == null)
                    articulo = new Articulo();
                decimal.TryParse(txtPrecio.Text, out decimal auxPrecio);

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Precio = auxPrecio;

                if(esEdicion)
                {
                    artNegocio.Update(articulo);
                    artNegocio.UpdateImage(articulo, cbxImagen.SelectedValue.ToString());
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    if(validaciones.ValidarCbo(cboMarca.SelectedValue) && validaciones.ValidarCbo(cboCategoria.SelectedValue))
                        {
                        MessageBox.Show("El campo Marca y Categoria no pueden quedar vacios");
                        return;
                        }
                    if(string.IsNullOrEmpty(txtCodigo.Text))
                    {
                        MessageBox.Show("El campo Codigo no puede quedar vacio");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtNombre.Text))
                    {
                        MessageBox.Show("El campo Nombre no puede quedar vacio");
                        return;
                    }

                    artNegocio.Add(articulo);
                    articulo = artNegocio.Listar().First();
                    articulo.Imagen = new Imagen();
                    articulo.Imagen.IdArticulo = articulo.Id;
                    articulo.Imagen.ImagenUrl = txtImagen.Text;
                    imgNegocio.Add(articulo.Imagen);
                    artNegocio.Update(articulo);

                    MessageBox.Show("Agregado exitosamente");
                }

                //Guardo imagen si la levanto localmente
                if(archivo != null && !(txtImagen.Text.ToUpper().Contains("HTTP")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                }    
                
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void txtImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtImagen.Text);
        }
        private void CargarImagen(string Imagen)
        {
            try
            {
                pbxArticulo.Load(Imagen);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROGVlwDhbC-6RixbdgEwDrABJ6BD3hhM2eJA&usqp=CAU");
            }
        }
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "JPeg|*.JPeg;|jpg|*.jpg;|png|*.png";
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = archivo.FileName;
                CargarImagen(archivo.FileName);

                //guardo imagen
                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
            }
        }

        private void cbxImagen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbxImagen.SelectedItem.ToString();

            CargarImagen(opcion);
        }
    }
}
