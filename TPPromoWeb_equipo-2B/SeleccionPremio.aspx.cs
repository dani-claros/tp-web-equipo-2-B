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
                    if (Voucher.CodigoVoucher != null)
                        lblCodigoVoucher.Text = Voucher.CodigoVoucher;
                    else
                        lblCodigoVoucher.Text = "—";

                    if (Voucher.FechaCanje != null)
                        lblFechaCanje.Text = Voucher.FechaCanje.Value.ToString("dd/MM/yyyy");
                    else
                        lblFechaCanje.Text = "—";

                    // --- Cliente ---
                    if (Voucher.Cliente != null)
                    {
                        lblIdCliente.Text = Voucher.Cliente.Id.ToString();

                        if (Voucher.Cliente.Nombre != null)
                            lblNombreCliente.Text = Voucher.Cliente.Nombre;
                        else
                            lblNombreCliente.Text = "—";

                        if (Voucher.Cliente.Apellido != null)
                            lblApellidoCliente.Text = Voucher.Cliente.Apellido;
                        else
                            lblApellidoCliente.Text = "—";

                        if (Voucher.Cliente.Documento != null)
                            lblDocumentoCliente.Text = Voucher.Cliente.Documento;
                        else
                            lblDocumentoCliente.Text = "—";

                        if (Voucher.Cliente.Email != null)
                            lblEmailCliente.Text = Voucher.Cliente.Email;
                        else
                            lblEmailCliente.Text = "—";

                        if (Voucher.Cliente.Direccion != null)
                            lblDireccionCliente.Text = Voucher.Cliente.Direccion;
                        else
                            lblDireccionCliente.Text = "—";

                        if (Voucher.Cliente.Ciudad != null)
                            lblCiudadCliente.Text = Voucher.Cliente.Ciudad;
                        else
                            lblCiudadCliente.Text = "—";

                        lblCPCliente.Text = Voucher.Cliente.CP.ToString();
                    }
                    else
                    {
                        lblIdCliente.Text = "—";
                        lblNombreCliente.Text = "—";
                        lblApellidoCliente.Text = "—";
                        lblDocumentoCliente.Text = "—";
                        lblEmailCliente.Text = "—";
                        lblDireccionCliente.Text = "—";
                        lblCiudadCliente.Text = "—";
                        lblCPCliente.Text = "—";
                    }

                    // --- Artículo ---
                    if (Voucher.Articulo != null)
                    {
                        lblIdArticulo.Text = Voucher.Articulo.Id.ToString();

                        if (Voucher.Articulo.Nombre != null)
                            lblNombreArticulo.Text = Voucher.Articulo.Nombre;
                        else
                            lblNombreArticulo.Text = "—";

                        if (Voucher.Articulo.Descripcion != null)
                            lblDescripcionArticulo.Text = Voucher.Articulo.Descripcion;
                        else
                            lblDescripcionArticulo.Text = "—";

                        lblPrecioArticulo.Text = Voucher.Articulo.Precio.ToString("C");

                        if (Voucher.Articulo.Marca != null && Voucher.Articulo.Marca.Descripcion != null)
                            lblMarcaArticulo.Text = Voucher.Articulo.Marca.Descripcion;
                        else
                            lblMarcaArticulo.Text = "—";

                        if (Voucher.Articulo.Categoria != null && Voucher.Articulo.Categoria.Descripcion != null)
                            lblCategoriaArticulo.Text = Voucher.Articulo.Categoria.Descripcion;
                        else
                            lblCategoriaArticulo.Text = "—";
                    }
                    else
                    {
                        lblIdArticulo.Text = "—";
                        lblNombreArticulo.Text = "—";
                        lblDescripcionArticulo.Text = "—";
                        lblPrecioArticulo.Text = "—";
                        lblMarcaArticulo.Text = "—";
                        lblCategoriaArticulo.Text = "—";
                    }
                }
            }
        }
    }
}
