using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Application.Commands;
using desafio_leads.Application.Commands.PersonCommands;
using desafio_leads.Application.Queries;
using desafio_leads.Application.Queries.PersonQueries;
using desafio_leads.Domain.Entities;
using desafio_leads.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace desafio_leads.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController
{
    [HttpGet]
    public Task<List<PersonDTO>> GetAllPeopleAsync([FromServices] IPersonQueries personQueries)
        => personQueries.GetPeopleAsync();

    [HttpGet("{id}")]
    public Task<PersonDTO> GetPersonByIdAsync(
        [FromServices] IPersonQueries personQueries,
        int id)
        => personQueries.GetPersonByIdAsync(id);

    [HttpPost]
    public async Task<PersonDTO> CreatePersonAsync(
        [FromServices] IMediator mediator, [FromBody] CreatePersonCommand command)
        => await mediator.Send(command);

    [HttpPut("{id}")]
    public async Task<PersonDTO> UpdatePersonAsync(
        [FromServices] IMediator mediator, [FromBody] UpdatePersonCommand command, int id)
    {
        command.Id = id;
        return await mediator.Send(command);
    }
}