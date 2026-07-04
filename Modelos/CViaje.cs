// Legajo: 31127 - Apellidos y Nombres: Avena Bautista
using System.Collections.Generic;

namespace TransporteEscolar.Modelos
{
    public class CViaje
    {
        private string institucionDestino;
        private CUnidad unidad;
        private CConductor conductor;
        private List<CAcompanante> acompanantes;

        public string InstitucionDestino
        {
            get { return institucionDestino; }
            set { institucionDestino = value; }
        }

        public CUnidad Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }

        public CConductor Conductor
        {
            get { return conductor; }
            set { conductor = value; }
        }

        public List<CAcompanante> Acompanantes
        {
            get { return acompanantes; }
            set { acompanantes = value; }
        }

        public CViaje(string destino, CUnidad unidad, CConductor conductor, List<CAcompanante> acompanantes)
        {
            InstitucionDestino = destino;
            Unidad = unidad;
            Conductor = conductor;
            Acompanantes = acompanantes;
        }
    }
}