using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animales
{
    class CCanario:CVertebrado,IVolador
    {
        public byte TamañoAlas { get; set; }
        public CCanario(string nombre, string tipo, byte cantidadPatas,byte tama) : base(nombre, tipo, cantidadPatas)
        {
            TamañoAlas = tama; 
        }
        
        
        public override void Caminar()
        {
            Console.WriteLine(Nombre + "Camina a " + CantidadPatas);
        }
        public override void Sonar()
        {
            Console.WriteLine("Hace pio pio");
        }
        public void Volar()
        {
            Console.WriteLine(Nombre + " Vuela con sus alas de " + TamañoAlas);
        }

    }
}
