<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_web_equipo_28.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-4">Bienvenid@!!!</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%# Eval("Imagen.ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <a href="DetalleArticulo.aspx?id=<%# Eval("Id") %>" class="btn btn-primary">Ver Detalle</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="text-center">
        <a href="ArticuloForm.aspx" class="btn btn-success mt-3">Cargar Nuevo Articulo</a>
    </div>
</asp:Content>

