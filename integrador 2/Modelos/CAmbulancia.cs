using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace integrador2
{
    internal class CAmbulancia(string patente, string marca, string modelo, string tipoAmbulancia) : CVehiculo(patente, marca, modelo)
    {
        private string tipoAmbulancia;
        public string TipoAmbulancia
        {
            get { return tipoAmbulancia; }
            set { tipoAmbulancia = value; }
        }
    }
}
