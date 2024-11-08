using desafio_leads.Domain.Entities;
using desafio_leads.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace desafio_leads.Infrastructure.Repositories.PersonRepository;

public class PersonRepository : IPersonRepository
{
    private readonly LeadsDbContext _ctx;

    public PersonRepository(LeadsDbContext ctx)
    {
        _ctx = ctx;
    }

    public Task<Person> GetPersonByIdAsync(int id) => _ctx.Persons.FirstAsync(x => x.Id == id);

    public Task<List<Person>> GetPeopleAsync() => _ctx.Persons.ToListAsync();

    public async Task<Person> CreatePersonAsync(Person person)
    {
        await _ctx.Persons.AddAsync(person);
        await _ctx.SaveChangesAsync();
        return person;
    }

    public Task<Person> UpdatePersonAsync(Person person)
    {
        _ctx.Entry(person).State = EntityState.Modified;
        return _ctx.SaveChangesAsync().ContinueWith(_ => person);
    }

    public async Task DeletePersonAsync(int id)
    {
        var person = await _ctx.Persons.FirstAsync(x => x.Id == id);
        _ctx.Persons.Remove(person);
        await _ctx.SaveChangesAsync();
    }
}