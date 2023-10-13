<%@ Page Title="Home" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_web_equipo_28.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card-3d {
            border: 1px solid #ccc;
            border-radius: 6px;
            box-shadow: 5px 5px 15px rgba(0, 0, 0, 0.3);
            transition: transform 0.2s;
        }

            .card-3d:hover {
                transform: scale(1.03);
            }

        .card-description {
            font-size: 18px;
            font-weight: bold;
            color: #333;
        }

        .card-price {
            font-size: 16px;
            font-weight: normal;
            color: #007bff; /* Cambia el color del precio a tu preferencia */
        }

        .custom-card {
            width: 100%;
            height: 100%;
        }
    </style>



    <h1 class="display-4 text-center">Listado de Artículos</h1>

    <div class="container">
        <div class="row row-cols-1 row-cols-md-4 g-4">

<asp:Repeater ID="repRepetidor" runat="server">
    <ItemTemplate>
        <div class="col">
            <div class="card card-3d custom-card">
                <img src='<%# Eval("Imagen.ImagenUrl") %>' class="card-img-top" alt="ERROR AL CARGAR IMAGEN" />
                <div class="card-body d-flex flex-column justify-content-between align-items-center">
                    <div>
                        <p class="card-description m-0"><%# Eval("Descripcion") %></p>
                    </div>
                    <div>
                        <p class="card-price m-0">$<%# string.Format("{0:N2}", Eval("Precio")) %></p>
                    </div>
                    <div class="text-center">
                        <a href='<%# "DetalleArticulo.aspx?id=" + Eval("Id") %>' class="btn btn-primary">Ver Detalle</a>
                        <asp:Button Text="Agregar al Carrito" OnClick="AgregarAlCarrito_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" runat="server" />
                    </div>
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


