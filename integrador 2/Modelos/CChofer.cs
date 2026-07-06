using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using integrador2.Modelos;

namespace integrador2
{
    public class CChofer : CEmpleado
    {
        public uint Registro { get; set; }
        public string Distrito { get; set; }
        public CChofer(string nombre, string apellido, ulong id, uint registro, string distrito) : base(id, apellido, nombre) 
        { 
            Registro = registro;
            Distrito = distrito;
        }

    }
}
