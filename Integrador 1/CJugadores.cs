using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrador1;

namespace Intregrador1
{
    public class CJugadores:CPersona
    {
        public DateTime Fecha {  get; set; }
        public string Posicion { get; set; }
        public CJugadores(string nombre,string apellido,int dni,DateTime fecha,string posicion) :base(dni,apellido,nombre)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Fecha = fecha;
            Posicion = posicion;
        }
        public override string DarDatos()
        {
            string datos = Nombre + Apellido + Fecha + Dni + Posicion;

            return datos;
        }

    }
}
