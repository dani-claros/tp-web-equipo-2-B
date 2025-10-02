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
                    //Control para que si acceden directo desde la url sin la validacion redirija al usuario a Default
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Voucher = (Voucher)Session["Voucher"];

                    lblCodigoVoucher.Text = Voucher.CodigoVoucher;
                    lblIdCliente.Text = Voucher.Cliente.Id.ToString() ?? "—";
                    lblFechaCanje.Text = Voucher.FechaCanje?.ToString("dd/MM/yyyy") ?? "—";
                    lblIdArticulo.Text = Voucher.Articulo.Id.ToString() ?? "—";
                }
                   
            }
        }
    }
}
