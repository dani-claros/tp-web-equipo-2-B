using modelo;
using System;

namespace negocio
{
    public class VoucherNegocio
    {
        public Voucher BuscarPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            ArticuloNegocio articuloNegocio =  new ArticuloNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.setearParametros("@codigo", codigo);
                datos.ejecutarLectura();

                

                if (datos.Lector.Read())
                {
                    Voucher voucher = new Voucher();

                    
                    voucher.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];

                    // FechaCanje 
                    if (!(datos.Lector["FechaCanje"] is DBNull))
                        voucher.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    else
                        voucher.FechaCanje = null;

                    // Cliente 

                    if (!(datos.Lector["IdCliente"] is DBNull)) {
                        voucher.Cliente = new Cliente();
                        voucher.Cliente = (Cliente)clienteNegocio.buscarPorId((int)datos.Lector["IdCliente"]);
                            }
                    else
                        voucher.Cliente = null;

                    // Artículo 
                    if (!(datos.Lector["IdArticulo"] is DBNull))
                        voucher.Articulo = (Articulo)articuloNegocio.BuscarPorId((int)datos.Lector["IdArticulo"]);
                    else
                        voucher.Articulo = null;

                    return voucher;
                }

                return null; // Si no encuentra el código
            }
            catch (Exception)
            {
                throw; // mantener el stacktrace original
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
