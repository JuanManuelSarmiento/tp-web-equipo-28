<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_web_equipo_28.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Listado de Productos</h1>

    <div class="row">
        <div class="col">

            <asp:GridView runat="server" ID="dgvArticulos" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                </Columns>
            </asp:GridView>
            <a href="ArticuloForm.aspx">Agregar</a>

        </div>
    </div>

</asp:Content>
