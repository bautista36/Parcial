using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Intregrador1
{
    public class CEquipos
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int EntrenadorAsignado { get; set; }
        public string Colores { get; set; }        
        public List<CJugadores> Jugadores { get; set; }
        public CEquipos(string nombre,string codigo,string colores,int entrenador)
        {
            Nombre = nombre;
            Codigo = codigo;
            Colores = colores;
            EntrenadorAsignado = entrenador;
            Jugadores = new List<CJugadores>();
        }

    }
}
