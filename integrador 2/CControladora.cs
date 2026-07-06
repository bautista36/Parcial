using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using integrador2.Modelos;

namespace integrador2
{
    internal class CControladora
    {
        private readonly List<CVehiculo> vehiculos = new();
        private readonly List<CEmpleado> empleados = new();
        private readonly List<CDotacion> dotaciones = new();

        public bool Agregar(CVehiculo nuevoCoche)
        {
            bool existe = false;
            if (nuevoCoche == null)
            {
                return existe;
            }
            else
            {
                foreach (CVehiculo coche in vehiculos)
                {
                    if (coche.Patente == nuevoCoche.Patente)
                    {
                        return existe;
                    }
                }
                vehiculos.Add(nuevoCoche);
                existe = true;
                return existe;
            }
        }
        public bool Agregar(CAmbulancia nuevaAmbulancia)
        {
            bool existe = false;
            if (nuevaAmbulancia == null)
            {
                return existe;
            }
            else
            {
                foreach (CVehiculo coche in vehiculos)
                {
                    if (coche.Patente == nuevaAmbulancia.Patente)
                    {
                        return existe;
                    }
                }
                vehiculos.Add(nuevaAmbulancia);
                existe = true;
                return existe;
            }
        }
        public bool Agregar(CChofer nuevoChofer)
        {
            bool existe = false;
            if (nuevoChofer == null)
            {
                return existe;
            }
            else
            {
                foreach (CEmpleado chofer in empleados)
                {
                    if (chofer.Id == nuevoChofer.Id)
                    {
                        return existe;
                    }
                }
                empleados.Add(nuevoChofer);
                existe = true;
                return existe;
            }
        }
        public bool Agregar(CProfesionales nuevoProfesional)
        {
            bool existe = false;

            if (nuevoProfesional == null)
            {
                return existe;
            }

            foreach (CEmpleado profesional in empleados)
            {
                if (profesional.Id == nuevoProfesional.Id)
                {
                    return existe;
                }
            }

            empleados.Add(nuevoProfesional);
            existe = true;
            return existe;
            
        }
        public List<CVehiculo> ListaVehiculos ()
        {
            return vehiculos;
                
        }
        public CChofer? BuscarChoferPorId(ulong id)
        {
            return empleados.OfType<CChofer>().FirstOrDefault(e => e.Id == id);
        }

        public CVehiculo? BuscarVehiculoPorPatente(string patente)
        {
            return vehiculos.FirstOrDefault(v => v.Patente == patente);
        }

        public List<CProfesionales> BuscarProfesionalesPorIds(IEnumerable<ulong> ids)
        {
            return empleados.OfType<CProfesionales>().Where(p => ids.Contains(p.Id)).ToList();
        }

        public void AgregarDotacion(CDotacion nuevaDotacion)
        {
            if (nuevaDotacion != null)
            {
                dotaciones.Add(nuevaDotacion);
            }
        }
        public List<CDotacion> ListaDotaciones()
        {
            return dotaciones;
        }
        public List<CEmpleado> ListaEmpleados()
        {
            return empleados;
        }                       
        public bool BuscarEmpleadoDotacion(ulong id) //PARA VER SI UN EMPLEADO ESTA EN UNA DOTACION !!!!!!!!!!!!!!!!!!!!!!!!!!
        {                                            //PARA VER SI UN EMPLEADO ESTA EN UNA DOTACION !!!!!!!!!!!!!!!!!!!!!!!!!!
            foreach (CDotacion dotacion in dotaciones)
            {
                foreach (CProfesionales profesional in dotacion.Profesionales)
                {
                    if (profesional.Id == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void EliminarEmpleado(ulong eliminar)
        {
            empleados.RemoveAll(c => c.Id == eliminar);
        }

        /*public int ContarAmbulanciasPorTipo(string tipoAmbulancia)
        {
            if (string.IsNullOrWhiteSpace(tipoAmbulancia))
            {
                return 0;
            }

            return vehiculos
                .OfType<CAmbulancia>()
                .Count(a => string.Equals(a.TipoAmbulancia, tipoAmbulancia, StringComparison.OrdinalIgnoreCase));
        }*/
    }
}
