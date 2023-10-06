using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogo.Dominio;

namespace Catalogo.Negocio
{
    interface IABML<T>
    {
        void Add(T newEntity);
        void Delete(T entity);
        void Update(T entity);
        List<T> Listar();
    }

}
