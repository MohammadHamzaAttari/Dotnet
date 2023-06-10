using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Context;
using Backend.Data;
using Backend.Dtos.Company;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BackendDdContext _context;
        private readonly IMapper _mapper;

        public BookingController(BackendDdContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }

            var companies = await _context.Bookings.ToListAsync();
            var record = _mapper.Map<List<GetBookingDto>>(companies);
            return Ok(record);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCompanyDetailsDto>> GetCompany(int id)
        {
            if (_context.Companies == null)
            {
                return NotFound();
            }
            var company = await _context.Companies.Include(e => e.Models).ThenInclude(e => e.Bodies).Include(e => e.Models).ThenInclude(e => e.Trims).Where(e => e.Id == id).FirstOrDefaultAsync();

            if (company == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<GetCompanyDetailsDto>(company);
            return Ok(record);
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administration")]
        public async Task<IActionResult> PutCompany(int id, UpdateCompanyDto company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }
            var mapping = _mapper.Map<Company>(company);

            _context.Entry(mapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult<Booking>> PostCompany([FromBody] CreateBookingDto booking)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'BackendDbContext.Companies'  is null.");
            }
            var company1 = _mapper.Map<Booking>(booking);
            _context.Bookings.Add(company1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var company = await _context.Bookings.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

