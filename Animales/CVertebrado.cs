using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animales
{
    abstract class CVertebrado:CAnimal
    {
        private byte cantidadPatas;
        public CVertebrado(string nombre,string tipo,byte cantidadPatas): base(nombre, tipo) { }
        public byte CantidadPatas
        {
            get { return cantidadPatas; }
            set {  cantidadPatas = value;}
        }

    }
}
