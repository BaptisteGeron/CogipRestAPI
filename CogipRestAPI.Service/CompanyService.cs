using CogipRestAPI.Domain.Abstractions;
using CogipRestAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;
        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        public List<Company> ProcessContacts()
        {
            var companies = _repo.GetCompanies();
            var processed = new List<Company>();
            foreach (var company in companies)
            {
                processed.Add(company);
            }
            return processed;
        }
    }

}
