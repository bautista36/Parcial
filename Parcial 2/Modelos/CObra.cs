namespace Parcial2.Modelos
{
    internal class CObra
    {
        private string codigo;
        private string nombre;
        private string ubicacion;

        public string Codigo { get { return codigo; } }
        public string Nombre { get { return nombre; } }
        public string Ubicacion { get { return ubicacion; } }

        public CObra(string codigo, string nombre, string ubicacion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.ubicacion = ubicacion;
        }
    }
}
