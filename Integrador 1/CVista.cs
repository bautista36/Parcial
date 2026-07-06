using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Integrador1;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Intregrador1
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
                Console.WriteLine("1. Nuevo Jugador");
                Console.WriteLine("2. Nuevo Entrenador");
                Console.WriteLine("3. Nuevo Equipo");
                Console.WriteLine("4. Mostrar todos los jugadores");
                Console.WriteLine("5. Mostrar todos los entrenadores");
                Console.WriteLine("6. Alistar un jugador");
                Console.WriteLine("7. Eliminar jugador");
                Console.WriteLine("8. Guardar datos");
                Console.WriteLine("9. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CJugadores nuevo = CargaJugadores();

                        controladora.CargaJugadores(nuevo);
                        break;

                    case "2":
                        CEntrenador nuevoEntrenador = CargaEntrenadores();

                        controladora.CargaEntrenadores(nuevoEntrenador);
                        break;

                    case "3":

                        CEquipos nuevoEquipo = CargaEquipos(controladora);

                        controladora.CargaEquipos(nuevoEquipo);
                        break;

                    case "4":
                        controladora.MostrarJugadores();
                        break;

                    case "5":
                        controladora.MostrarEntrenadores();
                        break;
                    case "6":
                        Console.WriteLine("Digite el DNI del jugador que quiere alistar");
                        int alistar = int.Parse(Console.ReadLine());

                        Console.WriteLine("A que equipo lo quiere designar");
                        string codigo = Console.ReadLine();

                        controladora.AlistarJugador(alistar,codigo);
                        break;

                    case "7":
                        Console.WriteLine("Digite el DNI del jugador que quiera eliminar");
                        int eliminar = int.Parse(Console.ReadLine());

                        bool existe = controladora.EliminarJugador(eliminar);

                        controladora.EliminarJugador(eliminar);
                        break;

                    case "8":
                        controladora.PasarAGuardarDatos();

                        break;

                    case "9":
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
        public CJugadores CargaJugadores()
        {
            CJugadores nuevoJugador = null;

            Console.WriteLine("Digite el nombre del jugador:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Digite el apellido del jugador:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Digite el DNI del jugador:");
            int dni = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite la fecha de nacimiento del jugador (dd/MM/yyyy):");
            string entrada = Console.ReadLine();

            if (!DateTime.TryParse(entrada, out DateTime fechaNacimiento))
            {
                throw new Exception("La fecha ingresada no es válida.");
            }

            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18 || edad > 45)
            {
                throw new Exception("El jugador debe tener entre 18 y 45 años.");
            }

            Console.WriteLine("Digite la posicion de juego del jugador:");
            string posicion = Console.ReadLine();

            nuevoJugador = new CJugadores(nombre,apellido,dni,fechaNacimiento,posicion);

            if (nuevoJugador == null)
            {
                throw new ArgumentException("no se pudo crear el animal intentelo denuevo");
            }
            else
            {
                return nuevoJugador;
            }
        }
        public CEquipos CargaEquipos(CControladora controladora)
        {
            CEquipos nuevoEquipo = null;

            Console.WriteLine("Digite el nombre del equipo:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Digite el codigo del equipo:");
            string codigo = Console.ReadLine();

            Console.WriteLine("Digite los colores que representan al equipo (maximo tres):");
            string colores = Console.ReadLine();
  

            Console.WriteLine("Digite el DNI del entrenador que quiere para su equipo:");
            int dniEntrenador = int.Parse(Console.ReadLine());

            bool entrenadorAsignado = controladora.BuscarEntrenador(dniEntrenador);

            switch(entrenadorAsignado)
            {
                case true:
                    nuevoEquipo = new CEquipos(nombre, codigo, colores, dniEntrenador);
                    break;

                case false:
                    Console.WriteLine("No se encontro el entrenador");
                    break;
            }
            if (nuevoEquipo != null)
            {
                return nuevoEquipo;
            }
            else 
            { 
                throw new Exception("No se pudo crear el equipo"); 
            }
        }
        public CEntrenador CargaEntrenadores ()
        {
            Console.Write("Digite el nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Digite el apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Digite el DNI: ");
            int dni = int.Parse(Console.ReadLine());

            Console.Write("Digite el teléfono: ");
            long telefono = long.Parse(Console.ReadLine());

            return new CEntrenador(nombre, apellido, dni, telefono);
        }
    }
}
