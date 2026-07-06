using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using integrador2.Modelos;

namespace integrador2
{
    internal class CVista
    {
        CControladora controladora = new CControladora();
        public void Vista()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("1. Menu Empleado");
                Console.WriteLine("2. Menu Vehiculo");
                Console.WriteLine("3. Menu Dotacion");
                Console.WriteLine("4. Guardar datos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción:");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuEmpleado();
                        break;

                    case "2":
                        MenuVehiculo();
                        break;

                    case "3":
                        MenuDotacion();
                        break;

                    case "4":

                        break;

                    case "5":
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
        public void MenuEmpleado()
        {
            Console.WriteLine("1. Registrar un empleado");
            Console.WriteLine("2. Listar todos los empleados");
            Console.WriteLine("3. Eliminar un empleado");
            Console.WriteLine("4. Para volver al menu principal");
            Console.Write("Seleccione una opcion:");

            byte opcionEmpleado;
            try
            {
                opcionEmpleado = byte.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Debe ingresar un número válido.");
                return;
            }

            switch (opcionEmpleado)
            {
                case 1:
                    Console.WriteLine("Es un profesional o un chofer?:");
                    string tipo = Console.ReadLine().ToLower();
                    switch (tipo)
                    {
                        case "profesional":
                            Console.WriteLine("Digite el nombre:");
                            string nombre = Console.ReadLine();

                            Console.WriteLine("Digite el apellido");
                            string apellido = Console.ReadLine();

                            Console.WriteLine("Digite el ID:");
                            ulong id = ulong.Parse(Console.ReadLine());

                            Console.WriteLine("Digite la matricula");
                            ushort matricula = ushort.Parse(Console.ReadLine());

                            Console.WriteLine("Digite el tipo de oficio:");
                            string categoria = Console.ReadLine();

                            CProfesionales nuevo = new CProfesionales(nombre, apellido, id, matricula, categoria);
                            bool exitoProfesional = controladora.Agregar(nuevo);

                            if (exitoProfesional == false)
                            {
                                Console.WriteLine("No se pudo agregar el profesional");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Agregado con exito");
                                return;
                            }

                        case "chofer":
                            Console.WriteLine("Digite el nombre:");
                            string nombreC = Console.ReadLine();

                            Console.WriteLine("Digite el apellido");
                            string apellidoC = Console.ReadLine();

                            Console.WriteLine("Digite el ID:");
                            ulong idC = ulong.Parse(Console.ReadLine());

                            Console.WriteLine("Digite su registro:");
                            uint registro = uint.Parse(Console.ReadLine());

                            Console.WriteLine("Digite el distrito:");
                            string distrito = Console.ReadLine();

                            CChofer nuevoChofer = new CChofer(nombreC, apellidoC, idC, registro, distrito);
                            bool exitoChofer = controladora.Agregar(nuevoChofer);

                            if (exitoChofer == false)
                            {
                                Console.WriteLine("No se pudo agregar el chofer");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Agregado con exito");
                                return;
                            }
                        
                    }
                    break;

                case 2:
                    List<CEmpleado> mostrar = controladora.ListaEmpleados();


                        if (mostrar != null)
                        {
                            foreach (CEmpleado c in mostrar)
                            {
                                Console.WriteLine($"{c.Nombre} {c.Apellido} | ID: {c.Id}");
                            }
                        }
                        else { Console.WriteLine("No se registraron empleados"); return; }

                    break;
                case 3:
                    Console.WriteLine("Digite el DNI del empleado que quiere eliminar:");
                    ulong dni = ulong.Parse(Console.ReadLine());

                    bool buscar = controladora.BuscarEmpleadoDotacion(dni);
                    controladora.ElimiarEmpleado(dni);
                    if (buscar == true)
                    {
                        Console.WriteLine("MAL");
                    }
                    else
                    {
                        Console.WriteLine("Eliminado con exito");
                    }
                    break;
            }
        }
        public void MenuVehiculo()
        {
            bool volver = false;

            while (!volver)
            {
                Console.WriteLine("1. Registrar un vehiculo");
                Console.WriteLine("2. Eliminar un vehiculo");
                Console.WriteLine("3. Digite el tipo de Ambulancia para mostrar las que estan en circulacion");
                Console.WriteLine("4. Para volver al menu principal");
                Console.Write("Seleccione una opcion:");

                byte opcionVehiculo = byte.Parse(Console.ReadLine());

                switch (opcionVehiculo)
                {
                    case 1:
                        Console.WriteLine("El vehiculo que quiere registrar es ambulancia o coche?");
                        string vehiculo = Console.ReadLine().ToLower();

                        switch (vehiculo)
                        {
                            case "ambulancia":
                                
                                    // matricula modelo marca y tipo de ambulancia
                                    Console.WriteLine("Digite la matricula");
                                    string matriculaAmbulancia = Console.ReadLine();

                                    Console.WriteLine("Digite el modelo");
                                    string modelo = Console.ReadLine();

                                    Console.WriteLine("Digite la matricula");
                                    string marca = Console.ReadLine();

                                    Console.WriteLine("Digite el tipo de ambulancia");
                                    string tipo = Console.ReadLine();

                                    CAmbulancia nuevaAmbulancia = new CAmbulancia(matriculaAmbulancia, marca, modelo, tipo);
                                    bool exitoAmbulancia = controladora.Agregar(nuevaAmbulancia);

                                    if (exitoAmbulancia == false)
                                    {
                                        Console.WriteLine("No se pudo agregar el coche");
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Agregado con exito");
                                        return;
                                    }
                                

                            case "coche":
                                // matricula modelo marca
                                Console.WriteLine("Digite la matricula");
                                string matriculaCoche = Console.ReadLine();

                                Console.WriteLine("Digite el modelo");
                                string modeloCoche = Console.ReadLine();

                                Console.WriteLine("Digite la matricula");
                                string marcaCoche = Console.ReadLine();

                                CVehiculo nuevoCoche = new CVehiculo(matriculaCoche, marcaCoche, modeloCoche);
                                bool exitoCoche = controladora.Agregar(nuevoCoche);

                                if (exitoCoche == false)
                                {
                                    Console.WriteLine("No se pudo agregar el coche");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Agregado con exito");
                                    return;
                                }

                        }
                        break;
                    case 2:
                        foreach (CVehiculo vehiculos in controladora.ListaVehiculos())
                        {
                            if (vehiculos is CAmbulancia ambulancia)
                            {
                                Console.WriteLine($"Es una ambulancia: {ambulancia.Patente} - {ambulancia.TipoAmbulancia}");
                            }
                            else
                            {
                                Console.WriteLine($"Es un coche: {vehiculos.Patente} - {vehiculos.Marca} - {vehiculos.Modelo}");
                            }
                        }
                        break;

                    case 3:
                        /*int cantidad = controladora.ContarAmbulanciasPorTipo("EMG");
                        Console.WriteLine($"Cantidad: {cantidad}");*/
                        return;

                    default:
                        Console.WriteLine("Opcion no valida");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    
                }
            }
        }
        public void MenuDotacion()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("1. Registrar una nueva dotacion");
                Console.WriteLine("2. Listar dotaciones");
                Console.WriteLine("3. Para volver al menu principal");
                Console.Write("Seleccione una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                    {
                        Console.WriteLine("Digite la fecha:");
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                        {
                            Console.WriteLine("Fecha inválida.");
                            return;
                        }

                        Console.WriteLine("Digite la patente del vehiculo");
                        string patente = Console.ReadLine() ?? "";

                        Console.WriteLine("Digite el legajo del chofer");
                        if (!ulong.TryParse(Console.ReadLine(), out ulong legajo))
                        {
                            Console.WriteLine("El legajo debe ser numérico.");
                            return;
                        }

                        Console.WriteLine("Cuantos profesionales van a ir en el vehiculo?:");
                        if (!byte.TryParse(Console.ReadLine(), out byte numero))
                        {
                            Console.WriteLine("Número inválido.");
                            return;
                        }

                        List<ulong> legajosProfesionales = new();
                        for (int i = 0; i < numero; i++)
                        {
                            Console.WriteLine("Digite el legajo del profesional:");
                            if (!ulong.TryParse(Console.ReadLine(), out ulong id))
                            {
                                Console.WriteLine("Legajo inválido.");
                                return;
                            }

                            legajosProfesionales.Add(id);
                        }

                        CChofer? chofer = controladora.BuscarChoferPorId(legajo);
                        CVehiculo? vehiculo = controladora.BuscarVehiculoPorPatente(patente);

                        if (chofer is null)
                        {
                            Console.WriteLine("No existe ese chofer.");
                            return;
                        }

                        if (vehiculo is null)
                        {
                            Console.WriteLine("No existe ese vehículo.");
                            return;
                        }

                        List<CProfesionales> profesionales = controladora.BuscarProfesionalesPorIds(legajosProfesionales);

                        CDotacion nuevaD = new CDotacion(fecha, chofer, profesionales, vehiculo);
                        controladora.AgregarDotacion(nuevaD);

                        Console.WriteLine("Dotación agregada con éxito.");
                        break;
                    }
                       

                    case "2":
                        List<CDotacion> mostrar = controladora.ListaDotaciones();

                        foreach(CDotacion c in mostrar)
                        {
                            Console.WriteLine($"{c.Chofer} | {c.Vehiculo} | {c.Profesionales} | {c.Fecha}");
                        }
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Opcion no valida");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
