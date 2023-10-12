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
        protected void AgregarAlCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string articuloId = btn.CommandArgument;

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = negocio.ObtenerArticuloPorId(articuloId);

            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

            if (carrito == null)
            {
                carrito = new List<Articulo>();
            }

            carrito.Add(articulo);

            Session["Carrito"] = carrito;

            int cantidadCarrito = carrito.Count;
            ScriptManager.RegisterStartupScript(this, GetType(), "ActualizarCantidadCarrito", "document.getElementById('cantidadCarrito').textContent = " + cantidadCarrito + ";", true);
        }
    }
}