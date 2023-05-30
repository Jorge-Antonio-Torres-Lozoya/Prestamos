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
    public class PagoesController : ControllerBase
    {
        private readonly BdContexto _context;

        public PagoesController(BdContexto context)
        {
            _context = context;
        }

        // GET: api/Pagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pago>>> GetPagos()
        {
          if (_context.Pagos == null)
          {
              return NotFound();
          }
            var pagoos = await _context.Pagos.Include(c => c.Solicitud_Prestamo).ToListAsync();
            return pagoos;
        }

        // GET: api/Pagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pago>> GetPago(int id)
        {
          if (_context.Pagos == null)
          {
              return NotFound();
          }
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            return pago;
        }

        // PUT: api/Pagoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPago(int id, Pago pago)
        {
            if (id != pago.PagoId)
            {
                return BadRequest();
            }

            _context.Entry(pago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoExists(id))
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

        // POST: api/Pagoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pago>> PostPago(Pago pago)
        {
          if (_context.Pagos == null)
          {
              return Problem("Entity set 'BdContexto.Pagos'  is null.");
          }
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPago", new { id = pago.PagoId }, pago);
        }

        // DELETE: api/Pagoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            if (_context.Pagos == null)
            {
                return NotFound();
            }
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagoExists(int id)
        {
            return (_context.Pagos?.Any(e => e.PagoId == id)).GetValueOrDefault();
        }
    }
}
