CREATE PROCEDURE storeListar AS
SELECT 
	A.Id, 
	A.Codigo, 
	A.Nombre, 
	A.Descripcion, 
	M.Descripcion as Marca, 
	C.Descripcion as Categoria, 
	I.ImagenUrl, 
	I.Id AS IdImagen, 
	A.Precio, A.IdCategoria, 
	A.IdMarca FROM ARTICULOS A 
	LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id 
	LEFT JOIN MARCAS M ON A.IdMarca = M.Id 
	LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo