using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Application.Commands;
using desafio_leads.Application.Commands.LeadCommands;
using desafio_leads.Application.Queries;
using desafio_leads.Application.Queries.LeadQueries;
using desafio_leads.Domain.Entities;
using desafio_leads.Domain.Enums;
using desafio_leads.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace desafio_leads.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAllPeopleAsync([FromServices] ILeadQueries leadQueries, [FromQuery] ELeadStatus status)
        => Ok(await leadQueries.GetLeadsAsync(status));

    [HttpGet("{id}")]
    public async Task<ActionResult> GetLeadByIdAsync(
        [FromServices] ILeadQueries leadQueries,
        int id)
        => Ok(await leadQueries.GetLeadByIdAsync(id));

    [HttpPost]
    public async Task<ActionResult> CreateLeadAsync(
        [FromServices] IMediator mediator, [FromBody] CreateLeadCommand command)
        => Ok(await mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateLeadAsync(
        [FromServices] IMediator mediator, [FromBody] UpdateLeadCommand command, int id)
    {
        command.Id = id;
        return Ok(await mediator.Send(command));
    }
}