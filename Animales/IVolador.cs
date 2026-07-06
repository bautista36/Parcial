using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animales
{
    internal interface IVolador
    {
        byte TamañoAlas { get; set; }
        void Volar();
    
    }
}
