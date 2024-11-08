using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Application.Commands.JobCommands;
using desafio_leads.Domain.Entities;
using desafio_leads.Infrastructure.Repositories;
using desafio_leads.Infrastructure.Repositories.JobRepository;
using MediatR;

namespace desafio_leads.Application.Handlers.JobHandlers;

public class UpdateJobHandler : IRequestHandler<UpdateJobCommand, JobDTO>
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;

    public UpdateJobHandler(IJobRepository jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task<JobDTO> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var job = _mapper.Map<Job>(request);
        await _jobRepository.UpdateJobAsync(job);
        return _mapper.Map<JobDTO>(job);
    }
}