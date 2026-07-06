using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrador1;

namespace Intregrador1
{
    internal class CControladora
    {
        private static readonly string ArchivoTextoJugadores = "listaJugadores.txt";
        private static readonly string ArchivoTextoEquipos = "listaEquipos.txt";
        private static readonly string ArchivoTextoEntrenadores = "listaEntrenadores.txt";

        private static readonly char Delimitador = ';';

        private List<CJugadores> jugadores;
        private List<CEquipos> equipos;
        private List<CEntrenador> entrenadores;
        private List<IParticipante> todos;
        public CControladora()
        {
            jugadores = new List<CJugadores>();
            equipos = new List<CEquipos>();
            entrenadores = new List<CEntrenador>();
            todos = new List<IParticipante>();

            CargarJugadores();
            CargarEntrenadores();
            CargarEquipos();
        }
        public void CargaJugadores (CJugadores c)
        {
            jugadores.Add (c);
        }
        public void CargaEquipos(CEquipos c)
        {
            equipos.Add (c);
        }
        public void CargaEntrenadores(CEntrenador c)
        {
            entrenadores.Add (c);
        }
        public IParticipante ObtenerTodos()
        {
            return (IParticipante)todos;
        }
        public bool BuscarEntrenador(int id)
        {
            bool existe = false;

            foreach(CEntrenador entrenador in entrenadores)
            {
                if(entrenador.Dni == id)
                {
                    existe = true;
                    
                }
            }

            return existe;
        }
        public List<IParticipante> ObtenerTodosLosParticipantes()
        {
            
            todos.AddRange(jugadores);

            todos.AddRange(entrenadores);

            todos.Sort((p1, p2) => p1.Apellido.CompareTo(p2.Apellido));

            return todos;
        }
        public void MostrarJugadores ()
        {
            if(jugadores == null)
            {
                throw new Exception("No se almaceno ningun jugador de momento\n");
            }
            else
            {
                foreach(CJugadores mostrar in jugadores)
                {
                    Console.WriteLine ($"{mostrar.Nombre}, {mostrar.Apellido}, {mostrar.Posicion}, {mostrar.Dni}, {mostrar.Fecha}");
                }
            }
        }
        public void MostrarEntrenadores()
        {
            if(jugadores == null)
            {
                throw new Exception("No se almaceno ningun entrenador de momento\n");
            }
            else
            {
                foreach (CEntrenador mostrar in entrenadores)
                {
                    Console.WriteLine($"{mostrar.Nombre}, {mostrar.Apellido}, {mostrar.Telefono}, {mostrar.Dni}");
                }
            }
        }
        public bool EliminarJugador(int eliminar)
        {
            bool existe = false;
            CJugadores jugadorAEliminar = null;

            foreach (CJugadores jugador in jugadores)
            {
                if (eliminar == jugador.Dni)
                {
                    jugadorAEliminar = jugador;
                    break;
                }
            }
            if (jugadorAEliminar != null)
            {
                foreach (CEquipos equipo in equipos)
                {
                    jugadores.Remove(jugadorAEliminar);

                    CJugadores jugadorEnEquipo = null;

                    foreach (CJugadores c in equipo.Jugadores)
                    {

                        if (c.Dni == eliminar)
                        {
                            jugadorEnEquipo = c;
                            break;
                        }
                    }
                    if (jugadorEnEquipo != null)
                    {
                        equipo.Jugadores.Remove(jugadorEnEquipo);
                        break;
                    }
                }
                return existe = true;
            }
            else
            {
                return existe;
            }
        }
        public void AlistarJugador(int alistar, string codigo)
        {
            CEquipos equipoEncontrado = null;
            foreach (CEquipos equipo in equipos)
            {
                if (equipo.Codigo == codigo)
                {
                    equipoEncontrado = equipo;
                    break;
                }
            }
            CJugadores encontrado = null;

            if ( equipoEncontrado != null)
            {

                foreach (CJugadores jugador in jugadores)
                {
                    if (alistar == jugador.Dni)
                    {
                        encontrado = jugador;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No se encontro el jugador");
                    }
                }
                foreach (CEquipos eq in equipos)
                {
                    foreach (CJugadores j in eq.Jugadores)
                    {
                        if (j.Dni == alistar)
                        {
                            Console.WriteLine($"Error: El jugador ya está asociado al equipo {eq.Nombre}.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontro el equipo");
            }
            equipoEncontrado.Jugadores.Add(encontrado);


        }
        public void PasarAGuardarDatos()
        {
            GuardarDatos(jugadores);
            GuardarDatos(entrenadores);
            GuardarDatos(equipos);
        }
        private void CargarJugadores()
        {
            if (File.Exists(ArchivoTextoJugadores))
            {
                string[] lineas = File.ReadAllLines(ArchivoTextoJugadores);

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(Delimitador);

                    string nombre = datos[0];
                    string apellido = datos[1];
                    int dni = int.Parse(datos[2]);
                    DateTime fecha = DateTime.Parse(datos[3]);
                    string posicion = datos[4];
                   

                    CJugadores jugadorRecuperado = new CJugadores(nombre, apellido, dni, fecha, posicion);
                    jugadores.Add(jugadorRecuperado);
                }
            }
        }
        private void CargarEntrenadores()
        {
            try
            {
                List<string> lineas = new List<string>();

                // Usamos directamente la lista privada 'entrenadores'
                foreach (CEntrenador e in entrenadores)
                {
                    lineas.Add($"{e.Nombre}{Delimitador}{e.Apellido}{Delimitador}{e.Dni}{Delimitador}{e.Telefono}");
                }

                File.WriteAllLines(ArchivoTextoEntrenadores, lineas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al guardar entrenadores: {ex.Message}");
            }
        }

        private void CargarEquipos()
        {
            try
            {
                List<string> lineas = new List<string>();

                // Usamos directamente la lista privada 'equipos'
                foreach (CEquipos eq in equipos)
                {
                    string coloresUnidos = string.Join(",", eq.Colores);
                    lineas.Add($"{eq.Nombre}{Delimitador}{coloresUnidos}{Delimitador}{eq.Codigo}{Delimitador}{eq.EntrenadorAsignado}");
                }

                File.WriteAllLines(ArchivoTextoEquipos, lineas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al guardar equipos: {ex.Message}");
            }
        }
        public static void GuardarDatos(List<CJugadores> jugador)
        {
            try
            {                
                List<string> lineas = new List<string>();

                foreach (CJugadores niga in jugador)
                {
                    lineas.Add($"{niga.Nombre}{Delimitador}{niga.Apellido}{Delimitador}{niga.Posicion}{Delimitador}{niga.Dni}{Delimitador}{niga.Fecha}");
                }

                File.WriteAllLines(ArchivoTextoJugadores, lineas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al guardar los datos: {ex.Message}");
            }
        }
        public static void GuardarDatos(List<CEquipos> equipos)
        {
            try
            {
                List<string> lineas = new List<string>();

                foreach (CEquipos niga in equipos)
                {
                    lineas.Add($"{niga.Nombre}{Delimitador}{niga.Colores}{Delimitador}{niga.Codigo}{niga.EntrenadorAsignado}");
                }

                File.WriteAllLines(ArchivoTextoEquipos, lineas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al guardar los datos: {ex.Message}");
            }
        }
        public static void GuardarDatos(List<CEntrenador> entrenador)
        {
            try
            {
                List<string> lineas = new List<string>();

                foreach (CEntrenador niga in entrenador)
                {
                    lineas.Add($"{niga.Nombre}{Delimitador}{niga.Apellido}{Delimitador}{niga.Telefono}{niga.Dni}");
                }

                File.WriteAllLines(ArchivoTextoEntrenadores, lineas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al guardar los datos: {ex.Message}");
            }
        }
    }
}
