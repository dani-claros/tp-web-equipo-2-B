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
                if (Session["Voucher"] == null)
                {
                    // Control: si acceden directo desde la url sin validación, redirige a Default
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Voucher = (Voucher)Session["Voucher"];
                    //seteo lista de articulos
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    
                    ListaArticulos = articuloNegocio.Listar();

                    repArticulos.DataSource = ListaArticulos;
                    repArticulos.DataBind();
                    // --- Voucher ---




                }
            }
        }
        protected string GetCarouselItems(modelo.Articulo articulo)
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
                    <img src='{img.ImagenURL}' class='d-block w-100' style='object-fit:contain; height:200px; background-color:#f8f9fa;' alt='Imagen {i + 1}' />
                </div>");
                }
            }
            else
            {
                sb.Append($@"
            <div class='carousel-item active'>
                <img src='https://distribuidoramiyi.com.ar/products/no_product.png' 
                     class='d-block w-100' 
                     style='object-fit:contain; height:200px; background-color:#f8f9fa;' 
                     alt='Sin imagen' />
            </div>");
            }

            return sb.ToString();
        }
    }
}
