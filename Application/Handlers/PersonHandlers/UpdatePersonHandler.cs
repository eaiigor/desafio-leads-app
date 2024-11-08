using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Application.Commands.PersonCommands;
using desafio_leads.Domain.Entities;
using desafio_leads.Infrastructure.Repositories;
using desafio_leads.Infrastructure.Repositories.PersonRepository;
using MediatR;

namespace desafio_leads.Application.Handlers.PersonHandlers;

public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonDTO>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public UpdatePersonHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<PersonDTO> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request);
        await _personRepository.UpdatePersonAsync(person);
        return _mapper.Map<PersonDTO>(person);
    }
}