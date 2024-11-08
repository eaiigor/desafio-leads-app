using desafio_leads.API.DTOs;

namespace desafio_leads.Application.Queries.PersonQueries;

public interface IPersonQueries
{
    Task<PersonDTO> GetPersonByIdAsync(int id);
    
    Task<List<PersonDTO>> GetPeopleAsync();
}