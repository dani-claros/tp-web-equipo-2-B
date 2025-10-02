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
        protected void repArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ImagenClick")
            {
                int idArticulo = Convert.ToInt32(e.CommandArgument);
                // acá resolvés el artículo clickeado
                Response.Write("Hiciste click en el artículo con ID: " + idArticulo);
            }
        }
    }
}
