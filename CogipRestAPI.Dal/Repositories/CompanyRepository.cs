using CogipRestAPI.Domain.Abstractions;
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

        
    }
}
