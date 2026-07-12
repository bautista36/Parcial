using System;
using System.Collections.Generic;
using System.Linq;

namespace Parcial2
{
    internal interface IMaquina
    {
        string Codigo { get; }
        string Marca { get; set; }
        string Modelo { get; }
        void MostrarDatos();
    }
}
