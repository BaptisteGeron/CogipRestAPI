using AutoMapper;
using CogipRestAPI.Domain.Abstractions.Repositories;
using CogipRestAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CogipRestAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceCategoryRepository _invoiceCategoryRepository;
        public InvoiceCategoryController(IMapper mapper, IInvoiceCategoryRepository invoiceCategoryRepository)
        {
            _invoiceCategoryRepository = invoiceCategoryRepository;
            _mapper = mapper;
        }
        // GET: api/<InvoiceCategoryController>
        [HttpGet]
        public async Task<ActionResult> GetAllInvoiceCategories()
        {
            var invoiceCategories = await _invoiceCategoryRepository.GetAllCategoriesAsync();
            return Ok(invoiceCategories);
        }

        // GET api/<InvoiceCategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoiceCategoryById(int id)
        {
            var invoiceCategory = await _invoiceCategoryRepository.GetCategoryByIdAsync(id);
            if (invoiceCategory == null)
                return BadRequest("Category not found ...");
            return Ok(invoiceCategory);
        }

        // POST api/<InvoiceCategoryController>
        [HttpPost]
        public async Task<ActionResult> CreateInvoiceCategory([FromBody] InvoiceCategory invoiceCategory)
        {
            await _invoiceCategoryRepository.CreateInvoiceCategoryAsync(invoiceCategory);
            return CreatedAtAction(nameof(GetInvoiceCategoryById), new { id = invoiceCategory.InvoiceCategoryId }, invoiceCategory);

        }

        // PUT api/<InvoiceCategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInvoiceCategory(int id, [FromBody] InvoiceCategory invoiceCategory)
        {
            invoiceCategory.InvoiceCategoryId = id;
            await _invoiceCategoryRepository.UpdateInvoiceCategoryAsync(id, invoiceCategory);
            return NoContent();
        }

        // DELETE api/<InvoiceCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoiceCategory(int id)
        {
            var invoiceCategory = await _invoiceCategoryRepository.DeleteInvoiceCategoryAsync(id);
            if (invoiceCategory == null)
                return NotFound("No Category with this id found...");
            return Ok(invoiceCategory);
        }
    }
}
