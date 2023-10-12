using Catalogo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_28
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarCantidadCarrito();
            }
        }

        private void ActualizarCantidadCarrito()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
            int cantidad = carrito != null ? carrito.Count : 0;

            ScriptManager.RegisterStartupScript(this, GetType(), "ActualizarCantidadCarrito", "document.getElementById('cantidadCarrito').textContent = " + cantidad + ";", true);
        }

        public int GetCantidadArticulosEnCarrito()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
            if (carrito != null)
            {
                return carrito.Count;
            }
            return 0;
        }
    }
}