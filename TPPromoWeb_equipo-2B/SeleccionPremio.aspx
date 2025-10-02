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
            <tr>
                <th>Código</th>
                <td><asp:Label ID="lblCodigoVoucher" runat="server" /></td>
            </tr>
            <tr>
                <th>Id Cliente</th>
                <td><asp:Label ID="lblIdCliente" runat="server" /></td>
            </tr>
            <tr>
                <th>Fecha de Canje</th>
                <td><asp:Label ID="lblFechaCanje" runat="server" /></td>
            </tr>
            <tr>
                <th>Id Artículo</th>
                <td><asp:Label ID="lblIdArticulo" runat="server" /></td>
            </tr>
        </table>

    </main>
</asp:Content>
