﻿using CogipRestAPI.Domain.Abstractions.Repositories;
using CogipRestAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Dal.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _ctx;
        public ContactRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Contact> CreateContactAsync(Contact contact, List<int> companies)
        {
            var contactCompanies = new List<Company>();
            foreach (var company in companies)
            {
                var companyForId = await _ctx.Companies
                    .Where(x => x.CompanyId == company)
                    .ToListAsync();
                contactCompanies.Add(companyForId.FirstOrDefault());
            }
            contact.Companies = contactCompanies;
            _ctx.Contacts.Add(contact);
            await _ctx.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> DeleteContactAsync(int id)
        {
            var contact = await _ctx.Contacts.FirstOrDefaultAsync(c => c.ContactId == id);
            if (contact == null)
                return null;
            _ctx.Contacts.Remove(contact);
            await _ctx.SaveChangesAsync();
            return contact;
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {

            return await _ctx.Contacts
                .Include(c => c.Companies)
                .ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var contact = await _ctx.Contacts
                .Where(c => c.ContactId == id)
                .Include(c => c.Companies).ToListAsync();
            if (contact == null)
                return null;
            var getContact = contact.FirstOrDefault();
            return getContact;
        }

        public async Task<Contact> UpdateContactAsync(int id, Contact contact, List<int> companies)
        {
            var contactCompanies = new List<Company>();
            foreach (var company in companies)
            {
                var companyForId = await _ctx.Companies
                    .Where(x => x.CompanyId == company)
                    .ToListAsync();
                contactCompanies.Add(companyForId.FirstOrDefault());
            }
            contact.Companies = contactCompanies;
            _ctx.Contacts.Update(contact);
            await _ctx.SaveChangesAsync();
            return contact;
        }
    }
}
