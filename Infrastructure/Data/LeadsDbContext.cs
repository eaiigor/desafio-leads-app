using desafio_leads.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace desafio_leads.Infrastructure.Data
{
    public class LeadsDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Lead> Leads { get; set; }

        public LeadsDbContext(DbContextOptions<LeadsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Job>().HasKey(p => p.Id);
            modelBuilder.Entity<Lead>().HasKey(p => p.Id);
            modelBuilder.Entity<Lead>().HasOne(p => p.Person).WithMany(x => x.Leads).HasForeignKey(x => x.PersonId);
            modelBuilder.Entity<Lead>().HasOne(p => p.Job).WithMany(x => x.Leads).HasForeignKey(x => x.JobId);
        }
    }
}