using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebServiceEmpleados.Data;
using WebServiceEmpleados.Models;

namespace WebServiceEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Consultar todas las áreas (GET)
        [HttpGet]
        public ActionResult<IEnumerable<Area>> GetAreas()
        {
            return _context.Areas.ToList();
        }

        // 2. Consultar un área por ID (GET)
        [HttpGet("{id}")]
        public ActionResult<Area> GetArea(int id)
        {
            var area = _context.Areas.Find(id);
            if (area == null) return NotFound();
            return area;
        }

        // 3. Insertar un nuevo área (POST)
        [HttpPost]
        public ActionResult<Area> PostArea(Area area)
        {
            _context.Areas.Add(area);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetArea), new { id = area.Id }, area);
        }

        // 4. Modificar un área existente (PUT)
        [HttpPut("{id}")]
        public IActionResult PutArea(int id, Area area)
        {
            if (id != area.Id) return BadRequest();
            _context.Entry(area).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // 5. Eliminar un área (DELETE)
        [HttpDelete("{id}")]
        public IActionResult DeleteArea(int id)
        {
            var area = _context.Areas.Find(id);
            if (area == null) return NotFound();
            _context.Areas.Remove(area);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
