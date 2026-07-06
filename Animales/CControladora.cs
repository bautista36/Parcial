using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animales
{
    internal class CControladora
    {
        private static readonly string ArchivoTexto = "listaAnimales.txt";

        private static readonly char Delimitador = ';';

        List<CAnimal> Animales = CargarDatos();

        public void CrearAnimal(CAnimal c)
        {
            Animales.Add(c);            
        }
        public List<CAnimal> ObtenerLista ()
        {
          return Animales;
        }
        public bool EliminarAnimal(string buscar)
        {
            foreach (CAnimal animal in Animales)
            {
                if (animal.Nombre.ToLower() == buscar.ToLower()) 
                {
                    Animales.Remove(animal);
                    return true;
                }

            }
            return false;
        }
        public static List<CAnimal> CargarDatos()
        {
            List<CAnimal> carga = new List<CAnimal>();

            // Leemos todas las líneas del archivo
            string[] lineas = File.ReadAllLines(ArchivoTexto);

            foreach (string linea in lineas)
            {
                // Evitamos procesar líneas vacías que puedan corromper el parseo
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    // Separamos los datos usando el delimitador
                    string[] partes = linea.Split(Delimitador);

                    // Validamos que la línea tenga exactamente los dos componentes esperados
                    if (partes.Length >= 3)
                    {
                        string nombre = partes[0];
                        string tipo = partes[1].ToLower();
                        byte cantidadPatas = byte.Parse(partes[2]);

                        CAnimal animal = null;

                        switch (tipo)
                        {
                            case "perro":
                                animal = new CPerro(nombre, tipo, cantidadPatas);
                                break;
                            case "gato":
                                animal = new CGato(nombre, tipo, cantidadPatas);
                                break;
                            case "canario":
                                byte tamanoAlas = byte.Parse(partes[3]);
                                animal = new CCanario(nombre, tipo, cantidadPatas, tamanoAlas);
                                break;
                        }

                        if (animal != null)
                        {
                            carga.Add(animal);
                        }
                    }
                }
            }
            return carga;
        }
        public static void GuardarDatos(List<CAnimal> animal)
        {
            try
            {
                // Creamos una lista de strings donde cada elemento representa un auto formateado
                List<string> lineas = new List<string>();

                foreach (CAnimal niga in animal)
                {
                    lineas.Add($"{niga.Nombre}{Delimitador}{niga.Tipo}");
                }

                // Escribe todas las líneas de golpe, pisando el archivo anterior
                File.WriteAllLines(ArchivoTexto, lineas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al guardar los datos: {ex.Message}");
            }
        }

        public void MostrarTodos ()
        {
            if(Animales.Count == 0)
            {
                throw new ArgumentException("No se almaceno ningun animal \n");
            }

            foreach (CAnimal mostrar in Animales)
            {
                Console.WriteLine($"{mostrar.Nombre} | {mostrar.Tipo}");

            }
        }
        

    }
}
