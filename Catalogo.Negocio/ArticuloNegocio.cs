﻿using Catalogo.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Catalogo.Negocio
{
    public class ArticuloNegocio : IABML<Articulo>
    {
        public void Add(Articulo newEntity) {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) \r\nVALUES (@codigo,@nombre,@descripcion,@idMarca,@idCategoria,@precio);");
                datos.SetParametro("@IdArticulo", newEntity.Id);
                datos.SetParametro("@codigo", newEntity.Codigo);
                datos.SetParametro("@nombre", newEntity.Nombre);
                datos.SetParametro("@descripcion", newEntity.Descripcion);
                datos.SetParametro("@idMarca", newEntity.Marca.Id);
                datos.SetParametro("@idCategoria", newEntity.Categoria.Id);
                datos.SetParametro("@precio", newEntity.Precio);

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
        public void Delete(Articulo newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetParametro("@id", newEntity.Id);
                datos.SetConsulta("DELETE FROM ARTICULOS WHERE Id = @id");

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
        public void Update(Articulo newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE ID = @id");
                datos.SetParametro("@codigo", newEntity.Codigo);
                datos.SetParametro("@nombre", newEntity.Nombre);
                datos.SetParametro("@descripcion", newEntity.Descripcion);
                datos.SetParametro("@idMarca", newEntity.Marca.Id);
                datos.SetParametro("@idCategoria", newEntity.Categoria.Id);
                datos.SetParametro("@precio", newEntity.Precio);
                datos.SetParametro("@id", newEntity.Id);


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
        public void UpdateImage(Articulo art)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("UPDATE IMAGENES SET ImagenUrl = @imagenUrl WHERE IdArticulo = @IdArticulo AND ID = @id");
                datos.SetParametro("@imagenUrl", art.Imagen.ImagenUrl);
                datos.SetParametro("@idArticulo", art.Id);
                datos.SetParametro("@id", art.Imagen.Id);

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
        public List<Articulo> Listar()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, I.ImagenUrl, I.Id AS IdImagen, A.Precio, A.IdCategoria, A.IdMarca FROM ARTICULOS A LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    int articuloId = (int)datos.Lector["Id"];

                    Articulo aux = articulos.FirstOrDefault(a => a.Id == articuloId);

                    if (aux == null)
                    {
                        aux = new Articulo
                        {
                            Marca = new Marca(),
                            Categoria = new Categoria(),
                            Imagenes = new List<Imagen>(),
                            Id = articuloId,
                            Codigo = datos.Lector["Codigo"] as string ?? string.Empty,
                            Nombre = datos.Lector["Nombre"] as string ?? string.Empty,
                            Descripcion = datos.Lector["Descripcion"] as string ?? string.Empty,
                            Precio = (decimal)datos.Lector["Precio"]
                        };

                        if (datos.Lector["IdImagen"] is int idImagen)
                        {
                            aux.Imagenes.Add(new Imagen
                            {
                                Id = idImagen,
                                IdArticulo = aux.Id,
                                ImagenUrl = datos.Lector["ImagenUrl"] as string ?? string.Empty
                            });
                        }

                        aux.Marca.Descripcion = datos.Lector["Marca"] as string ?? string.Empty;
                        aux.Categoria.Descripcion = datos.Lector["Categoria"] as string ?? string.Empty;

                        articulos.Add(aux);
                    }
                    else
                    {
                        if (datos.Lector["IdImagen"] is int idImagen)
                        {
                            aux.Imagenes.Add(new Imagen
                            {
                                Id = idImagen,
                                IdArticulo = aux.Id,
                                ImagenUrl = datos.Lector["ImagenUrl"] as string ?? string.Empty
                            });
                        }
                    }
                }

                return articulos.OrderByDescending(a => a.Id).ToList();
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
        public List<Articulo> ListarConSP()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetProcedure("storeListar");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Imagen = new Imagen();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Imagen.IdArticulo = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    else
                        aux.Codigo = "";

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    else
                        aux.Nombre = "";

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    else
                        aux.Descripcion = "";

                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    else
                        aux.Marca.Descripcion = "";

                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    else
                        aux.Categoria.Descripcion = "";

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    else
                        aux.Imagen.ImagenUrl = "";

                    if (!(datos.Lector["IdImagen"] is DBNull))
                    {
                        aux.Imagen.Id = (int)datos.Lector["IdImagen"];
                    }



                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    else
                        aux.Precio = 0;

                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    else
                        aux.Categoria.Id = 0;

                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    else
                        aux.Categoria.Id = 1;

                    if (!articulos.Any(a => a.Id == aux.Id))
                    {
                        articulos.Add(aux);
                    }
                }

                return articulos.OrderByDescending(a => a.Id).ToList();
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
        public List<Articulo> Filtrar(string campo, string criterio, string filtro)
            {
                List<Articulo> articulos = new List<Articulo>();
                AccesoADatos datos = new AccesoADatos();

                try
                {
                    string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion , M.Descripcion as Marca, C.Descripcion as Categoria, I.ImagenUrl, I.Id AS IdImagen, A.Precio, A.IdCategoria, A.IdMarca FROM ARTICULOS A LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo WHERE ";

                    switch (campo)
                    {
                        case "Nombre":
                            switch (criterio)
                            {
                                case "Comienza con":
                                    consulta += "A.Nombre LIKE '" + filtro + "%'";
                                    break;
                                case "Termina con":
                                    consulta += "A.Nombre LIKE '%" + filtro + "'";
                                    break;
                                case "Contiene":
                                    consulta += "A.Nombre LIKE '%" + filtro + "%'";
                                    break;
                                default:
                                    break;
                            }

                            break;
                        case "Marca":
                            switch (criterio)
                            {
                                case "Comienza con":
                                    consulta += "M.Descripcion LIKE '" + filtro + "%'";
                                    break;
                                case "Termina con":
                                    consulta += "M.Descripcion LIKE '%" + filtro + "'";
                                    break;
                                case "Contiene":
                                    consulta += "M.Descripcion LIKE '%" + filtro + "%'";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Categoria":
                            switch (criterio)
                            {
                                case "Comienza con":
                                    consulta += "C.Descripcion LIKE '" + filtro + "%'";
                                    break;
                                case "Termina con":
                                    consulta += "C.Descripcion LIKE '%" + filtro + "'";
                                    break;
                                case "Contiene":
                                    consulta += "C.Descripcion LIKE '%" + filtro + "%'";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Precio":
                            switch (criterio)
                            {
                                case "Mayor a":
                                    consulta += "A.Precio > " + filtro;
                                    break;
                                case "Menor a":
                                    consulta += "A.Precio < " + filtro;
                                    break;
                                case "Igual a":
                                    consulta += "A.Precio = " + filtro;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }

                    datos.SetConsulta(consulta);
                    datos.EjecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Articulo aux = new Articulo();

                        aux.Marca = new Marca();
                        aux.Categoria = new Categoria();
                        aux.Imagen = new Imagen();

                        aux.Id = (int)datos.Lector["Id"];
                        aux.Imagen.IdArticulo = (int)datos.Lector["Id"];

                        if (!(datos.Lector["Codigo"] is DBNull))
                            aux.Codigo = (string)datos.Lector["Codigo"];
                        else
                            aux.Codigo = "";

                        if (!(datos.Lector["Nombre"] is DBNull))
                            aux.Nombre = (string)datos.Lector["Nombre"];
                        else
                            aux.Nombre = "";

                        if (!(datos.Lector["Descripcion"] is DBNull))
                            aux.Descripcion = (string)datos.Lector["Descripcion"];
                        else
                            aux.Descripcion = "";

                        if (!(datos.Lector["Marca"] is DBNull))
                            aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                        else
                            aux.Marca.Descripcion = "";

                        if (!(datos.Lector["Categoria"] is DBNull))
                            aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        else
                            aux.Categoria.Descripcion = "";

                        if (!(datos.Lector["ImagenUrl"] is DBNull))
                            aux.Imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                        else
                            aux.Imagen.ImagenUrl = "";

                        if (!(datos.Lector["IdImagen"] is DBNull))
                        {
                            aux.Imagen.Id = (int)datos.Lector["IdImagen"];
                        }



                        if (!(datos.Lector["Precio"] is DBNull))
                            aux.Precio = (decimal)datos.Lector["Precio"];
                        else
                            aux.Precio = 0;

                        if (!(datos.Lector["IdCategoria"] is DBNull))
                            aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                        else
                            aux.Categoria.Id = 0;

                        if (!(datos.Lector["IdMarca"] is DBNull))
                            aux.Marca.Id = (int)datos.Lector["IdMarca"];
                        else
                            aux.Categoria.Id = 1;

                        articulos.Add(aux);

                    }
                    return articulos;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        public List<Articulo> ListarXId(string id)
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT TOP 1 A.Id, A.Codigo, A.Nombre, A.Descripcion , M.Descripcion as Marca, C.Descripcion as Categoria, I.ImagenUrl, I.Id AS IdImagen, A.Precio, A.IdCategoria, A.IdMarca FROM ARTICULOS A LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo WHERE ";

                consulta += "A.Id =" + id;

                datos.SetConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Imagen = new Imagen();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Imagen.IdArticulo = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    else
                        aux.Codigo = "";

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    else
                        aux.Nombre = "";

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    else
                        aux.Descripcion = "";

                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    else
                        aux.Marca.Descripcion = "";

                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    else
                        aux.Categoria.Descripcion = "";

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    else
                        aux.Imagen.ImagenUrl = "";

                    if (!(datos.Lector["IdImagen"] is DBNull))
                    {
                        aux.Imagen.Id = (int)datos.Lector["IdImagen"];
                    }



                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    else
                        aux.Precio = 0;

                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    else
                        aux.Categoria.Id = 0;

                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    else
                        aux.Categoria.Id = 1;

                    articulos.Add(aux);

                }
                return articulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Articulo ObtenerArticuloPorId(string articuloId)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetParametro("@id", articuloId);
                datos.SetConsulta("SELECT Id, Codigo, Nombre, Descripcion, Precio FROM ARTICULOS WHERE Id = @id");

                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo
                    {
                        Id = (int)datos.Lector["Id"],
                        Codigo = datos.Lector["Codigo"].ToString(), 
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(datos.Lector["Precio"])
                    };

                    return articulo;
                }
                return null;
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
