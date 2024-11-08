using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Infrastructure.Repositories;
using desafio_leads.Infrastructure.Repositories.PersonRepository;

namespace desafio_leads.Application.Queries.PersonQueries;

public class PersonQueries : IPersonQueries
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonQueries(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<PersonDTO> GetPersonByIdAsync(int id)
    {
        var person = await _personRepository.GetPersonByIdAsync(id);
        return _mapper.Map<PersonDTO>(person);
    }

    public async Task<List<PersonDTO>> GetPeopleAsync()
    {
        var people = await _personRepository.GetPeopleAsync();
        return _mapper.Map<List<PersonDTO>>(people);
    }
}