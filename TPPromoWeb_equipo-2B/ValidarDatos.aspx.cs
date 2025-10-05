using modelo;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPPromoWeb_equipo_2B
{
    public partial class ValidarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

                Session["IdCliente"] = clienteEncontrado.Id;
            }
            else
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtCiudad.Text = string.Empty;
                txtCP.Text = string.Empty;

                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtEmail.Enabled = true;
                txtDireccion.Enabled = true;
                txtCiudad.Enabled = true;
                txtCP.Enabled = true;

                Session["IdCliente"] = null;
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            bool valido = true;

            lblErrorNombre.Visible = false;
            lblErrorApellido.Visible = false;
            lblErrorEmail.Visible = false;
            lblErrorDireccion.Visible = false;
            lblErrorCiudad.Visible = false;
            lblErrorCP.Visible = false;

            if (txtNombre.Enabled && string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                lblErrorNombre.Text = "Campo obligatorio!";
                lblErrorNombre.Visible = true; 
                valido = false;
            }

            if(txtApellido.Enabled && string.IsNullOrEmpty(txtApellido.Text.Trim()))
            {
                lblErrorApellido.Text = "Campo obligatorio!";
                lblErrorApellido.Visible = true; 
                valido = false;
            }

            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (txtEmail.Enabled && (string.IsNullOrEmpty(txtEmail.Text.Trim()) || !System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), patronEmail)))
            {
                lblErrorEmail.Text = "Formato de email incorrecto - Campo obligatorio!";
                lblErrorEmail.Visible = true; 
                valido = false;
            }

            if (txtDireccion.Enabled && string.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                lblErrorDireccion.Text = "Campo obligatorio!";
                lblErrorDireccion.Visible = true; 
                valido = false;
            }

            if (txtCiudad.Enabled && string.IsNullOrEmpty(txtCiudad.Text.Trim()))
            {
                lblErrorCiudad.Text = "Campo obligatorio!";
                lblErrorCiudad.Visible = true; 
                valido = false;
            }

            if (txtCP.Enabled && (string.IsNullOrEmpty(txtCP.Text.Trim()) || !int.TryParse(txtCP.Text.Trim(), out int cp) || cp <= 0))
            {
                lblErrorCP.Text = "Formato incorrecto - Campo obligatorio!";
                lblErrorCP.Visible = true; 
                valido = false;
            }

            if (!valido)
                return;

       
            ClienteNegocio negocio = new ClienteNegocio();
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

            // si no existe, lo registramos

            if (Session["IdCliente"] == null)
            {
                negocio.RegistrarCliente(nuevoCliente);
            }



            Response.Redirect("ParticipacionExitosa.aspx");
        }
    }
}