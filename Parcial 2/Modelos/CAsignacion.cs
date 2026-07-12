using System;

namespace Parcial2.Modelos
{
    internal class CAsignacion
    {
        private DateTime fecha;
        private IMaquina maquina;
        private CObra obra;
        private IOperador operador;

        public DateTime Fecha { get { return fecha; } }
        public IMaquina Maquina { get { return maquina; } }
        public CObra Obra { get { return obra; } }
        public IOperador Operador { get { return operador; } }

        public CAsignacion(DateTime fecha, IMaquina maquina, CObra obra, IOperador operador)
        {
            this.fecha = fecha;
            this.maquina = maquina;
            this.obra = obra;
            this.operador = operador;
        }
    }
}
