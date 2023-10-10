<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_web_equipo_28.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenid@!!!</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%
            foreach (Catalogo.Dominio.Articulo art in ListaArticulo)
            {%>

                <div class="col">
                    <div class="card">
                        <img src="<%: art.Imagen.ImagenUrl %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"></h5>
                            <p class="card-text"><%: art.Descripcion %></p>
                            <a href="DetalleArticulo.aspx?id=<%: art.Id %>">Ver Detalle</a>
                        </div>
                    </div>
                </div>

          <%}%>
    </div>

</asp:Content>
