<%@ Page Title="Mi Carrito" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="CarritoForm.aspx.cs" Inherits="tp_web_equipo_28.CarritoForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repCarrito" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%# Eval("Imagen.ImagenUrl") %>" class="card-img-top" alt="ERROR AL CARGAR IMAGEN">
                        <div class="card-body">
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <asp:Button Text="Seguir Comprando" ID="btnSeguir" CssClass="btn btn-primary" OnClick="btnSeguir_Click" runat="server" />
                            <asp:Button Text="Eliminar del Carrito" ID="btnEliminarDelCarrito" CssClass="btn btn-primary" OnClick="btnEliminarDelCarrito_Click" runat="server" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
