using CogipRestAPI.Domain.Abstractions;
using CogipRestAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Dal.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _ctx;
        public CompanyRepository(DataContext ctx)
        {
                _ctx = ctx;
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            _ctx.Companies.Add(company);
            await _ctx.SaveChangesAsync();
            return company;
        }

        public async Task<Company> DeleteCompanyAsync(int id)
        {
            var company = await _ctx.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
            if (company == null)
                return null;
            _ctx.Companies.Remove(company);
            return company;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _ctx.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            var company = await _ctx.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
            if (company == null)
                return null;
            return company;
        }

        public async Task<Company> UpdateCompanyAsync(int id, Company company)
        {
            _ctx.Companies.Update(company);
            await _ctx.SaveChangesAsync();
            return company;
        }
    }
}
