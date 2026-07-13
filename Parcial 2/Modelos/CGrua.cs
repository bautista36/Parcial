namespace Parcial2.Modelos
{
    internal class CGrua : CMaquinas
    {
        private double capacidad;

        public double Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }

        public CGrua(string codigo, string marca, string modelo, double capacidad)
            : base(codigo, marca, modelo, false)
        {
            this.capacidad = capacidad;
        }

        public override void MostrarDatos()
        {
            base.MostrarDatos();
            System.Console.WriteLine("Capacidad: " + Capacidad + " toneladas");
        }
    }
}
