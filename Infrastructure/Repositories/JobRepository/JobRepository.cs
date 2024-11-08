using desafio_leads.Domain.Entities;
using desafio_leads.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace desafio_leads.Infrastructure.Repositories.JobRepository;

public class JobRepository : IJobRepository
{
    private readonly LeadsDbContext _context;

    public JobRepository(LeadsDbContext context)
    {
        _context = context;
    }

    public async Task<Job> GetJobByIdAsync(int id)
    {
        return await _context.Jobs
            .FirstAsync(j => j.Id == id);
    }

    public async Task<List<Job>> GetJobsAsync()
    {
        return await _context.Jobs
            .ToListAsync();
    }

    public async Task<Job> CreateJobAsync(Job job)
    {
        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();
        return job;
    }

    public async Task<Job> UpdateJobAsync(Job job)
    {
        _context.Entry(job).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return job;
    }

    public async Task DeleteJobAsync(int id)
    {
        var job = await _context.Jobs.FirstAsync(x => x.Id == id);
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
    }
}