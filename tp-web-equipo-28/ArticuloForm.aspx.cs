using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tp_web_equipo_28;
using Catalogo.Negocio;
namespace tp_web_equipo_28
{
    public partial class ArticuloForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.ListarConSP();
            dgvArticulos.DataBind();
        }
    }
}