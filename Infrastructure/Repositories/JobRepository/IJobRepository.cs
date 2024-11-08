using desafio_leads.Domain.Entities;

namespace desafio_leads.Infrastructure.Repositories.JobRepository;

public interface IJobRepository
{
    Task<Job> GetJobByIdAsync(int id);
    Task<List<Job>> GetJobsAsync();
    Task<Job> CreateJobAsync(Job job);
    Task<Job> UpdateJobAsync(Job job);
    Task DeleteJobAsync(int id);
}