using CogipRestAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Domain.Abstractions
{
    public interface ICompanyRepository
    {
       Task<List<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(Company company, List<int> contacts);
        Task<Company> UpdateCompanyAsync(int id, Company company, List<int> contacts);
        Task<Company> DeleteCompanyAsync(int id);
    }
}
