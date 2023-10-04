<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ArticuloForm.aspx.cs" Inherits="tp_web_equipo_28.ArticuloForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="extId" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtMarcas" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarcas" CssClass="form-select" runat="server"/>
            </div>
            <div class="mb-3">
                <label for="txtCategorias" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategorias" CssClass="form-select" runat="server"/>
            </div>
            <%-- Falta Imagen --%>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="Home.aspx">Cancelar</a>
            </div>
        </div>
    </div>

</asp:Content>
