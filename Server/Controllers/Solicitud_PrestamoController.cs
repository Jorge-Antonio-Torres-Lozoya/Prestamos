using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicios_Prestamos.Server;
using Servicios_Prestamos.Shared.Modelos;

namespace Servicios_Prestamos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Solicitud_PrestamoController : ControllerBase
    {
        private readonly BdContexto _context;

        public Solicitud_PrestamoController(BdContexto context)
        {
            _context = context;
        }

        // GET: api/Solicitud_Prestamo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitud_Prestamo>>> GetSolicitudes()
        {
          if (_context.Solicitudes == null)
          {
              return NotFound();
          }
            var solicitud = await _context.Solicitudes.Include(c => c.Pagos).ToListAsync();
            return solicitud;
        }

        // GET: api/Solicitud_Prestamo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud_Prestamo>> GetSolicitud_Prestamo(int id)
        {
          if (_context.Solicitudes == null)
          {
              return NotFound();
          }
            var solicitud_Prestamo = await _context.Solicitudes.FindAsync(id);

            if (solicitud_Prestamo == null)
            {
                return NotFound();
            }

            return solicitud_Prestamo;
        }

        // PUT: api/Solicitud_Prestamo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud_Prestamo(int id, Solicitud_Prestamo solicitud_Prestamo)
        {
            if (id != solicitud_Prestamo.SolicitudId)
            {
                return BadRequest();
            }

            _context.Entry(solicitud_Prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Solicitud_PrestamoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Solicitud_Prestamo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Solicitud_Prestamo>> PostSolicitud_Prestamo(Solicitud_Prestamo solicitud_Prestamo)
        {
          if (_context.Solicitudes == null)
          {
              return Problem("Entity set 'BdContexto.Solicitudes'  is null.");
          }
            _context.Solicitudes.Add(solicitud_Prestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitud_Prestamo", new { id = solicitud_Prestamo.SolicitudId }, solicitud_Prestamo);
        }

        // DELETE: api/Solicitud_Prestamo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud_Prestamo(int id)
        {
            if (_context.Solicitudes == null)
            {
                return NotFound();
            }
            var solicitud_Prestamo = await _context.Solicitudes.FindAsync(id);
            if (solicitud_Prestamo == null)
            {
                return NotFound();
            }

            _context.Solicitudes.Remove(solicitud_Prestamo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Solicitud_PrestamoExists(int id)
        {
            return (_context.Solicitudes?.Any(e => e.SolicitudId == id)).GetValueOrDefault();
        }
    }
}
