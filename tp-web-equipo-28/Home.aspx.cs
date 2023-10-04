﻿using System;
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
            if(Session["listaArticulos"] == null)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.Listar());
            }

            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();

            if (!IsPostBack)
            {
                //Cargar por única vez cuando carga la página
                //Se puede usar AutoPostBack = "true" en el TextBox (x ejemplo)
            }
        }
        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Captura objeto
            //var algo = dgvArticulos.SelectedRow.Cells[0].Text;
            var id = dgvArticulos.SelectedDataKey.Value.ToString();
            //Se lleva el id al navegar
            Response.Redirect("ArticuloForm.aspx?id=" + id);
        }
    }
}