using AutoMapper;
using cogip.Models;
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
            var getCompanies = new List<CompanyGetDto>();
           
            foreach (var company in companies)
            {
                var getCompany = new CompanyGetDto();
                var contactIds = new List<int>();
                var contacts = company.Contacts;
                foreach (var contact in contacts)
                {
                    contactIds.Add(contact.ContactId);
                }
                getCompany = _mapper.Map<CompanyGetDto>(company);
                getCompany.Contacts = contactIds;
                getCompanies.Add(getCompany);
            }
            return Ok(getCompanies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompanyById(int id)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(id);

            if (company == null)
                return NotFound();

            var getCompany = new CompanyGetDto();
            var contactIds = new List<int>();
            var contacts = company.Contacts;
            if (company.Contacts != null)
            {
                foreach (var contact in contacts)
                {
                    contactIds.Add(contact.ContactId);
                }
                getCompany = _mapper.Map<CompanyGetDto>(company);
                getCompany.Contacts = contactIds;
            }
            

            return Ok(getCompany);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult> PostCompany([FromBody] CompanyPostPutDto companypostputdto)
        {
            //TODO: add location provider service here
            var contacts = companypostputdto.contacts.ToList();
            var company = _mapper.Map<Company>(companypostputdto);
            company = await _companyRepository.CreateCompanyAsync(company, contacts);
            return CreatedAtAction(nameof(GetCompanyById), new { id = company.CompanyId }, company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCompany(int id, [FromBody] CompanyPostPutDto companypostputdto)
        {
            //TODO: add location provider service here
            var contacts = companypostputdto.contacts;
            var company = _mapper.Map<Company>(companypostputdto);
            company.CompanyId = id;

            await _companyRepository.UpdateCompanyAsync(id, company, contacts);
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
