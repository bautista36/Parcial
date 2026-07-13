namespace Parcial2.Modelos
{
    internal class COperador : IOperador
    {
        private ulong legajo;
        private string apellido;
        private string nombre;
        private string categoria;

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

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

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
