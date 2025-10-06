using modelo;
using negocio;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace TPPromoWeb_equipo_2B
{
    public partial class ValidarDatos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validación de acceso directo o sesión inválida
                if (Session["Voucher"] == null || Session["IdArticuloSeleccionado"] == null)
                {
                    // Limpieza por seguridad
                    LimpiarSesion();
                    Response.Redirect("Default.aspx");
                    return;
                }
            }
        }

        protected void BtnBuscarDNI_Click(object sender, EventArgs e)
        {
            string dniIngresado = txtDNI.Text.Trim();

            if (string.IsNullOrEmpty(dniIngresado))
            {
                lblErrorDNI.Text = "Debe ingresar un DNI.";
                pnlDatosSecundarios.Visible = false;
                return;
            }

            ClienteNegocio negocio = new ClienteNegocio();
            Cliente clienteEncontrado = negocio.BuscarPorDNI(dniIngresado);

            pnlDatosSecundarios.Visible = true;

            if (clienteEncontrado != null)
            {
                txtNombre.Text = clienteEncontrado.Nombre;
                txtApellido.Text = clienteEncontrado.Apellido;
                txtEmail.Text = clienteEncontrado.Email;
                txtDireccion.Text = clienteEncontrado.Direccion;
                txtCiudad.Text = clienteEncontrado.Ciudad;
                txtCP.Text = clienteEncontrado.CP.ToString();

                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtEmail.Enabled = false;
                txtDireccion.Enabled = false;
                txtCiudad.Enabled = false;
                txtCP.Enabled = false;

                txtDNI.Enabled = false;

                // Guardamos el ID del cliente ya existente
                Session["IdCliente"] = clienteEncontrado.Id;
            }
            else
            {
                // Limpiar y habilitar campos para un nuevo cliente
                txtNombre.Text = txtApellido.Text = txtEmail.Text =
                txtDireccion.Text = txtCiudad.Text = txtCP.Text = string.Empty;

                txtNombre.Enabled = txtApellido.Enabled = txtEmail.Enabled =
                txtDireccion.Enabled = txtCiudad.Enabled = txtCP.Enabled = true;

                Session["IdCliente"] = null;
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            bool valido = true;

            // Reset de labels de error
            lblErrorNombre.Visible = lblErrorApellido.Visible =
            lblErrorEmail.Visible = lblErrorDireccion.Visible =
            lblErrorCiudad.Visible = lblErrorCP.Visible = false;

            // Validaciones básicas
            if (txtNombre.Enabled && string.IsNullOrEmpty(txtNombre.Text.Trim()))
            { lblErrorNombre.Visible = true; valido = false; }

            if (txtApellido.Enabled && string.IsNullOrEmpty(txtApellido.Text.Trim()))
            { lblErrorApellido.Visible = true; valido = false; }

            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (txtEmail.Enabled && (string.IsNullOrEmpty(txtEmail.Text.Trim()) || !Regex.IsMatch(txtEmail.Text.Trim(), patronEmail)))
            { lblErrorEmail.Visible = true; valido = false; }

            if (txtDireccion.Enabled && string.IsNullOrEmpty(txtDireccion.Text.Trim()))
            { lblErrorDireccion.Visible = true; valido = false; }

            if (txtCiudad.Enabled && string.IsNullOrEmpty(txtCiudad.Text.Trim()))
            { lblErrorCiudad.Visible = true; valido = false; }

            if (txtCP.Enabled && (string.IsNullOrEmpty(txtCP.Text.Trim()) || !int.TryParse(txtCP.Text.Trim(), out int cp) || cp <= 0))
            { lblErrorCP.Visible = true; valido = false; }

            if (!valido)
                return;

            try
            {
                ClienteNegocio negocioCliente = new ClienteNegocio();
                VoucherNegocio negocioVoucher = new VoucherNegocio();

                int idCliente;

                // Si el cliente no existe, lo registramos
                if (Session["IdCliente"] == null)
                {
                    Cliente nuevoCliente = new Cliente()
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Ciudad = txtCiudad.Text.Trim(),
                        CP = int.Parse(txtCP.Text.Trim()),
                        Documento = txtDNI.Text.Trim()
                    };

                    idCliente = negocioCliente.RegistrarCliente(nuevoCliente);
                }
                else
                {
                    idCliente = (int)Session["IdCliente"];
                }

                // 🔍 Validamos sesión antes de canjear
                if (Session["Voucher"] == null || Session["IdArticuloSeleccionado"] == null)
                {
                    lblErrorDNI.Text = "La sesión expiró. Por favor, volvé a iniciar el proceso.";
                    lblErrorDNI.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Recuperamos datos de sesión
                var voucher = (Voucher)Session["Voucher"];
                int idArticulo = (int)Session["IdArticuloSeleccionado"];
                string codigoVoucher = voucher.CodigoVoucher;

                // Realizamos el canje del voucher
                negocioVoucher.CanjearVoucher(codigoVoucher, idArticulo, idCliente);

                // 🧹 Limpiamos la sesión después del canje exitoso
                LimpiarSesion();

                // Redirigimos al usuario a la pantalla de éxito
                Response.Redirect("ParticipacionExitosa.aspx", false);
            }
            catch (Exception ex)
            {
                lblErrorDNI.Text = "Ocurrió un error al procesar el canje: " + ex.Message;
                lblErrorDNI.ForeColor = System.Drawing.Color.Red;
            }
        }

        // 🧹 Método auxiliar para limpiar variables de sesión
        private void LimpiarSesion()
        {
            Session.Remove("Voucher");
            Session.Remove("IdArticuloSeleccionado");
            Session.Remove("IdCliente");
        }
    }
}
