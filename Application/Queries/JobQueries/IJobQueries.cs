using desafio_leads.API.DTOs;

namespace desafio_leads.Application.Queries.JobQueries;

public interface IJobQueries
{
    Task<JobDTO> GetJobByIdAsync(int id);
    
    Task<List<JobDTO>> GetJobsAsync();
}