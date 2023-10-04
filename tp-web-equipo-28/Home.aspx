<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_web_equipo_28.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <style>
        .oculto{
            display: none;
        }
    </style>--%>
    <h1>Listado de Productos</h1>

    <div class="row">
        <div class="col">

            <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
                <Columns>
<%--                    <asp:BoundField HeaderText="Id" DataField="Id" headerStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />--%>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Detalle" HeaderText="" />
                </Columns>
            </asp:GridView>
            <a href="ArticuloForm.aspx">Agregar</a>

        </div>
    </div>

</asp:Content>
