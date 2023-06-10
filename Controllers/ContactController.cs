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
    public class ContactController : ControllerBase
    {
        private readonly BackendDdContext _context;
        private readonly IMapper _mapper;

        public ContactController(BackendDdContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact()
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }

            var companies = await _context.Contacts.ToListAsync();

            return Ok(companies);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetCompany(int id)
        {
            if (_context.Companies == null)
            {
                return NotFound();
            }
            var company = await _context.Contacts.ToListAsync();

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
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

        public async Task<ActionResult<Contact>> PostCompany([FromBody] Contact contact)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'BackendDbContext.Companies'  is null.");
            }

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administration")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var company = await _context.Contacts.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

