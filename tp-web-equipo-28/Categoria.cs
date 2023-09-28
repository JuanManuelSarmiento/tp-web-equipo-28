using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_web_equipo_28
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}