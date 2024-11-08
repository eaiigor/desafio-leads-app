using desafio_leads.Domain.Entities;

namespace desafio_leads.Infrastructure.Repositories.PersonRepository;

public interface IPersonRepository
{
    Task<Person> GetPersonByIdAsync(int id);
    Task<List<Person>> GetPeopleAsync();
    Task<Person> CreatePersonAsync(Person person);
    Task<Person> UpdatePersonAsync(Person person);
    Task DeletePersonAsync(int id);
}