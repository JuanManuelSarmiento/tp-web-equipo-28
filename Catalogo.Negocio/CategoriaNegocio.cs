using Catalogo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Negocio
{
    public class CategoriaNegocio : IABML<Categoria>
    {
        public void Add(Categoria newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("INSERT INTO CATEGORIAS(Descripcion) \r\nVALUES (@descripcion);");
                //datos.SetParametro("@id", newEntity.Id);
                datos.SetParametro("@descripcion", newEntity.Descripcion);

                datos.EjecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Delete(Categoria newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetParametro("@id", newEntity.Id);
                datos.SetConsulta("DELETE FROM CATEGORIAS WHERE Id = @Id AND NOT EXISTS (SELECT 1 FROM ARTICULOS WHERE IdCategoria = @Id)");

                datos.EjecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("SELECT Id, Descripcion from CATEGORIAS");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"]
                    };

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return lista;
        }

        public void Update(Categoria newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                //------------------
                //FALTA TERMINAR
                //datos.SetConsulta("UPDATE CATEGORIAS SET Descripcion = 'NUEVA-DESCRIPCION' WHERE Descripcion = 'VIEJA-DESCRIPCION'");
                //datos.SetParametro("@id", newEntity.Descripcion);
                //datos.SetParametro("@descripcion", nuevaDescripcion);
                //datos.EjecutarLectura();
                //------------------
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
