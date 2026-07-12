using System;
using System.Collections.Generic;
using System.Linq;

namespace Parcial2
{
    internal interface IOperador
    {
        ulong Legajo { get; }
        string Apellido { get; }
        string Nombre { get; }
        string Categoria { get; } // A, B, C
        void MostrarDatos();
    }
}
