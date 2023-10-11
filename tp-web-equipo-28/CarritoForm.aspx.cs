using Catalogo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_28
{
    public partial class CarritoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

                if (carrito != null)
                {
                    repCarrito.DataSource = carrito;
                    repCarrito.DataBind();
                }
            }
        }
        protected void btnSeguir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void btnEliminarDelCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string articuloIdStr = btn.CommandArgument;

            if (int.TryParse(articuloIdStr, out int articuloId))
            {
                List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

                if (carrito != null)
                {
                    Articulo articuloAEliminar = carrito.FirstOrDefault(a => a.Id == articuloId);

                    if (articuloAEliminar != null)
                    {
                        carrito.Remove(articuloAEliminar);
                    }

                    Session["Carrito"] = carrito;
                }

                Response.Redirect("CarritoForm.aspx");
            }
        }

    }
}