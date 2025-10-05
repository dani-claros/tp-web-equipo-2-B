using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection connection { get; set; }
        private SqlCommand command { get; set; }
        private SqlDataReader lector { get; set; }
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            //"Server=localhost,1433;Database=PROMOS_DB;User Id=sa;Password=BaseDeDatos#2;TrustServerCertificate=True;Integrated Security=False;"
            connection = new SqlConnection("Server=localhost;Database=PROMOS_DB;Integrated Security=True;");
            command = new SqlCommand();
        }


        public void setearConsulta(string consulta)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                lector = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
                connection.Close();
            }
        }

        public void ejecutarAccion()
        {
            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void setearParametros(string parametro, object valor)
        {
            command.Parameters.AddWithValue(parametro, valor);
        }
    }
}