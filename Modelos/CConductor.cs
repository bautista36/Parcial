// Legajo: 31127 - Apellidos y Nombres: Avena Bautista

namespace TransporteEscolar.Modelos
{
    public class CConductor : CTrabajador
    {
        private uint registro;
        private char categoriaLicencia;

        public uint Registro
        {
            get { return registro; }
            set { registro = value; }
        }

        public char CategoriaLicencia
        {
            get { return categoriaLicencia; }
            set { categoriaLicencia = value; }
        }

        public CConductor(ulong legajo, string apellido, string nombre, uint registro, char categoria) : base(legajo, apellido, nombre)
        {
            Registro = registro;
            CategoriaLicencia = categoria;
        }

        public override string DarDatos()
        {
            return $"Conductor: {Apellido}, {Nombre} | Legajo: {Legajo} | Registro: {Registro} | Cat: {CategoriaLicencia}";
        }
    }
}