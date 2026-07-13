namespace Parcial2.Modelos
{
    internal class CMaquinas : IMaquina
    {
        private string codigo;
        private string marca;
        private string modelo;
        private bool esBasica;
        private static int cantidadMaquinas;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public bool EsBasica
        {
            get { return esBasica; }
            set { esBasica = value; }
        }

        public CMaquinas(string codigo, string marca, string modelo, bool esBasica)
        {
            this.codigo = codigo;
            this.marca = marca;
            this.modelo = modelo;
            this.esBasica = esBasica;
            cantidadMaquinas++;
        }

        public static int DevolverTotalMaquinas()
        {
            return cantidadMaquinas;
        }

        public virtual void MostrarDatos()
        {
            System.Console.WriteLine("Código: " + Codigo + " | Marca: " + Marca +
                                     " | Modelo: " + Modelo);
            if (EsBasica)
            {
                System.Console.WriteLine("Tipo: máquina básica");
            }
            else
            {
                System.Console.WriteLine("Tipo: máquina pesada");
            }
        }
    }
}
