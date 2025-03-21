namespace WebServiceEmpleados.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int AreaId { get; set; }
        public DateTime FechaIngreso { get; set; }

        // Relaci�n con el �rea
        public Area Area { get; set; }
    }
}
