using modelo;
using negocio;
using System;
using System.Web.UI;

namespace TPPromoWeb_equipo_2B
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validacion por si llegas a haber ingresado el codigo y volves a la pagina principal, se elimina la informacion de Session Del voucher
            Session["Voucher"] = null;
            Session["CodigoIngresado"] = null;
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            string codigo = txtVoucher.Text.Trim().ToUpper();

            //validacion con base de datos
            VoucherNegocio negocio = new VoucherNegocio();
            Voucher voucher = new Voucher();
            voucher = negocio.BuscarPorCodigo(codigo);


            if (voucher != null) 
            {
                // Guardar en sesión
                Session["Voucher"] = voucher;


                // Redirigir a la siguiente pantalla
                Response.Redirect("SeleccionPremio.aspx");

            }
            else
            {
                // Mostrar mensaje de error o redirigir
                Session["CodigoIngresado"] = codigo;
                Response.Redirect("InvalidVoucher.aspx");
            }
        }
       }
}