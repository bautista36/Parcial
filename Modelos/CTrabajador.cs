// Legajo: 31127 - Apellidos y Nombres: Avena Bautista
namespace TransporteEscolar.Modelos
{
    public abstract class CTrabajador : ITrabajador
    {
        private ulong legajo;
        private string apellido;
        private string nombre;

        public ulong Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        protected CTrabajador(ulong legajo, string apellido, string nombre)
        {
            Legajo = legajo;
            Apellido = apellido;
            Nombre = nombre;
        }

        public abstract string DarDatos();
    }
}