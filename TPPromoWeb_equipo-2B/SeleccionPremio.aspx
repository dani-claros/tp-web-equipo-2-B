<%@ Page Title="Selección de Premio!!" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="SeleccionPremio.aspx.cs" 
    Inherits="TPPromoWeb_equipo_2B.SeleccionPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>Selecciona Tu Articulo:  </h2>
  
        
        <div class="row row-cols-1 row-cols-md-3 g-4">
            
            <asp:Repeater ID="repArticulos" runat="server">
                <ItemTemplate>

                    <%int contador = 0; %>
                    <div class="col">
                        <div class="card" style="width: 18rem;">
                            <!-- Imagen -->
                   <asp:ImageButton ID="imgArticulo" 
                                    runat="server" 
                                    ImageUrl='<%# ((List<modelo.Imagen>)Eval("Imagenes")).Count > 0 
                                                ? ((List<modelo.Imagen>)Eval("Imagenes"))[0].ImagenURL 
                                                : "https://distribuidoramiyi.com.ar/products/no_product.png" %>'
                                    CssClass="card-img-top img-fluid"
                                    style="object-fit: contain; height: 200px; background-color: #f8f9fa;" 
                                     />

                            <div class="card-body">
                                <!-- Título -->
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                  <!-- Marca -->
                                 <p class="h5"><%# Eval("Marca.Descripcion") %></p>
                                <!-- Categoría -->
                                <p class="h6"><%# Eval("Categoria.Descripcion") %></p>
                          
                                <!-- Descripción -->
                                <p class="card-text"><%# Eval("Descripcion") %></p>

                                <!-- Botón ASP.NET -->
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
