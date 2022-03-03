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

        public async Task<Company> CreateCompanyAsync(Company company, List<int> contacts)
        {
            var companyContacts = new List<Contact>();
            foreach (var contact in contacts)
            {
                var contactForId = await _ctx.Contacts
                    .Where(x => x.ContactId == contact)
                    .ToListAsync();
                companyContacts.Add(contactForId.FirstOrDefault());
            }
            company.Contacts = companyContacts;
            _ctx.Companies.Add(company);
            //_ctx.Entry(company).State = EntityState.Modified;
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
            return await _ctx.Companies
                .Include(c => c.Contacts)
                .ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            var company = await _ctx.Companies
                .Where(c => c.CompanyId == id)
                .Include(c => c.Contacts).ToListAsync();
            if (company == null)
                return null;
            var getcompany = company.FirstOrDefault();
            return getcompany;
        }

        public async Task<Company> UpdateCompanyAsync(int id, Company company, List<int> contacts)
        {
            var companyContacts = new List<Contact>();
            foreach (var contact in contacts)
            {
                var contactForId = await _ctx.Contacts
                    .Where(x => x.ContactId == contact)
                    .ToListAsync();
                companyContacts.Add(contactForId.FirstOrDefault());
            }
            //company.Contacts = null;
            //_ctx.Companies.Update(company);
            //await _ctx.SaveChangesAsync();
            company.Contacts = companyContacts;
            _ctx.Companies.Update(company);
            

            
            await _ctx.SaveChangesAsync();
            return company;
        }
    }
}
