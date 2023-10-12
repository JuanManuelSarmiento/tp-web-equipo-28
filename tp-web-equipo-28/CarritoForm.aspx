<%@ Page Title="Mi Carrito" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="CarritoForm.aspx.cs" Inherits="tp_web_equipo_28.CarritoForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <h1>Mi Carrito</h1>
            <table class="table">
                <thead>
                    <tr>
                        <th>Imagen</th>
                        <th>Descripción</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repCarrito" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><img src='<%# Eval("Imagen.ImagenUrl") %>' alt="Imagen del artículo" style="max-width: 100px;" /></td>
                                <td><%# Eval("Descripcion") %></td>
                                <td>
                                    <asp:Button Text="Seguir Comprando" ID="btnSeguir" CssClass="btn btn-primary" OnClick="btnSeguir_Click" runat="server" />
                                    <asp:Button Text="Eliminar del Carrito" ID="btnEliminarDelCarrito" CssClass="btn btn-danger" OnClick="btnEliminarDelCarrito_Click" CommandArgument='<%# Eval("Id") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

    <asp:Label ID="lblPrecioTotal" runat="server" Text="Precio Total: $" CssClass="precio-total"></asp:Label>

</asp:Content>

