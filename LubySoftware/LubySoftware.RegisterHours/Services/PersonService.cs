using LubySoftware.Domain.Models;
using LubySoftware.Domain.Repositories;
using System.Threading.Tasks;

namespace LubySoftware.RegisterHours.Services
{
    public class PersonService
    {
        readonly IPersonRepository PersonRepository;

        public PersonService(IPersonRepository person)
        {
            PersonRepository = person;
        }

        public async Task Save(PersonModel person)
        {
            await PersonRepository.Save(person);
        }

        public async Task<PersonModel> Find(long id)
        {
            return await PersonRepository.Find(id);
        }

        public async Task Delete(long id)
        {
            await PersonRepository.Delete(id);
        }

        public async Task Update(PersonModel person)
        {
            await PersonRepository.Update(person);
        }
    }
}
