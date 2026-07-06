using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intregrador1
{
    public class CEntrenador:CPersona
    {
        public long Telefono {  get; set; }
        public CEntrenador(string nombre, string apellido, int dni,long telefono ) : base(dni, apellido, nombre)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
        }
        public override string DarDatos()
        {
            string datos = Nombre + Apellido + Dni + Telefono;

            return datos;
        }
    }
}
