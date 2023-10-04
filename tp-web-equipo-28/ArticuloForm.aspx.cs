using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tp_web_equipo_28

namespace tp_web_equipo_28
{
    public partial class ArticuloForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Provisorio de Prueba
            if(!IsPostBack)
            {
                ddlMarcas.Items.Add("1");
                ddlMarcas.Items.Add("2");
                ddlMarcas.Items.Add("3");
            }
            //Provisorio de Prueba
            if (!IsPostBack)
            {
                ddlCategorias.Items.Add("1");
                ddlCategorias.Items.Add("2");
                ddlCategorias.Items.Add("3");
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo aux = new Articulo();
            aux.Id = int.Parse(txtDescripcion.Text);
            aux.Codigo = txtCodigo.Text;
            aux.Nombre = txtNombre.Text;
            aux.Descripcion = txtDescripcion.Text;
            //aux.Marca = ddlMarcas.SelectedValue;
            //aux.Categoria = ddlCategorias.SelectedValue;
            //Falta Imagen
            aux.Precio = decimal.Parse(txtPrecio.Text);

            ((List<Articulo>)Session["listaArticulos"]).Add(aux);
        }
    }
}