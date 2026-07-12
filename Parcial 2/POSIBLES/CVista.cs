using System;
using System.IO;
using Parcial2.Modelos;

namespace Parcial2
{
    internal class CVista
    {
        private readonly CControladora controladora = new CControladora();
        private const string Archivo = "datosAlquiObras.txt";

        public CVista()
        {
            CargarDatos();
        }

        public void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("--- ALQUIOBRAS S.A. ---");
                Console.WriteLine("1. Registrar operador");
                Console.WriteLine("2. Registrar máquina");
                Console.WriteLine("3. Registrar obra");
                Console.WriteLine("4. Registrar asignación");
                Console.WriteLine("5. Listar operadores");
                Console.WriteLine("6. Listar máquinas");
                Console.WriteLine("7. Guardar datos");
                Console.WriteLine("8. Salir");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": RegistrarOperador(); break;
                    case "2": RegistrarMaquina(); break;
                    case "3": RegistrarObra(); break;
                    case "4": RegistrarAsignacion(); break;
                    case "5": ListarOperadores(); break;
                    case "6": ListarMaquinas(); break;
                    case "7": GuardarDatos(); break;
                    case "8": salir = true; continue;
                    default: Console.WriteLine("Opción inválida."); break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void RegistrarOperador()
        {
            Console.Write("Legajo: ");
            if (!ulong.TryParse(Console.ReadLine(), out ulong legajo))
            {
                Console.WriteLine("El legajo debe ser numérico.");
                return;
            }

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine() ?? string.Empty;
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.Write("Categoría (A, B o C): ");
            string categoria = (Console.ReadLine() ?? string.Empty).ToUpper();

            if (categoria != "A" && categoria != "B" && categoria != "C")
            {
                Console.WriteLine("Categoría inválida.");
                return;
            }

            bool registrado = controladora.RegistrarOperador(
                new COperador(legajo, apellido, nombre, categoria));
            Console.WriteLine(registrado ? "Operador registrado." : "Legajo duplicado.");
        }

        private void RegistrarMaquina()
        {
            Console.Write("Tipo (1: básica, 2: pesada, 3: grúa): ");
            string tipo = Console.ReadLine() ?? string.Empty;
            Console.Write("Código: ");
            string codigo = Console.ReadLine() ?? string.Empty;
            Console.Write("Marca: ");
            string marca = Console.ReadLine() ?? string.Empty;
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine() ?? string.Empty;

            IMaquina maquina;
            if (tipo == "1")
            {
                maquina = new CMaquinas(codigo, marca, modelo, true);
            }
            else if (tipo == "2")
            {
                maquina = new CMaquinas(codigo, marca, modelo, false);
            }
            else if (tipo == "3")
            {
                Console.Write("Capacidad en toneladas: ");
                if (!double.TryParse(Console.ReadLine(), out double capacidad) || capacidad <= 0)
                {
                    Console.WriteLine("Capacidad inválida.");
                    return;
                }
                maquina = new CGrua(codigo, marca, modelo, capacidad);
            }
            else
            {
                Console.WriteLine("Tipo inválido.");
                return;
            }

            Console.WriteLine(controladora.RegistrarMaquina(maquina)
                ? "Máquina registrada." : "Código duplicado.");
        }

        private void RegistrarObra()
        {
            Console.Write("Código: ");
            string codigo = Console.ReadLine() ?? string.Empty;
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.Write("Ubicación: ");
            string ubicacion = Console.ReadLine() ?? string.Empty;

            Console.WriteLine(controladora.RegistrarObra(new CObra(codigo, nombre, ubicacion))
                ? "Obra registrada." : "Código duplicado.");
        }

        private void RegistrarAsignacion()
        {
            Console.Write("Fecha: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("Fecha inválida.");
                return;
            }

            Console.Write("Código de máquina: ");
            string codigoMaquina = Console.ReadLine() ?? string.Empty;
            Console.Write("Código de obra: ");
            string codigoObra = Console.ReadLine() ?? string.Empty;
            Console.Write("Legajo del operador: ");
            if (!ulong.TryParse(Console.ReadLine(), out ulong legajo))
            {
                Console.WriteLine("Legajo inválido.");
                return;
            }

            try
            {
                controladora.RegistrarAsignacion(fecha, codigoMaquina, codigoObra, legajo);
                Console.WriteLine("Asignación registrada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void ListarOperadores()
        {
            foreach (IOperador operador in controladora.ObtenerOperadores())
                operador.MostrarDatos();
        }

        private void ListarMaquinas()
        {
            foreach (IMaquina maquina in controladora.ObtenerMaquinas())
                maquina.MostrarDatos();
        }

        private void GuardarDatos()
        {
            try
            {
                using (StreamWriter archivo = new StreamWriter(Archivo))
                {
                    archivo.WriteLine("OPERADORES");
                    foreach (IOperador operador in controladora.ObtenerOperadores())
                    {
                        archivo.WriteLine(operador.Legajo + ";" + operador.Apellido + ";" +
                                          operador.Nombre + ";" + operador.Categoria);
                    }

                    archivo.WriteLine("MAQUINAS");
                    foreach (IMaquina maquina in controladora.ObtenerMaquinas())
                    {
                        if (maquina is CGrua)
                        {
                            CGrua grua = (CGrua)maquina;
                            archivo.WriteLine("GRUA;" + grua.Codigo + ";" + grua.Marca + ";" +
                                              grua.Modelo + ";" + grua.Capacidad);
                        }
                        else
                        {
                            CMaquinas maquinaComun = (CMaquinas)maquina;
                            archivo.WriteLine("MAQUINA;" + maquina.Codigo + ";" + maquina.Marca + ";" +
                                              maquina.Modelo + ";" + maquinaComun.EsBasica);
                        }
                    }

                    archivo.WriteLine("OBRAS");
                    foreach (CObra obra in controladora.ObtenerObras())
                    {
                        archivo.WriteLine(obra.Codigo + ";" + obra.Nombre + ";" + obra.Ubicacion);
                    }

                    archivo.WriteLine("ASIGNACIONES");
                    foreach (CAsignacion asignacion in controladora.ObtenerAsignaciones())
                    {
                        archivo.WriteLine(asignacion.Fecha.ToString("yyyy-MM-dd") + ";" +
                                          asignacion.Maquina.Codigo + ";" +
                                          asignacion.Obra.Codigo + ";" +
                                          asignacion.Operador.Legajo);
                    }
                }

                Console.WriteLine("Datos guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar: " + ex.Message);
            }
        }

        private void CargarDatos()
        {
            if (!File.Exists(Archivo))
            {
                return;
            }

            try
            {
                string[] lineas = File.ReadAllLines(Archivo);
                string seccion = "";

                foreach (string linea in lineas)
                {
                    if (linea == "OPERADORES" || linea == "MAQUINAS" ||
                        linea == "OBRAS" || linea == "ASIGNACIONES")
                    {
                        seccion = linea;
                    }
                    else if (linea != "")
                    {
                        string[] datos = linea.Split(';');

                        if (seccion == "OPERADORES" && datos.Length == 4)
                        {
                            controladora.RegistrarOperador(new COperador(
                                ulong.Parse(datos[0]), datos[1], datos[2], datos[3]));
                        }
                        else if (seccion == "MAQUINAS" && datos[0] == "MAQUINA" && datos.Length == 5)
                        {
                            controladora.RegistrarMaquina(new CMaquinas(
                                datos[1], datos[2], datos[3], bool.Parse(datos[4])));
                        }
                        else if (seccion == "MAQUINAS" && datos[0] == "GRUA" && datos.Length == 5)
                        {
                            controladora.RegistrarMaquina(new CGrua(
                                datos[1], datos[2], datos[3], double.Parse(datos[4])));
                        }
                        else if (seccion == "OBRAS" && datos.Length == 3)
                        {
                            controladora.RegistrarObra(new CObra(datos[0], datos[1], datos[2]));
                        }
                        else if (seccion == "ASIGNACIONES" && datos.Length == 4)
                        {
                            controladora.RegistrarAsignacion(DateTime.Parse(datos[0]),
                                datos[1], datos[2], ulong.Parse(datos[3]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los datos: " + ex.Message);
            }
        }
    }
}
