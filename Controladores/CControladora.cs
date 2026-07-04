using System.Collections.Generic;
using TransporteEscolar.Modelos;

namespace TransporteEscolar.Controladores
{
    public class CControladora
    {
        private readonly List<ITrabajador> trabajadores;
        private readonly List<CUnidad> unidades;
        private readonly List<CViaje> viajes;

        public CControladora()
        {
            trabajadores = new List<ITrabajador>();
            unidades = new List<CUnidad>();
            viajes = new List<CViaje>();
        }

        public List<ITrabajador> ObtenerTrabajadores()
        {
            return trabajadores;
        }

        public void AgregarTrabajador(ITrabajador trabajador)
        {
            if (trabajador != null)
            {
                trabajadores.Add(trabajador);
            }
        }

        public bool EliminarTrabajador(ulong legajo)
        {
            for (int i = 0; i < trabajadores.Count; i++)
            {
                if (trabajadores[i].Legajo == legajo)
                {
                    trabajadores.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void AgregarUnidad(CUnidad unidad)
        {
            if (unidad != null)
            {
                unidades.Add(unidad);
            }
        }

        public bool EliminarUnidad(string patente)
        {
            for (int i = 0; i < unidades.Count; i++)
            {
                if (unidades[i].Patente.Equals(patente, System.StringComparison.OrdinalIgnoreCase))
                {
                    unidades.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void AgregarViaje(CViaje viaje)
        {
            if (viaje != null)
            {
                viajes.Add(viaje);
            }
        }

        public bool EliminarViaje(CViaje viaje)
        {
            return viajes.Remove(viaje);
        }

        public void RegistrarViaje(string patente, ulong legajoConductor, string destino)
        {
            CUnidad unidad = BuscarUnidad(patente);
            CConductor conductor = BuscarConductor(legajoConductor);

            if (unidad == null)
            {
                throw new Exception("La unidad no existe.");
            }

            if (conductor == null)
            {
                throw new Exception("El conductor no existe.");
            }

            CViaje viaje = new CViaje(destino, unidad, conductor, new List<CAcompanante>());
            viajes.Add(viaje);
        }

        private CUnidad BuscarUnidad(string patente)
        {
            foreach (CUnidad unidad in unidades)
            {
                if (unidad.Patente.Equals(patente, System.StringComparison.OrdinalIgnoreCase))
                {
                    return unidad;
                }
            }

            return null;
        }

        private CConductor BuscarConductor(ulong legajo)
        {
            foreach (ITrabajador trabajador in trabajadores)
            {
                if (trabajador is CConductor conductor && conductor.Legajo == legajo)
                {
                    return conductor;
                }
            }

            return null;
        }
    }
}
