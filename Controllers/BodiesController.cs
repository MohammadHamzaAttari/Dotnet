using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend;
using Backend.Data;
using AutoMapper;
using Practice.Context;
using Backend.Dtos.Body;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodiesController : ControllerBase
    {
        private readonly BackendDdContext _context;
        private readonly IMapper _mapper;


        public BodiesController(BackendDdContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;

        }

        // GET: api/Bodies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBodyDto>>> GetBodies()
        {
            if (_context.Bodies == null)
            {
                return NotFound();
            }
            var record = await _context.Bodies.Include(w => w.Model).ToListAsync();
            var result = _mapper.Map<List<GetBodyDto>>(record);
            return Ok(result);
        }

        // GET: api/Bodies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Body>> GetBody(int id)
        {
            if (_context.Bodies == null)
            {
                return NotFound();
            }
            var body = await _context.Bodies.FindAsync(id);

            if (body == null)
            {
                return NotFound();
            }

            return body;
        }

        // PUT: api/Bodies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Dealer,Administration")]
        public async Task<IActionResult> PutBody(int id, [FromForm] UpdateBodyDto body)
        {
            if (id != body.Id)
            {
                return BadRequest();
            }

            var bodies = _context.Bodies.FirstOrDefault(e => e.Id == id);
            if (bodies != null)
            {
                bodies.Name = body.Name;
                bodies.ModelId = body.ModelId;


                using (var stream = new MemoryStream())
                {
                    body.FileUpload?.CopyTo(stream);
                    bodies.Image = stream.ToArray();
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyExists(id))
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

        // POST: api/Bodies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Dealer,Administration")]
        public async Task<ActionResult> PostBody([FromForm] CreateBodyDto Bodies)
        {

            if (Bodies == null)
            {
                return BadRequest();
            }

            try
            {
                var record = _mapper.Map<Body>(Bodies);
                if (record != null)
                {
                    var bodies = new Body
                    {
                        Name = record.Name,
                        ModelId = record.ModelId
                    };
                    using (var stream = new MemoryStream())
                    {
                        record.FileUpload?.CopyTo(stream);
                        bodies.Image = stream.ToArray();

                    }
                    await _context.Bodies.AddAsync(bodies);
                    await _context.SaveChangesAsync();

                    return Ok();
                }

                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Bodies/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Dealer,Administration")]
        public async Task<IActionResult> DeleteBody(int id)
        {
            if (_context.Bodies == null)
            {
                return NotFound();
            }
            var body = await _context.Bodies.FindAsync(id);
            if (body == null)
            {
                return NotFound();
            }

            _context.Bodies.Remove(body);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BodyExists(int id)
        {
            return (_context.Bodies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
