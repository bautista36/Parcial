using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integrador2
{
    internal class CDotacion
    {
        private DateTime fecha;
        private CChofer chofer;
        private List<CProfesionales> profesionales;
        private CVehiculo vehiculo;
        public DateTime Fecha 
        { 
            get { return fecha; }
            set { fecha = value; }        
        }
        public CChofer? Chofer 
        {
            get { return chofer; }
            set { chofer = value; }         
        }
        public List<CProfesionales> Profesionales
        {
            get { return profesionales;}
            set { profesionales = value; }
        }
        public CVehiculo? Vehiculo 
        { 
            get { return vehiculo; }
            set { vehiculo = value; }
        } 
        public CDotacion(DateTime fecha, CChofer chofer, List<CProfesionales> pro,CVehiculo vehi)
        {
            Fecha = fecha;
            Chofer = chofer;
            Profesionales = pro;
            Vehiculo = vehi;
        }
    }
}
