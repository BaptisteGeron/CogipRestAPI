using AutoMapper;
using cogip.Models;
using CogipRestAPI.Domain.Abstractions.Repositories;
using CogipRestAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CogipRestAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        public ContactController(IMapper mapper, IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
            var getContacts = new List<ContactGetDto>();

            foreach (var contact in contacts)
            {
                var getContact = new ContactGetDto();
                var companyIds = new List<int>();
                var companies = contact.Companies;
                foreach (var company in companies)
                {
                    companyIds.Add(company.CompanyId);
                }
                getContact = _mapper.Map<ContactGetDto>(contact);
                getContact.companies = companyIds;
                getContacts.Add(getContact);

            }
            return Ok(getContacts);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null)
                return NotFound();

            var getContact = new ContactGetDto();
            var companyIds = new List<int>();
            var companies = contact.Companies;
            if (contact.Companies != null)
            {
                foreach (var company in companies)
                {
                    companyIds.Add(company.CompanyId);
                }
                getContact = _mapper.Map<ContactGetDto>(contact);
                getContact.companies = companyIds;
            }

            return Ok(getContact);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> CreateContact([FromBody] ContactGetDto postContact)
        {
            var companies = postContact.companies.ToList();
            var contact = _mapper.Map<Contact>(postContact);
            contact = await _contactRepository.CreateContactAsync(contact, companies);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.ContactId }, contact);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, [FromBody] ContactGetDto contactpostdto)
        {
            var companies = contactpostdto.companies.ToList();
            contactpostdto.id = id;
            var contact = _mapper.Map<Contact>(contactpostdto);
            await _contactRepository.UpdateContactAsync(id, contact,companies);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var contact = await _contactRepository.DeleteContactAsync(id);
            if (contact == null)
                return BadRequest();
            return Ok(contact);
        }
    }
}
