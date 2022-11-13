using Labinot_Krasniqi_Portfolio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labinot_Krasniqi_Portfolio.Data.Services
{
    public interface IContactServices
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact contact);

        Task<Contact> UpdateAsync(int id, Contact newContact);

        Task DeleteAsync(int id);


    }
}
