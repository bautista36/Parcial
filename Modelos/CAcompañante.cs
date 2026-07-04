// Legajo: 31127 - Apellidos y Nombres: Avena Bautista
namespace TransporteEscolar.Modelos
{
    public class CAcompanante : CTrabajador
    {
        private bool certificacionCuidados;

        public bool CertificacionCuidados
        {
            get { return certificacionCuidados; }
            set { certificacionCuidados = value; }
        }

        public CAcompanante(ulong legajo, string apellido, string nombre, bool certificacion) : base(legajo, apellido, nombre)
        {
            CertificacionCuidados = certificacion;
        }

        public override string DarDatos()
        {
            string cert = CertificacionCuidados ? "Con Certificación" : "Sin Certificación";
            return $"Acompañante: {Apellido}, {Nombre} | Legajo: {Legajo} | {cert}";
        }
    }
}