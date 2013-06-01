using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Abm_Recorrido
{
    class ParametrosIncorrectosException : System.Exception
    {
        public ParametrosIncorrectosException(String mensaje) : base(mensaje) {}
    }
}
