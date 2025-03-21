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

        [HttpGet]
        public ActionResult<IEnumerable<Area>> GetAreas()
        {
            return _context.Areas.ToList();
        }

        [HttpPost]
        public ActionResult<Area> PostArea(Area area)
        {
            _context.Areas.Add(area);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAreas), new { id = area.Id }, area);
        }
    }
}
