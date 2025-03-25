using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebServiceEmpleados.Data;
using WebServiceEmpleados.Models;

namespace WebServiceEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Consultar todos los empleados (GET)
        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> GetEmpleados()
        {
            return _context.Empleados.ToList();
        }

        // 2. Consultar un empleado por ID (GET)
        [HttpGet("{id}")]
        public ActionResult<Empleado> GetEmpleado(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado == null) return NotFound();
            return empleado;
        }

        // 3. Insertar un nuevo empleado (POST)
        [HttpPost]
        public ActionResult<Empleado> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, empleado);
        }

        // 4. Modificar un empleado existente (PUT)
        [HttpPut("{id}")]
        public IActionResult PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.Id) return BadRequest();
            _context.Entry(empleado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // 5. Eliminar un empleado (DELETE)
        [HttpDelete("{id}")]
        public IActionResult DeleteEmpleado(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado == null) return NotFound();
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
