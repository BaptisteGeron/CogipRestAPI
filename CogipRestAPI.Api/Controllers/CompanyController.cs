using AutoMapper;
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
        private readonly HttpContext _http;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _http = httpContextAccessor.HttpContext;
            _mapper = mapper;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllCompaniesAsync();
            return Ok(companies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompanyById(int id)
        {
            var company = _companyRepository.GetCompanyByIdAsync(id);

            if (company == null)
                return NotFound();

            //var CompanyGet = _mapper.Map<CompanyGetDto>(company);

            return Ok(company);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult> PostCompany([FromBody] Company company)
        {
            company = await _companyRepository.CreateCompanyAsync(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = company.CompanyId }, company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCompany(int id, [FromBody] Company company)
        {
            company.CompanyId = id;

            await _companyRepository.UpdateCompanyAsync(id, company);
            return NoContent();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var company = await _companyRepository.DeleteCompanyAsync(id);

            if (company == null)
                return NotFound();

            return NoContent();
        }
    }
}
