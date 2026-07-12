namespace Parcial2.Modelos
{
    internal class COperador : IOperador
    {
        private ulong legajo;
        private string apellido;
        private string nombre;
        private string categoria;

        public ulong Legajo { get { return legajo; } }
        public string Apellido { get { return apellido; } }
        public string Nombre { get { return nombre; } }
        public string Categoria { get { return categoria; } }

        public COperador(ulong legajo, string apellido, string nombre, string categoria)
        {
            this.legajo = legajo;
            this.apellido = apellido;
            this.nombre = nombre;
            this.categoria = categoria.ToUpper();
        }

        public void MostrarDatos()
        {
            System.Console.WriteLine("Legajo: " + Legajo + " | " + Apellido + ", " +
                                     Nombre + " | Categoría: " + Categoria);
        }
    }
}
