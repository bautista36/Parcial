using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animales
{
    abstract class CAnimal
    {
        private string nombre;
        private string tipo;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public CAnimal(string nombre,string tipo)
        {
            Nombre = nombre;
            Tipo = tipo;
        }
        public abstract void Caminar();
        public abstract void Sonar();
    }
}
