// Legajo: 31127 - Apellidos y Nombres: Avena Bautista

namespace TransporteEscolar.Modelos
{
    public class CCombi : CUnidad
    {
        public CCombi(string patente, string marca, string modelo) : base(patente, marca, modelo) { }
    }

    public class CMicro : CUnidad
    {
        private ushort capacidadMaxima;

        public ushort CapacidadMaxima
        {
            get { return capacidadMaxima; }
            set { capacidadMaxima = value; }
        }

        public CMicro(string patente, string marca, string modelo, ushort capacidad) : base(patente, marca, modelo)
        {
            CapacidadMaxima = capacidad;
        }
    }
}