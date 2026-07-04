// Legajo: 31127 - Apellidos y Nombres: Avena Bautista
namespace TransporteEscolar
{
    public interface ITrabajador
    {
        ulong Legajo { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }

        string DarDatos();
    }
}
