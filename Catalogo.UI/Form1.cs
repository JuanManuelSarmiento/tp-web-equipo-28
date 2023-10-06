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
using Catalogo.Dominio;
using Catalogo.Negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Catalogo.UI
{
    public partial class frmArticulos : Form
    {
        private List<Articulo> listaArticulo;
        public frmArticulos()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            cargar();
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");
            cboCampo.Items.Add("Precio");

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            cbxImagen.DataSource = articuloNegocio.Listar();
        }
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                CargarImagen(seleccionado.Imagen.ImagenUrl);
            }
        }
        private void cbxImagen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Articulo articulo = new Articulo();

            //Articulo seleccionado = (Articulo)cbxImagen.SelectedItem;
            //CargarImagen(seleccionado.Imagen.ImagenUrl);
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
        private void cargar()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                listaArticulo = articuloNegocio.Listar();
                dgvArticulos.DataSource = listaArticulo;
                ocultarColumnas();
                dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                int cantFilas = dgvArticulos.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultarColumnas()
        {
            dgvArticulos.Columns["id"].Visible = false;
            dgvArticulos.Columns["Imagen"].Visible = false;
        }
        private bool validarFiltro()
        {
            if(cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un campo para filtar.");
                return true;
            }
            if(cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un criterio para filtar.");
                return true;
            }
            if(txtFiltroAvanzado.Text.Length == 0)
            {
                MessageBox.Show("Debe cargar el filtro para la búsqueda.");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio" )
            {
                if(txtFiltroAvanzado.Text.Length>38)
                {
                    MessageBox.Show("Solo puede cargar hasta 38 dígitos.");
                    return true;
                }
                if(string.IsNullOrEmpty(txtFiltroAvanzado.Text)) 
                {
                    MessageBox.Show("Debe cargar el filtro para numéricos.");
                    return true;
                }
                if (!(validarNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo se pueden ingresar números para filtrar por campos numéricos.");
                    return true;
                }
                return false;
            }
            if(!(validarNumerosLetras(txtFiltroAvanzado.Text))) 
            {
                MessageBox.Show("Solo se permiten letras y números");
                return true;
            }

            return false;
        }
        private bool validarNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool validarNumerosLetras(string texto)
        {
            string patron = "^[a-zA-Z0-9]+$";
            bool esValido = Regex.IsMatch(texto, patron);

            return esValido;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                dgvArticulos.DataSource = negocio.Filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro.Length >=2)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }
        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear ();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            cargar();
            txtFiltroAvanzado.Text = "";
        }
        private void eliminarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            try
            {
                DialogResult respuesta = MessageBox.Show("Eliminar Articulo???", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    articulo.Delete(seleccionado);
                    MessageBox.Show("Eliminado exitosamente");
                    cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            cargar();
        }
        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
        private void agregarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaArticulo altaArticulo = new frmAltaArticulo();
            altaArticulo.ShowDialog();
            cargar();
        }
        private void agregarMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaMarca altaMarca = new frmAltaMarca();
            altaMarca.ShowDialog();
        }
        private void eliminarMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBajaMarca bajaMarca = new frmBajaMarca();
            bajaMarca.ShowDialog();

            MarcaNegocio marca = new MarcaNegocio();
            try
            {

                /*DialogResult respuesta = MessageBox.Show("Eliminar MArca???", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    Marca seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    marca.Delete(seleccionado);
                    MessageBox.Show("Eliminado exitosamente");
                }*/
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void agregarCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaCategoria altaCategoria = new frmAltaCategoria();
            altaCategoria.ShowDialog();
        }
        private void eliminarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBajaCategoria bajaCategoria = new frmBajaCategoria();
            bajaCategoria.ShowDialog();

            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {

                /*DialogResult respuesta = MessageBox.Show("Eliminar MArca???", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    Marca seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    marca.Delete(seleccionado);
                    MessageBox.Show("Eliminado exitosamente");
                }*/
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void modificarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            if (dgvArticulos.CurrentCell is null)
            {
                MessageBox.Show("Debe Seleccionar un Artículo");
            }
            else
            {
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
                modificar.ShowDialog();
                cargar();
            }
        }
        private void modificarMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificarMarca modificarMarca = new frmModificarMarca();
            modificarMarca.ShowDialog();
            cargar();
        }
        private void modificarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificarCategoria modificarCategoria = new frmModificarCategoria();
            modificarCategoria.ShowDialog();
            cargar();
        }
        private void btnImagen_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            if (dgvArticulos.CurrentCell is null)
            {
                MessageBox.Show("Debe Seleccionar un Artículo");
            }
            else
            {
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmImagen cambiarImagen = new frmImagen(seleccionado);
                cambiarImagen.ShowDialog();
                cargar();
            }
        }
    }
}
