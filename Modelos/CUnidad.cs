// Legajo: 31127 - Apellidos y Nombres: Avena Bautista
namespace TransporteEscolar.Modelos
{
    public abstract class CUnidad
    {
        private string patente;
        private string marca;
        private string modelo;

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
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

        protected CUnidad(string patente, string marca, string modelo)
        {
            Patente = patente;
            Marca = marca;
            Modelo = modelo;
        }
    }
}