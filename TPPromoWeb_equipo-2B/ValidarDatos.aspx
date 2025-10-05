<%@ Page Title="Ingreso de datos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidarDatos.aspx.cs" Inherits="TPPromoWeb_equipo_2B.ValidarDatos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Paso 3: Ingreso de Datos Personales</h2>

    <div class="row">
        <div class="col-md-6">
            <label for="<%= txtDNI.ClientID %>">DNI:</label>
            <div class="input-group mb-3">
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" />
                
                <asp:Button ID="BtnBuscarDNI" runat="server" Text="Validar DNI" 
                            CssClass="btn btn-info" OnClick="BtnBuscarDNI_Click" />
            </div>

            <asp:Label ID="lblErrorDNI" runat="server" ForeColor="Red" />
            
            <asp:Panel ID="pnlDatosSecundarios" runat="server" Visible="False">
                <hr />
                
                <label for="<%= txtNombre.ClientID %>">Nombre:</label>
                <div style="display: flex; align-items: center; margin-bottom: 10px;">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control me-2" style="flex-grow: 1;" />
                    <asp:Label ID="lblErrorNombre" runat="server" 
                        Text="Campo obligatorio." 
                        Visible="false" 
                        CssClass="text-danger fw-bold" />
                </div>
                <label for="<%= txtApellido.ClientID %>">Apellido:</label>
                <div style="display: flex; align-items: center; margin-bottom: 10px;">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control me-2" style="flex-grow: 1;" />
                    <asp:Label ID="lblErrorApellido" runat="server" 
                        Text="Campo obligatorio." 
                        Visible="false" 
                        CssClass="text-danger fw-bold" />
                </div>
                <label for="<%= txtEmail.ClientID %>">Email:</label>
                <div style="display: flex; align-items: center; margin-bottom: 10px;">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control me-2" style="flex-grow: 1;" />
                    <asp:Label ID="lblErrorEmail" runat="server" 
                        Text="Formato de Email incorrecto." 
                        Visible="false" 
                        CssClass="text-danger fw-bold" />
                </div>
                <label for="<%= txtDireccion.ClientID %>">Direccion:</label>
                <div style="display: flex; align-items: center; margin-bottom: 10px;">
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control me-2" style="flex-grow: 1;" />
                    <asp:Label ID="lblErrorDireccion" runat="server" 
                        Text="Campo obligatorio." 
                        Visible="false" 
                        CssClass="text-danger fw-bold" />
                </div>
                <label for="<%= txtCiudad.ClientID %>">Ciudad:</label>
                <div style="display: flex; align-items: center; margin-bottom: 10px;">
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control me-2" style="flex-grow: 1;" />
                    <asp:Label ID="lblErrorCiudad" runat="server" 
                        Text="Campo obligatorio." 
                        Visible="false" 
                        CssClass="text-danger fw-bold" />
                </div>
                <label for="<%= txtCP.ClientID %>">CP:</label>
                <div style="display: flex; align-items: center; margin-bottom: 10px;">
                    <asp:TextBox ID="txtCP" runat="server" CssClass="form-control me-2" style="flex-grow: 1;" />
                    <asp:Label ID="lblErrorCP" runat="server" 
                        Text="Formato de Codigo Postal incorrecto." 
                        Visible="false" 
                        CssClass="text-danger fw-bold" />
                </div>
                <br />
                <asp:Button ID="btnParticipar" runat="server" Text="Participar!" 
                            CssClass="btn btn-success" OnClick="btnParticipar_Click" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
