using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tp_web_equipo_28;
using Catalogo.Negocio;
using Catalogo.Dominio;

namespace tp_web_equipo_28
{
    public partial class ArticuloForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //A desarrollar
            if(!IsPostBack)
            {
                ddlMarcas.Items.Add("1");
                ddlMarcas.Items.Add("2");
                ddlMarcas.Items.Add("3");
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo a = new Articulo();
            a.Codigo = txtCodigo.Text;
            a.Descripcion = txtCodigo.Text;
            a.Marca.Descripcion = ddlMarcas.SelectedValue;
            //Falta agregar todos los campos

            //Falta Guarda en la Base de Datos
        }
    }
}