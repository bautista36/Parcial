using System;

namespace integrador2.Modelos
{
    interface IEmpleado
    {
        ulong Id { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }

        string DarDatos();
    }
}
