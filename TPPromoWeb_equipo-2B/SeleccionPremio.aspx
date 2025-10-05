<%@ Page Title="Selección de Premio!!" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="SeleccionPremio.aspx.cs" 
    Inherits="TPPromoWeb_equipo_2B.SeleccionPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>Selecciona Tu Articulo:  </h2>
        <asp:Label ID="lblError" runat="server" 
                   Text="" 
                   Visible="false" 
                   CssClass="alert alert-danger" />
        
        <div class="row row-cols-1 row-cols-md-3 g-4">
            
            <asp:Repeater ID="repArticulos" runat="server" OnItemCommand="repArticulos_ItemCommand">
    <ItemTemplate>
        <div class="col">
            <div class="card" style="width: 18rem;">
                
                <!-- Carrusel de imágenes -->
                <div id="carousel_<%# Eval("Id") %>" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <%# GetCarouselItems((modelo.Articulo)Container.DataItem) %>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carousel_<%# Eval("Id") %>" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon"></span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carousel_<%# Eval("Id") %>" data-bs-slide="next">
                        <span class="carousel-control-next-icon"></span>
                    </button>
                </div>

                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                    <p class="h5"><%# Eval("Marca.Descripcion") %></p>
                    <p class="h6"><%# Eval("Categoria.Descripcion") %></p>
                    <p class="card-text"><%# Eval("Descripcion") %></p>
                    <asp:Button ID="btnSeleccionar" 
                                runat="server" 
                                Text="Seleccionar" 
                                CssClass="btn btn-primary"
                                CommandName="Seleccionar"
                                CommandArgument='<%# Eval("Id") %>' />
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
        </div>
           
      
    </main>
</asp:Content>
