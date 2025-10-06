<%@ Page Title="Canjeá Tu Codigo y Ganá" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="TPPromoWeb_equipo_2B._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="voucherTitle">
            <section class="col-md-5" aria-labelledby="gettingStartedTitle">
                <h1 id="voucherTitle">Ingrese su código de voucher</h1>
                <p class="lead">Participá de la promoción ingresando el código que recibiste con tu compra.</p>

                <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control" 
                             placeholder="XXXXXXXXXXXXX"></asp:TextBox>
                <br />

                <asp:Button ID="btnValidar" runat="server" CssClass="btn btn-primary" 
                            Text="Siguiente" onClick="btnValidar_Click"/>
                <br />

                 <asp:RequiredFieldValidator ID="rfvVoucher" runat="server" ControlToValidate="txtVoucher" ErrorMessage="El código es obligatorio." CssClass="text-danger" Display="Dynamic" />

            </section>
        </section>
    </main>

</asp:Content>
