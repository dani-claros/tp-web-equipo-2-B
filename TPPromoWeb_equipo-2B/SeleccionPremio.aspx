<%@ Page Title="Selección de Premio!!" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="SeleccionPremio.aspx.cs" 
    Inherits="TPPromoWeb_equipo_2B.SeleccionPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>Detalle del Voucher</h2>

        <table class="table table-bordered">
            <!-- Voucher -->
            <tr>
                <th>Código Voucher</th>
                <td><asp:Label ID="lblCodigoVoucher" runat="server" /></td>
            </tr>
            <tr>
                <th>Fecha de Canje</th>
                <td><asp:Label ID="lblFechaCanje" runat="server" /></td>
            </tr>

            <!-- Cliente -->
            <tr>
                <th>ID Cliente</th>
                <td><asp:Label ID="lblIdCliente" runat="server" /></td>
            </tr>
            <tr>
                <th>Nombre Cliente</th>
                <td><asp:Label ID="lblNombreCliente" runat="server" /></td>
            </tr>
            <tr>
                <th>Apellido Cliente</th>
                <td><asp:Label ID="lblApellidoCliente" runat="server" /></td>
            </tr>
            <tr>
                <th>Documento</th>
                <td><asp:Label ID="lblDocumentoCliente" runat="server" /></td>
            </tr>
            <tr>
                <th>Email</th>
                <td><asp:Label ID="lblEmailCliente" runat="server" /></td>
            </tr>
            <tr>
                <th>Dirección</th>
                <td><asp:Label ID="lblDireccionCliente" runat="server" /></td>
            </tr>
            <tr>
                <th>Ciudad</th>
                <td><asp:Label ID="lblCiudadCliente" runat="server" /></td>
            </tr>
            <tr>
                <th>Código Postal</th>
                <td><asp:Label ID="lblCPCliente" runat="server" /></td>
            </tr>

            <!-- Artículo -->
            <tr>
                <th>ID Artículo</th>
                <td><asp:Label ID="lblIdArticulo" runat="server" /></td>
            </tr>
            <tr>
                <th>Nombre Artículo</th>
                <td><asp:Label ID="lblNombreArticulo" runat="server" /></td>
            </tr>
            <tr>
                <th>Descripción</th>
                <td><asp:Label ID="lblDescripcionArticulo" runat="server" /></td>
            </tr>
            <tr>
                <th>Precio</th>
                <td><asp:Label ID="lblPrecioArticulo" runat="server" /></td>
            </tr>
            <tr>
                <th>Marca</th>
                <td><asp:Label ID="lblMarcaArticulo" runat="server" /></td>
            </tr>
            <tr>
                <th>Categoría</th>
                <td><asp:Label ID="lblCategoriaArticulo" runat="server" /></td>
            </tr>
        </table>
    </main>
</asp:Content>
