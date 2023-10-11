<%@ Page Title="Detalle" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="tp_web_equipo_28.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalle</h1>

    <asp:GridView runat="server" ID="dgvArticulos"></asp:GridView>
    <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-primary" OnClick="btnVolver_Click" runat="server" />
    <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-primary" OnClick="btnEliminar_Click" runat="server" />

</asp:Content>

