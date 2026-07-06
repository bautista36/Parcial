using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrador1;

namespace Intregrador1
{
    public abstract class CPersona : IParticipante
    {
        public int Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public CPersona(int dni, string apellido, string nombre)
        {
            Dni = dni;
            Apellido = apellido;
            Nombre = nombre;
        }
        public abstract string DarDatos();
    }
}
