using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using integrador2.Modelos;

namespace integrador2
{
    public class CProfesionales: CEmpleado
    {        
        public ushort Matricula { get; set; }
        public string Categoria {  get; set; }

        public CProfesionales(string nombre, string apellido, ulong id, ushort matricula, string categoria) : base(id, apellido, nombre) 
        {
            Matricula = matricula;
            Categoria = categoria;
        }
    }
}
