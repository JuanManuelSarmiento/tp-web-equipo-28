using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Negocio
{
    public class AccesoADatos
    {
        private SqlConnection _conexion;
        private SqlCommand _comando;
        private SqlDataReader _lector;
        public SqlDataReader Lector { get { return _lector; } }

        public AccesoADatos()
        {
            _conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true") ;
            _comando = new SqlCommand();
        }
        public void SetConsulta(string consulta)
        {
            _comando.CommandType = System.Data.CommandType.Text;
            _comando.CommandText = consulta;
        }
        public void EjecutarLectura()
        {
            _comando.Connection = _conexion;
            
            try
            {
                _conexion.Open();
                _lector = _comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        public void SetParametro(string parametro, object valor)
        {
            _comando.Parameters.AddWithValue(parametro, valor); 
        }
        public void CerrarConexion()
        {
            if (_lector != null)
                _lector.Close();
            _conexion.Close();  
        }
    }
}
