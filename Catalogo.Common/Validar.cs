using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Common
{
    public class Validar
    {
        public bool ValidarCbo(object cbo)
        {
            if(cbo == null)
            {
                return true;
            }
            return false;
        }

    }
}
