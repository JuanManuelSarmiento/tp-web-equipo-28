using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_web_equipo_28
{
    interface IABML<T>
    {
        void Add(T newEntity);
        void Delete(T entity);
        void Update(T entity);
        List<T> Listar();
    }
}