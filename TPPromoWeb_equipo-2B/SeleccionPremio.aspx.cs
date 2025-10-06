using modelo;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TPPromoWeb_equipo_2B
{
    public partial class SeleccionPremio : System.Web.UI.Page
    {
        public Voucher Voucher { get; set; } = new Voucher();
        public List<Articulo> ListaArticulos { get; set; } = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Control: si entran directo por URL sin voucher validado, los saca
                if (Session["Voucher"] == null)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                // Recuperar voucher de sesión
                Voucher = (Voucher)Session["Voucher"];

                // Cargar artículos disponibles
                try
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    ListaArticulos = articuloNegocio.Listar();

                    repArticulos.DataSource = ListaArticulos;
                    repArticulos.DataBind();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Error al cargar los artículos: " + ex.Message;
                }
            }
        }

        // Renderiza dinámicamente las imágenes del artículo dentro del carrusel Bootstrap
        protected string GetCarouselItems(Articulo articulo)
        {
            var sb = new System.Text.StringBuilder();

            if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
            {
                for (int i = 0; i < articulo.Imagenes.Count; i++)
                {
                    var img = articulo.Imagenes[i];
                    string activeClass = (i == 0) ? "active" : "";

                    sb.Append($@"
                        <div class='carousel-item {activeClass}'>
                            <img src='{img.ImagenURL}' 
                                 class='d-block w-100' 
                                 style='object-fit:contain; height:200px; background-color:#f8f9fa;' 
                                 alt='Imagen {i + 1}' />
                        </div>");
                }
            }
            else
            {
                sb.Append(@"
                    <div class='carousel-item active'>
                        <img src='https://distribuidoramiyi.com.ar/products/no_product.png' 
                             class='d-block w-100' 
                             style='object-fit:contain; height:200px; background-color:#f8f9fa;' 
                             alt='Sin imagen' />
                    </div>");
            }

            return sb.ToString();
        }

        // Evento del botón "Seleccionar"
        protected void repArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                lblError.Visible = false;

                try
                {
                    int idArticuloSeleccionado = Convert.ToInt32(e.CommandArgument);

                    // Guardamos la información necesaria en sesión
                    Session["IdArticuloSeleccionado"] = idArticuloSeleccionado;

                    // Redirigir a la página de ValidarDatos
                    Response.Redirect("ValidarDatos.aspx", false);
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Ocurrió un error al seleccionar el artículo: " + ex.Message;
                }
            }
        }
    }
}
