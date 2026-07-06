using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using integrador2.Modelos;

namespace integrador2.Modelos
{
    public class CEmpleado:IEmpleado
    {
        private ulong id;
        private string nombre;
        private string apellido;
        public ulong Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public CEmpleado(ulong id, string apellido, string nombre)
        {
            Id = id;
            Apellido = apellido;
            Nombre = nombre;
        }
        public string DarDatos()
        {
            string datos = $"{Nombre} {Apellido}; legajo:{id}";
            return datos;
        }
    }
}
