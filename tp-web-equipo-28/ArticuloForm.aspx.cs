using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tp_web_equipo_28;
using Catalogo.Negocio;
using Catalogo.Dominio;
using System.Drawing;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace tp_web_equipo_28
{
    public partial class ArticuloForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Marca> marcas = ObtenerMarcasDesdeBaseDeDatos();
                foreach (Marca marca in marcas)
                {
                    ddlMarcas.Items.Add(new ListItem(marca.Descripcion, marca.Id.ToString()));
                }
                List<Categoria> categorias = ObtenerCategoriasDesdeBaseDeDatos();
                foreach (Categoria categoria in categorias)
                {
                    ddlCategorias.Items.Add(new ListItem(categoria.Descripcion, categoria.Id.ToString()));
                }
            }
        }
        private List<Marca> ObtenerMarcasDesdeBaseDeDatos()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            List<Marca> marcas = negocio.Listar();

            return marcas;
        }
        private List<Categoria> ObtenerCategoriasDesdeBaseDeDatos()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            List<Categoria> categorias = negocio.Listar();

            return categorias;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo a = new Articulo();

            a.Codigo = txtCodigo.Text;
            a.Nombre = txtNombre.Text;
            a.Descripcion = txtDescripcion.Text;

            //NO CHEQUEA QUE EXISTA LA MARCA Y LA CATEGORIA
            // Instanciar y configurar Marca
            Marca marca = new Marca();
            marca.Descripcion = ddlMarcas.SelectedValue;
            a.Marca = marca;

            // Instanciar y configurar Categoria
            Categoria categoria = new Categoria();
            categoria.Descripcion = ddlCategorias.SelectedValue;
            a.Categoria = categoria;

            decimal.TryParse(txtPrecio.Text, out decimal precio);
            a.Precio = precio;

            negocio.Add(a);

            Response.Redirect("Home.aspx");
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}