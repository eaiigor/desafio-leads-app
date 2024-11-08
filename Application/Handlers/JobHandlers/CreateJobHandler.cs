using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Application.Commands.JobCommands;
using desafio_leads.Domain.Entities;
using desafio_leads.Infrastructure.Repositories;
using desafio_leads.Infrastructure.Repositories.JobRepository;
using MediatR;

namespace desafio_leads.Application.Handlers.JobHandlers;

public class CreateJobHandler : IRequestHandler<CreateJobCommand, JobDTO>
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;

    public CreateJobHandler(IJobRepository jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task<JobDTO> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var job = _mapper.Map<Job>(request);
        var created = await _jobRepository.CreateJobAsync(job);
        return _mapper.Map<Job, JobDTO>(created);
    }
}