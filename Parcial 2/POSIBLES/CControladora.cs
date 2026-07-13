using System;
using System.Collections.Generic;
using Parcial2.Modelos;

namespace Parcial2
{
    internal class CControladora
    {
        private readonly List<IMaquina> maquinas = new List<IMaquina>();
        private readonly List<IOperador> operadores = new List<IOperador>();
        private readonly List<CObra> obras = new List<CObra>();
        private readonly List<CAsignacion> asignaciones = new List<CAsignacion>();

        public bool RegistrarMaquina(IMaquina maquina)
        {
            if (maquina == null)
            {
                return false;
            }

            foreach (IMaquina item in maquinas)
            {
                if (item.Codigo == maquina.Codigo)
                {
                    return false;
                }
            }

            maquinas.Add(maquina);
            return true;
        }

        public bool RegistrarOperador(IOperador operador)
        {
            if (operador == null)
            {
                return false;
            }

            foreach (IOperador item in operadores)
            {
                if (item.Legajo == operador.Legajo)
                {
                    return false;
                }
            }

            operadores.Add(operador);
            return true;
        }

        public bool RegistrarObra(CObra obra)
        {
            if (obra == null)
            {
                return false;
            }

            foreach (CObra item in obras)
            {
                if (item.Codigo == obra.Codigo)
                {
                    return false;
                }
            }

            obras.Add(obra);
            return true;
        }

        public void RegistrarAsignacion(DateTime fecha, string codigoMaquina,
                                        string codigoObra, ulong legajoOperador)
        {
            IMaquina maquina = BuscarMaquina(codigoMaquina);
            CObra obra = BuscarObra(codigoObra);
            IOperador operador = BuscarOperador(legajoOperador);

            if (maquina == null)
            {
                throw new Exception("No existe una máquina con ese código.");
            }

            if (obra == null)
            {
                throw new Exception("No existe una obra con ese código.");
            }

            if (operador == null)
            {
                throw new Exception("No existe un operador con ese legajo.");
            }

            foreach (CAsignacion item in asignaciones)
            {
                if (item.Fecha.Date == fecha.Date && item.Maquina.Codigo == maquina.Codigo)
                {
                    throw new Exception("La máquina ya está asignada en esa fecha.");
                }
            }

            if (!OperadorHabilitado(operador, maquina))
            {
                throw new Exception("El operador no está habilitado para esa máquina.");
            }

            asignaciones.Add(new CAsignacion(fecha, maquina, obra, operador));
        }

        private bool OperadorHabilitado(IOperador operador, IMaquina maquina)
        {
            string categoria = operador.Categoria.ToUpper();

            if (categoria == "A")
            {
                return true;
            }

            if (categoria == "B")
            {
                return maquina is CMaquinas && maquina is not CGrua;
            }

            if (categoria == "C")
            {
                return maquina is CMaquinas maquinaNormal && maquina is not CGrua && maquinaNormal.EsBasica;
            }

            return false;
        }

        public IMaquina BuscarMaquina(string codigo)
        {
            foreach (IMaquina item in maquinas)
            {
                if (item.Codigo == codigo)
                {
                    return item;
                }
            }
            return null;
        }

        public IOperador BuscarOperador(ulong legajo)
        {
            foreach (IOperador item in operadores)
            {
                if (item.Legajo == legajo)
                {
                    return item;
                }
            }
            return null;
        }

        public CObra BuscarObra(string codigo)
        {
            foreach (CObra item in obras)
            {
                if (item.Codigo == codigo)
                {
                    return item;
                }
            }
            return null;
        }

        /*
        // Eliminar operador por legajo.
        public bool EliminarOperador(ulong legajo)
        {
            for (int i = 0; i < operadores.Count; i++)
            {
                if (operadores[i].Legajo == legajo)
                {
                    operadores.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // Eliminar máquina por código.
        public bool EliminarMaquina(string codigo)
        {
            for (int i = 0; i < maquinas.Count; i++)
            {
                if (maquinas[i].Codigo == codigo)
                {
                    maquinas.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // Eliminar obra por código.
        public bool EliminarObra(string codigo)
        {
            for (int i = 0; i < obras.Count; i++)
            {
                if (obras[i].Codigo == codigo)
                {
                    obras.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // Eliminar asignación por código de máquina y fecha.
        public bool EliminarAsignacion(string codigoMaquina, DateTime fecha)
        {
            for (int i = 0; i < asignaciones.Count; i++)
            {
                if (asignaciones[i].Maquina.Codigo == codigoMaquina &&
                    asignaciones[i].Fecha.Date == fecha.Date)
                {
                    asignaciones.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        */

        /*
        // Una asignación se diferencia por la máquina y la fecha,
        // porque una máquina no puede estar asignada dos veces el mismo día.
        public CAsignacion BuscarAsignacion(string codigoMaquina, DateTime fecha)
        {
            foreach (CAsignacion item in asignaciones)
            {
                if (item.Maquina.Codigo == codigoMaquina && item.Fecha.Date == fecha.Date)
                {
                    return item;
                }
            }
            return null;
        }
        */

        public List<IMaquina> ObtenerMaquinas()
        {
            return maquinas;
        }

        public List<IOperador> ObtenerOperadores()
        {
            return operadores;
        }

        public List<CObra> ObtenerObras()
        {
            return obras;
        }

        public List<CAsignacion> ObtenerAsignaciones()
        {
            return asignaciones;
        }
    }
}
