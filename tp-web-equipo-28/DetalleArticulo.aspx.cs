using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Catalogo.Dominio;
using Catalogo.Negocio;

namespace tp_web_equipo_28
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];

            if (!string.IsNullOrEmpty(id))
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                dgvArticulos.DataSource = negocio.ListarXId(id);
                dgvArticulos.DataBind();
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];

            if (!string.IsNullOrEmpty(id))
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo a = new Articulo();

                if (int.TryParse(id, out int articuloId))
                {
                    a.Id = articuloId;
                    negocio.Delete(a);
                    Response.Redirect("Home.aspx");
                }
            }
        }

    }
}