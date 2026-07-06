namespace TransporteEscolar
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
                Console.WriteLine("1. Agregar personal");
                Console.WriteLine("2. Eliminar personal");
                Console.WriteLine("3. ");
                Console.WriteLine("4. Guardar datos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción:");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":

                        break;

                    case "2":
                        
                        break;

                    case "3":
                        ;
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
    }
}