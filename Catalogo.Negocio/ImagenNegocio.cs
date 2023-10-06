using Catalogo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Negocio
{
    public class ImagenNegocio : IABML<Imagen>
    {
        private AccesoADatos datos;
        public void Add(Imagen newEntity)
        {
            datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("insert into IMAGENES values(@idArticulo,@url)");
                datos.SetParametro("@idArticulo", newEntity.IdArticulo);
                datos.SetParametro("@url", newEntity.ImagenUrl);
                datos.EjecutarLectura();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Delete(Imagen entity)
        {
            throw new NotImplementedException();
        }

        public List<Imagen> Listar()
        {
            datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("Select Id,IdArticulo, ImagenUrl from IMAGENES WHERE ImagenUrl != ''");
                datos.EjecutarLectura();
                var imagenes = new List<Imagen>();
                while (datos.Lector.Read())
                {
                    var aux = new Imagen
                    {
                        Id = (int)datos.Lector["Id"],
                        IdArticulo = (int)datos.Lector["IdArticulo"],
                        ImagenUrl = (string)datos.Lector["ImagenUrl"]
                    };
                    imagenes.Add(aux);
                }
                return imagenes;
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
        public List<Imagen> Listar(Articulo art)
        {
            datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @idArticulo ORDER BY CASE WHEN ImagenUrl = '@urlActual' THEN 0 ELSE 1 END, ImagenUrl");
                datos.SetParametro("@idArticulo", art.Id);
                datos.SetParametro("@urlActual", art.Imagen.ImagenUrl);
                datos.EjecutarLectura();
                List<Imagen> imagenes = new List<Imagen>();
                while (datos.Lector.Read())
                {
                    var aux = new Imagen
                    {
                        ImagenUrl = (string)datos.Lector["ImagenUrl"]
                    };
                    imagenes.Add(aux);
                }
                return imagenes;
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

        public void Update(Imagen entity)
        {
            throw new NotImplementedException();
        }
    }
}
