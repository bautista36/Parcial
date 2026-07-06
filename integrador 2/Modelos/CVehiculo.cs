using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integrador2
{
    internal class CVehiculo
    {
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public CVehiculo (string patente, string marca, string modelo)
        {
            Patente = patente;
            Marca = marca;
            Modelo = modelo;
        }
    }
}
