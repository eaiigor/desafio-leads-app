using desafio_leads.API.DTOs;
using desafio_leads.Application.Commands.JobCommands;
using desafio_leads.Application.Queries.JobQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace desafio_leads.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController
{
    [HttpGet]
    public Task<List<JobDTO>> GetAllPeopleAsync([FromServices] IJobQueries jobQueries)
        => jobQueries.GetJobsAsync();

    [HttpGet("{id}")]
    public Task<JobDTO> GetJobByIdAsync(
        [FromServices] IJobQueries jobQueries,
        int id)
        => jobQueries.GetJobByIdAsync(id);

    [HttpPost]
    public async Task<JobDTO> CreateJobAsync(
        [FromServices] IMediator mediator, [FromBody] CreateJobCommand command)
        => await mediator.Send(command);

    [HttpPut("{id}")]
    public async Task<JobDTO> UpdateJobAsync(
        [FromServices] IMediator mediator, [FromBody] UpdateJobCommand command, int id)
    {
        command.Id = id;
        return await mediator.Send(command);
    }
}