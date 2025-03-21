namespace WebServiceEmpleados.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int AreaId { get; set; }
        public DateTime FechaIngreso { get; set; }

        // Relación con el área
        public Area Area { get; set; }
    }
}
