using System;
using System.Collections.Generic;
using System.IO;
using TransporteEscolar.Controladores;
using TransporteEscolar.Modelos;

namespace TransporteEscolar
{
    internal class CVista1
    {
        private readonly CControladora controladora;
        private static readonly string ArchivoTexto = "datos.txt";
        private static readonly char Delimitador = ';';

        public CVista1()
        {
            controladora = new CControladora();
            CargarDatos();
        }

        public void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("1. Mostrar personal");
                Console.WriteLine("2. Registrar viaje");
                Console.WriteLine("3. Guardar datos");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1":
                        MostrarPersonal();
                        break;

                    case "2":
                        RegistrarViaje();
                        break;

                    case "3":
                        GuardarDatos();
                        break;

                    case "4":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private void MostrarPersonal()
        {
            foreach (ITrabajador trabajador in controladora.ObtenerTrabajadores())
            {
                Console.WriteLine(trabajador.DarDatos());
            }
        }

        private void RegistrarViaje()
        {
            Console.Clear();
            Console.WriteLine("\n--- REGISTRAR VIAJE ---");
            Console.Write("Patente: ");
            string patente = Console.ReadLine();

            Console.WriteLine("Legajo del conductor: ");
            string legajoTexto = Console.ReadLine();

            Console.WriteLine("Destino: ");
            string destino = Console.ReadLine();

            try
            {
                ulong legajo = ulong.Parse(legajoTexto);
                controladora.RegistrarViaje(patente, legajo, destino);
                Console.WriteLine("Viaje registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void GuardarDatos()
        {
            try
            {
                List<string> lineas = new List<string>();

                lineas.Add("TRABAJADORES");
                foreach (ITrabajador trabajador in controladora.ObtenerTrabajadores())
                {
                    lineas.Add($"{trabajador.GetType().Name}{Delimitador}{trabajador.Legajo}{Delimitador}{trabajador.Nombre}{Delimitador}{trabajador.Apellido}");
                }

                lineas.Add("VIAJES");
                foreach (CViaje viaje in controladora.ObtenerViajes())
                {
                    lineas.Add($"{viaje.InstitucionDestino}{Delimitador}{viaje.Conductor.Legajo}{Delimitador}{viaje.Unidad.Patente}");
                }

                File.WriteAllLines(ArchivoTexto, lineas);
                Console.WriteLine("Datos guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los datos: {ex.Message}");
            }
        }

        private void CargarDatos()
        {
            if (!File.Exists(ArchivoTexto))
            {
                return;
            }

            try
            {
                string[] lineas = File.ReadAllLines(ArchivoTexto);
                bool leyendoTrabajadores = false;
                bool leyendoViajes = false;

                foreach (string linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea))
                    {
                        //Ignora las líneas vacias
                    }
                    else if (linea == "TRABAJADORES")
                    {
                        leyendoTrabajadores = true;
                        leyendoViajes = false;
                    }
                    else if (linea == "VIAJES")
                    {
                        leyendoTrabajadores = false;
                        leyendoViajes = true;
                    }
                    else
                    {
                        string[] datos = linea.Split(Delimitador);

                        if (leyendoTrabajadores && datos.Length >= 4)
                        {
                            if (datos[0] == "CConductor")
                            {
                                controladora.AgregarTrabajador(new CConductor(ulong.Parse(datos[1]), datos[3], datos[2], 0, 'A'));
                            }
                            else if (datos[0] == "CAcompanante")
                            {
                                controladora.AgregarTrabajador(new CAcompanante(ulong.Parse(datos[1]), datos[3], datos[2], false));
                            }
                        }
                        else if (leyendoViajes && datos.Length >= 3)
                        {
                            CUnidad unidad = controladora.BuscarUnidad(datos[2]);
                            CConductor conductor = controladora.BuscarConductor(ulong.Parse(datos[1]));

                            if (unidad != null && conductor != null)
                            {
                                controladora.AgregarViaje(new CViaje(datos[0], unidad, conductor, new List<CAcompanante>()));
                            }
                        }
                    }
                }

                Console.WriteLine("Datos cargados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los datos: {ex.Message}");
            }
        }
    }
}