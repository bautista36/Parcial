using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador1
{
    internal interface IParticipante
    {
        int Dni { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }

        string DarDatos(); //String concatenado
    }
}
