<%@ Page Title="Código inválido" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="InvalidVoucher.aspx.cs" 
    Inherits="TPPromoWeb_equipo_2B.InvalidVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="invalidVoucherTitle">
            <section class="col-md-6 offset-md-3 text-center">
                <h1 id="invalidVoucherTitle" class="text-danger">⚠ Código Inválido</h1>
               <p class="lead">
                El código "<%=Codigo %>" que ingresaste no es válido.
                    </p>
                <p>Por favor, verificá el número y volvé a intentarlo.</p>

                <br />

                <!-- Link de regreso a la página principal -->
                <a href="Default.aspx" class="btn btn-primary">Volver al inicio</a>
            </section>
        </section>
    </main>
</asp:Content>
