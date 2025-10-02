using modelo;
using System;

namespace negocio
{
    public class VoucherNegocio
    {
        public Voucher BuscarPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.setearParametros("@codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Voucher voucher = new Voucher();

                    // Código del voucher (siempre existe porque es PK)
                    voucher.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];

                    // FechaCanje puede ser NULL
                    if (!(datos.Lector["FechaCanje"] is DBNull))
                        voucher.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    else
                        voucher.FechaCanje = null;

                    // Cliente (por ahora solo el Id)
                    if (!(datos.Lector["IdCliente"] is DBNull))
                        voucher.Cliente = new Cliente { Id = (int)datos.Lector["IdCliente"] };
                    else
                        voucher.Cliente = null;

                    // Artículo (por ahora solo el Id)
                    if (!(datos.Lector["IdArticulo"] is DBNull))
                        voucher.Articulo = new Articulo { Id = (int)datos.Lector["IdArticulo"] };
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
