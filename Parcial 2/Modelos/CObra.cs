namespace Parcial2.Modelos
{
    internal class CObra
    {
        private string codigo;
        private string nombre;
        private string ubicacion;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public CObra(string codigo, string nombre, string ubicacion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.ubicacion = ubicacion;
        }
    }
}
