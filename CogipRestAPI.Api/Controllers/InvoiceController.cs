using AutoMapper;
using CogipRestAPI.Domain.Abstractions.Repositories;
using CogipRestAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CogipRestAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IMapper mapper, IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public async Task<ActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceRepository.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoiceById(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return BadRequest("Invoice not found...");
            return Ok(invoice);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public async Task<ActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            invoice = await _invoiceRepository.CreateInvoiceAsync(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.InvoiceId }, invoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInvoice(int id, [FromBody] Invoice invoice)
        {
            invoice.InvoiceId = id;
            await _invoiceRepository.UpdateInvoiceAsync(id,invoice);
            return NoContent();
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoice(int id)
        {
            var invoice = await _invoiceRepository.DeleteInvoiceAsync(id);
            if (invoice == null)
                return NotFound("No Invoice with this id found...");
            return Ok(invoice);
        }
    }
}
