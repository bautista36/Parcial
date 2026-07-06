using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animales
{
    class CPerro:CVertebrado
    {
        public CPerro(string nombre, string tipo, byte cantidadPatas) : base(nombre, tipo,cantidadPatas) { }

        public override void Caminar()
        {
            Console.WriteLine(Nombre + "Camina a " + CantidadPatas);
        }
        public override void Sonar()
        {
            Console.WriteLine("Hace gof gof");
        }
    }
}
