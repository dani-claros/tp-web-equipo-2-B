using System;

namespace TPPromoWeb_equipo_2B
{
    public partial class InvalidVoucher : System.Web.UI.Page
    {
        public string Codigo { get; set; } = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CodigoIngresado"] != null) 
            {
                Codigo = Session["CodigoIngresado"].ToString();
            }
            
        }
    }
}
