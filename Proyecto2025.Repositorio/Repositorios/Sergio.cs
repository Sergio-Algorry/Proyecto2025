using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.Repositorio.Repositorios
{
    internal class Sergio : IRepositorio

    {
        public string Juan { get; set; }
        public int Pepe { get; set; }

        public void Mostrar()
        {
            Console.WriteLine($"Pepe: {Pepe}");
        }

        public int Sumar(int a, int b)
        {
            return a * b + Pepe;
        }

        public int Multiplicar(int a, int b)
        {
            return a * b + Pepe;
        }
    }
}
