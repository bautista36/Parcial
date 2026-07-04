using System;
using System.IO;
using TransporteEscolar.Controladores;
using TransporteEscolar.Modelos;

namespace TransporteEscolar.Vistas
{
    public class CVista
    {
        private readonly CControladora controladora;
        private readonly string archivoDatos = "datos.txt";

        public CVista()
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

                string opcion = Console.ReadLine();

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
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private void MostrarPersonal()
        {
            Console.WriteLine("\n--- PERSONAL ---");
            foreach (ITrabajador trabajador in controladora.ObtenerTrabajadores())
            {
                Console.WriteLine(trabajador.DarDatos());
            }
        }

        private void RegistrarViaje()
        {
            Console.WriteLine("\n--- REGISTRAR VIAJE ---");
            Console.Write("Patente: ");
            string patente = Console.ReadLine();

            Console.Write("Legajo del conductor: ");
            string legajoTexto = Console.ReadLine();

            Console.Write("Destino: ");
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
                using (StreamWriter writer = new StreamWriter(archivoDatos))
                {
                    writer.WriteLine("TRABAJADORES");
                    foreach (ITrabajador trabajador in controladora.ObtenerTrabajadores())
                    {
                        writer.WriteLine($"{trabajador.GetType().Name};{trabajador.Legajo};{trabajador.Nombre};{trabajador.Apellido}");
                    }

                    writer.WriteLine("VIAJES");
                    foreach (CViaje viaje in controladora.ObtenerViajes())
                    {
                        writer.WriteLine($"{viaje.InstitucionDestino};{viaje.Conductor.Legajo};{viaje.Unidad.Patente}");
                    }
                }

                Console.WriteLine("Datos guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar: {ex.Message}");
            }
        }

        private void CargarDatos()
        {
            if (!File.Exists(archivoDatos))
            {
                return;
            }

            try
            {
                string[] lineas = File.ReadAllLines(archivoDatos);
                bool leyendoTrabajadores = false;
                bool leyendoViajes = false;

                foreach (string linea in lineas)
                {
                    if (linea == "TRABAJADORES")
                    {
                        leyendoTrabajadores = true;
                        leyendoViajes = false;
                    }

                    if (linea == "VIAJES")
                    {
                        leyendoTrabajadores = false;
                        leyendoViajes = true;
                    }

                    if (leyendoTrabajadores && !string.IsNullOrWhiteSpace(linea))
                    {
                        string[] datos = linea.Split(';');
                        if (datos.Length >= 4)
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
                    }

                    if (leyendoViajes && !string.IsNullOrWhiteSpace(linea))
                    {
                        string[] datos = linea.Split(';');
                        if (datos.Length >= 3)
                        {
                            CUnidad unidad = controladora.BuscarUnidad(datos[2]);
                            CConductor conductor = controladora.BuscarConductor(ulong.Parse(datos[1]));

                            if (unidad != null && conductor != null)
                            {
                                controladora.AgregarViaje(new CViaje(datos[0], unidad, conductor, new System.Collections.Generic.List<CAcompanante>()));
                            }
                        }
                    }
                }

                Console.WriteLine("Datos cargados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar: {ex.Message}");
            }
        }
    }
}
