using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animales
{
    class CGato:CVertebrado
    {
        public CGato(string nombre, string tipo, byte cantidadPatas) : base(nombre, tipo, cantidadPatas) { }

        public override void Caminar()
        {
            Console.WriteLine(Nombre + "Camina a " + CantidadPatas);
        }
        public override void Sonar()
        {
            Console.WriteLine("Hace miau");
        }
    }
}
