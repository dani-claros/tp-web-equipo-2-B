<%@ Page Title="Selección de Premio!!" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="SeleccionPremio.aspx.cs" 
    Inherits="TPPromoWeb_equipo_2B.SeleccionPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>Detalle del Voucher</h2>

       <div class="card" style="width: 18rem;">
    <!-- Imagen -->
    <asp:Image ID="imgArticulo" runat="server" CssClass="card-img-top" AlternateText="Imagen del artículo" />

    <div class="card-body">
        <!-- Título -->
        <asp:Label ID="lblTitulo" runat="server" CssClass="card-title h5"></asp:Label>
        
        <!-- Texto -->
        <asp:Label ID="lblDescripcion" runat="server" CssClass="card-text d-block"></asp:Label>

        <!-- Botón -->
        <asp:HyperLink ID="lnkAccion" runat="server" CssClass="btn btn-primary" Text="Ver más" />
    </div>
</div>

    </main>
</asp:Content>
