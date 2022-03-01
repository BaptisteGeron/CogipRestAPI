using AutoMapper;
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
            return Ok(contacts);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null)
                return NotFound();
            return Ok(contact);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> CreateContact([FromBody] Contact contact)
        {
            contact = await _contactRepository.CreateContactAsync(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.ContactId }, contact);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, [FromBody] Contact contact)
        {
            contact.ContactId = id;
            await _contactRepository.UpdateContactAsync(id, contact);
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
