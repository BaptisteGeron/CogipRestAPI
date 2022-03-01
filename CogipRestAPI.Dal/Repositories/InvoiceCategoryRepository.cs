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
    public class InvoiceCategoryRepository : IInvoiceCategoryRepository
    {
        private readonly DataContext _ctx;
        public InvoiceCategoryRepository(DataContext ctx)
        {
             _ctx = ctx;
        }

        public async Task<InvoiceCategory> CreateInvoiceCategoryAsync(InvoiceCategory invoiceCategory)
        {
            _ctx.InvoicesCategory.Add(invoiceCategory);
            await _ctx.SaveChangesAsync();
            return invoiceCategory;
        }

        public async Task<InvoiceCategory> DeleteInvoiceCategoryAsync(int id)
        {
            var invoiceCategory = await _ctx.InvoicesCategory.FirstOrDefaultAsync(i => i.InvoiceCategoryId == id);
            if (invoiceCategory != null)
                return null;
            _ctx.InvoicesCategory.Remove(invoiceCategory);
            await _ctx.SaveChangesAsync();
            return invoiceCategory;
        }

        public async Task<List<InvoiceCategory>> GetAllCategoriesAsync()
        {
            return await _ctx.InvoicesCategory.ToListAsync();
        }

        public async Task<InvoiceCategory> GetCategoryByIdAsync(int id)
        {
            var category = await _ctx.InvoicesCategory.FirstOrDefaultAsync(c => c.InvoiceCategoryId == id);
            if (category != null)
                return null;
            return category;
        }

        public async Task<InvoiceCategory> UpdateInvoiceCategoryAsync(int id, InvoiceCategory invoiceCategory)
        {
            _ctx.InvoicesCategory.Update(invoiceCategory);
            await _ctx.SaveChangesAsync();
            return invoiceCategory;
        }
    }
}
