using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.Repositorio.Repositorios
{
    internal class Repositorio : IRepositorio
    {
        public int Pepe { get; set; }
        public string Juan { get; set; }

        public Repositorio(int pepe, string juan)
        {
            this.Pepe = pepe;
            this.Juan = juan;
        }

        public void Mostrar()
        {
            Console.WriteLine($"Pepe: {Pepe}, Juan: {Juan}");
        }

        public int Sumar(int a, int b)
        {
            return a + b + Pepe;
        }
    }
}
