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

        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> GetEmpleados()
        {
            return _context.Empleados.ToList();
        }

        [HttpPost]
        public ActionResult<Empleado> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmpleados), new { id = empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        public IActionResult PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.Id) return BadRequest();

            _context.Entry(empleado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

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
