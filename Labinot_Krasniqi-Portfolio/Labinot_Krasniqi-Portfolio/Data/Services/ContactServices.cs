using Labinot_Krasniqi_Portfolio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labinot_Krasniqi_Portfolio.Data.Services
{
    public class ContactServices : IContactServices
    {

        private readonly AppDbContext _context;

        public ContactServices(AppDbContext context)
        {
            _context = context; 
        }


        public async Task AddAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);

            await _context.SaveChangesAsync();

        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var result = await _context.Contacts.ToListAsync();
            return result;
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            var result = await _context.Contacts.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public Task<Contact> UpdateAsync(int id, Contact newContact)
        {
            throw new System.NotImplementedException();
        }
    }
}
