using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Infrastructure.Repositories;
using desafio_leads.Infrastructure.Repositories.JobRepository;

namespace desafio_leads.Application.Queries.JobQueries;

public class JobQueries : IJobQueries
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;

    public JobQueries(IJobRepository jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task<JobDTO> GetJobByIdAsync(int id)
    {
        var job = await _jobRepository.GetJobByIdAsync(id);
        return _mapper.Map<JobDTO>(job);
    }

    public async Task<List<JobDTO>> GetJobsAsync()
    {
        var people = await _jobRepository.GetJobsAsync();
        return _mapper.Map<List<JobDTO>>(people);
    }
}