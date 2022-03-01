using CogipRestAPI.Domain.Abstractions;
using CogipRestAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CogipRestAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly DataContext _context;
        private readonly HttpContext _http;

        public CompanyController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _http = httpContextAccessor.HttpContext;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult> GetAllCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            return Ok(companies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompanyById(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(h => h.CompanyId == id);

            if (company == null)
                return NotFound();

            //var CompanyGet = _mapper.Map<CompanyGetDto>(company);

            return Ok(company);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult> PostCompany([FromBody] Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCompanyById), new { id = company.CompanyId }, company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCompany(int id, [FromBody] Company company)
        {
            company.CompanyId = id;

            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);

            if (company == null)
                return NotFound();

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
