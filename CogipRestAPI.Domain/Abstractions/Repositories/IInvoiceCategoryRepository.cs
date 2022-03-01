using CogipRestAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Domain.Abstractions.Repositories
{
    public interface IInvoiceCategoryRepository
    {
        Task<List<InvoiceCategory>> GetAllCategoriesAsync();
        Task<InvoiceCategory> GetCategoryByIdAsync(int id);
        Task<InvoiceCategory> CreateInvoiceCategoryAsync(InvoiceCategory invoiceCategory);
        Task<InvoiceCategory> UpdateInvoiceCategoryAsync(int id, InvoiceCategory invoiceCategory);
        Task<InvoiceCategory> DeleteInvoiceCategoryAsync(int id);
    }
}
