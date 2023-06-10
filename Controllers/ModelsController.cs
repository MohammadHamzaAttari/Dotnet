using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Context;
using Backend.Data;
using Backend.Dtos.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly BackendDdContext _context;
        private readonly IMapper _mapper;

        public ModelsController(BackendDdContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        // GET: api/Models
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetModelDto>>> GetModels()
        {
            if (_context.Models == null)
            {
                return NotFound();
            }
            var record = await _context.Models.ToListAsync();
            var result = _mapper.Map<IEnumerable<GetModelDto>>(record);
            return Ok(result);
        }
        [HttpGet]
        [Route(("dealerModels"))]
        public async Task<ActionResult<IEnumerable<ModelDetailsDto>>> DealerModels()
        {
            if (_context.Models == null)
            {
                return NotFound();
            }
            var record = await _context.Models.Include(e => e.Bodies).Include(w => w.Trims).ToListAsync();
            var result = _mapper.Map<IEnumerable<ModelDetailsDto>>(record);
            return Ok(result);
        }
        // GET: api/Models/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelDetailsDto>> GetModel(int id)
        {
            if (_context.Models == null)
            {
                return NotFound();
            }
            var model = await _context.Models.Include(e => e.Bodies).Include(w => w.Trims).FirstOrDefaultAsync(e => e.Id == id);

            if (model == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<ModelDetailsDto>(model);
            return record;
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Dealer,Administration")]
        public async Task<IActionResult> PutModel(int id, [FromForm] UpdateModelDto model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var models = _context.Models.FirstOrDefault(e => e.Id == id);
            if (models != null)
            {
                models.Name = model.Name;
                models.CompanyId = model.CompanyId;
                models.Date = model.Date;
                models.Price = model.Price;
                using (var stream = new MemoryStream())
                {
                    model.FileUpload?.CopyTo(stream);
                    models.Image = stream.ToArray();
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Dealer,Administration")]
        public async Task<ActionResult> PostModel([FromForm] CreateModelDto model)
        {
            if (_context.Models == null)
            {
                return Problem("Entity set 'BackendDbContext.Models'  is null.");
            }
            try
            {
                var record = _mapper.Map<Model>(model);
                if (record != null)
                {
                    var models = new Model
                    {
                        Name = record.Name,
                        CompanyId = record.CompanyId,
                        Price = record.Price,
                        Date = record.Date
                    };
                    using (var stream = new MemoryStream())
                    {
                        record.FileUpload?.CopyTo(stream);
                        models.Image = stream.ToArray();

                    }
                    await _context.Models.AddAsync(models);
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
        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Dealer,Administration")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            if (_context.Models == null)
            {
                return NotFound();
            }
            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelExists(int id)
        {
            return (_context.Models?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
