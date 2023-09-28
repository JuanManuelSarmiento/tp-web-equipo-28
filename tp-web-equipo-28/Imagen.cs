using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_web_equipo_28
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public string ImagenUrl { get; set; }
        public override string ToString()
        {
            return ImagenUrl;
        }
    }
}