using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animales
{
    internal class CVista
    {
        public void Vista()
        {
            bool salir = false;

            CControladora controladora = new CControladora();

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("1. Crear Animal");
                Console.WriteLine("2. Mostrar todos los animales");
                Console.WriteLine("3. Hacer sonar a todos los animales");
                Console.WriteLine("4. Mostrar animales voladores");
                Console.WriteLine("5. Eliminar un animal");
                Console.WriteLine("6. Guardar datos");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CAnimal nuevo = CrearAnimal();

                        controladora.CrearAnimal(nuevo);
                        break;

                    case "2":
                        controladora.MostrarTodos();
                        break;

                    case "3":
                        List<CAnimal> listaSonido = controladora.ObtenerLista();
                        foreach (CAnimal animal in listaSonido)
                        {
                            Console.Write($"{animal.Nombre} es {animal.Tipo} y ");

                            animal.Sonar();
                        }
                        break;

                    case "4":
                        List<CAnimal> listaVoladores = controladora.ObtenerLista();

                        bool encontrado = false;    

                        foreach(CAnimal animal in listaVoladores)
                        {
                            encontrado = true;

                            if(animal is IVolador volador)
                            {
                                volador.Volar();
                            }
                            
                        }
                        if(!encontrado)
                        {
                            throw new Exception("No se encontraron canarios");
                        }

                        break;

                    case "5":
                        Console.WriteLine("Digite el animal a buscar por nombre");
                        string buscar = Console.ReadLine().ToLower();

                        bool existe = controladora.EliminarAnimal(buscar);
                        
                        switch(existe)
                        {
                            case true:
                                Console.WriteLine("Se elimino con exito");
                                break;

                            case false:
                                Console.WriteLine("No se pudo eliminar con exito");
                                break;
                        }
                        break;

                    case "6":
                        CControladora.GuardarDatos(controladora.ObtenerLista());
                        Console.WriteLine("Datos guardados ");
                        break;

                    case "7":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
        public CAnimal CrearAnimal()
        {
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el tipo de animal: ");
            string tipo = Console.ReadLine().ToLower();

            Console.WriteLine("Digite la cantidad de patas");
            byte cantidadPatas = byte.Parse(Console.ReadLine());

            CAnimal nuevoAnimal = null;

            switch (tipo)
            {
                case "perro":
                    nuevoAnimal = new CPerro(nombre, tipo, cantidadPatas);
                    break;

                case "gato":
                    nuevoAnimal = new CGato(nombre, tipo, cantidadPatas);
                    break;

                case "canario":
                    Console.WriteLine("Digite el tamaño de las alas");
                    byte tamanoAlas = byte.Parse(Console.ReadLine());

                    nuevoAnimal = new CCanario(nombre, tipo, cantidadPatas, tamanoAlas);
                    break;
            }
            if(nuevoAnimal == null)
            {
                throw new ArgumentException("no se pudo crear el animal intentelo denuevo");
            }
            else
            {
                return nuevoAnimal;
            }
        }

    }
}
