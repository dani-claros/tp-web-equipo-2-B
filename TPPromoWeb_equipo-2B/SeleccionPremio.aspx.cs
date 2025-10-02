using modelo;
using System;

namespace TPPromoWeb_equipo_2B
{
    public partial class SeleccionPremio : System.Web.UI.Page
    {
        public Voucher Voucher { get; set; } = new Voucher();

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

                    // --- Voucher ---
                  
                    
                        imgArticulo.ImageUrl = "https://e7.pngegg.com/pngimages/7/879/png-clipart-internet-computer-icons-online-advertising-world-wide-web-web-design-text.png";
                        lblTitulo.Text = "Notebook Lenovo";
                        lblDescripcion.Text = "Notebook de alto rendimiento para estudiantes y profesionales.";
                        lnkAccion.NavigateUrl = "#";
                   
                }
            }
        }
    }
}
