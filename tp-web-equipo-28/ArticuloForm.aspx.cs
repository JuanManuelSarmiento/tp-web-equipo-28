using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tp_web_equipo_28;

namespace tp_web_equipo_28
{
    public partial class ArticuloForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Provisorio de Prueba
            //if (!IsPostBack)
            //{
            //    ddlMarcas.Items.Add("1");
            //    ddlMarcas.Items.Add("2");
            //    ddlMarcas.Items.Add("3");
            //}
            //Provisorio de Prueba
            //if (!IsPostBack)
            //{
            //    ddlCategorias.Items.Add("1");
            //    ddlCategorias.Items.Add("2");
            //    ddlCategorias.Items.Add("3");
            //}

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                List<Articulo> temporal = (List<Articulo>)Session["listaArticulos"];
                Articulo seleccionado = temporal.Find(x => x.Id == id);
                txtId.Text = seleccionado.Id.ToString();
                txtCodigo.Text = seleccionado.Codigo.ToString();
                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;

                txtId.ReadOnly = true;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = false;
                txtDescripcion.ReadOnly = false;

            }

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo aux = new Articulo();
            aux.Id = int.Parse(txtId.Text);
            aux.Codigo = txtCodigo.Text;
            aux.Nombre = txtNombre.Text;
            aux.Descripcion = txtDescripcion.Text;

            ((List<Articulo>)Session["listaArticulos"]).Add(aux);

            Response.Redirect("Home.aspx");
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int idModificar = int.Parse(txtId.Text);
            List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];

            Articulo articuloExistente = listaArticulos.FirstOrDefault(a => a.Id == idModificar);

            if (articuloExistente != null)
            {
                articuloExistente.Codigo = txtCodigo.Text;
                articuloExistente.Nombre = txtNombre.Text;
                articuloExistente.Descripcion = txtDescripcion.Text;
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = int.Parse(txtId.Text);
            List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];

            Articulo articuloAEliminar = listaArticulos.FirstOrDefault(a => a.Id == idEliminar);

            if (articuloAEliminar != null)
            {
                listaArticulos.Remove(articuloAEliminar);

                LimpiarCampos();

                Response.Redirect("Home.aspx");
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }
    }
}