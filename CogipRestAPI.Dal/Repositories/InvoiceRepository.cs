using CogipRestAPI.Domain.Abstractions.Repositories;
using CogipRestAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Dal.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _ctx;
        public InvoiceRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            _ctx.Invoices.Add(invoice);
            await _ctx.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> DeleteInvoiceAsync(int id)
        {
            var invoice = _ctx.Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice == null)
                return null;
            _ctx.Invoices.Remove(invoice);
            await _ctx.SaveChangesAsync();
            return invoice;
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _ctx.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _ctx.Invoices.FirstOrDefaultAsync(i => i.InvoiceId == id);
            if (invoice == null)
                return null;
            return invoice;
        }

        public async Task<Invoice> UpdateInvoiceAsync(int id, Invoice invoice)
        {
            _ctx.Invoices.Update(invoice);
            await _ctx.SaveChangesAsync();
            return invoice;
        }
    }
}
