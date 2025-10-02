using System;

namespace TPPromoWeb_equipo_2B
{
    public partial class InvalidVoucher : System.Web.UI.Page
    {
        public string Codigo { get; set; } = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validacion por si llegas a haber ingresado el codigo y volves a la pagina principal, se elimina la informacion de Session Del voucher
            Session["Voucher"] = null;

            if (Session["CodigoIngresado"] != null) 
            {
                Codigo = Session["CodigoIngresado"].ToString();
            }
            
        }
    }
}
