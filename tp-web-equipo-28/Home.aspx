<%@ Page Title="Home" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_web_equipo_28.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-4 text-center">Bienvenid@!!!</h1>

    <div class="container">
        <div class="row row-cols-1 row-cols-md-4 g-4">
            <asp:Repeater ID="repRepetidor" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src='<%# Eval("Imagen.ImagenUrl") %>' class="card-img-top" alt="ERROR AL CARGAR IMAGEN" />
                            <div class="card-body">
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <p class="card-text">$<%# string.Format("{0:N2}", Eval("Precio")) %></p>
                                <a href='<%# "DetalleArticulo.aspx?id=" + Eval("Id") %>' class="btn btn-primary">Ver Detalle</a>
                                <asp:Button Text="Agregar al Carrito" OnClick="AgregarAlCarrito_Click" CommandArgument='<%# Eval("Id") %>' runat="server" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="text-center mt-3">
        <a href="ArticuloForm.aspx" class="btn btn-success">Cargar Nuevo Artículo</a>
    </div>
</asp:Content>


