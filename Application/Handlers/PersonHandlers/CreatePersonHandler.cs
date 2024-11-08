using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Application.Commands.PersonCommands;
using desafio_leads.Domain.Entities;
using desafio_leads.Infrastructure.Repositories;
using desafio_leads.Infrastructure.Repositories.PersonRepository;
using MediatR;

namespace desafio_leads.Application.Handlers.PersonHandlers;

public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonDTO>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public CreatePersonHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<PersonDTO> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request);
        var created = await _personRepository.CreatePersonAsync(person);
        return _mapper.Map<Person, PersonDTO>(created);
    }
}