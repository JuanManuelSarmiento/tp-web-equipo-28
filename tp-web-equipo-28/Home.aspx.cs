using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Catalogo.Dominio;
using Catalogo.Negocio;

namespace tp_web_equipo_28
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.ListarConSP();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }
        }
        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }

        //FALTA:
        //AGREGAR, ELIMINAR Y VER ARTICULOS EN CARRITO DE COMPRAS
        //FILTRADO
        //IMAGENES (EN DETALLE PRODUCTO)
        protected void AgregarAlCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string articuloId = btn.CommandArgument;

            // Obtén el artículo con el ID seleccionado y guárdalo en una lista de artículos en la sesión
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = negocio.ObtenerArticuloPorId(articuloId);

            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

            if (carrito == null)
            {
                carrito = new List<Articulo>();
            }

            carrito.Add(articulo);

            Session["Carrito"] = carrito;
        }
    }
}