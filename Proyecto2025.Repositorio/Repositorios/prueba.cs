using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.Repositorio.Repositorios
{
    public class prueba
    {
        public prueba()
        {
            var rep = new Repositorio(10, "Juan");
            var ser = new Sergio();

            IRepositorio interf = ser;

            interf.Mostrar();
        }
    }
}
