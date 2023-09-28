using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_28
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.Listar();
            dgvArticulos.DataBind();

            if (!IsPostBack)
            {
                //Cargar por única vez cuando carga la página
                //Se puede usar AutoPostBack = "true" en el TextBox (x ejemplo)
            }
        }
    }
}