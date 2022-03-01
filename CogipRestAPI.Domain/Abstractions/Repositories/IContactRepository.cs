using CogipRestAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Domain.Abstractions.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> CreateContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(int id, Contact contact);
        Task<Contact> DeleteContactAsync(int id);

    }
}
