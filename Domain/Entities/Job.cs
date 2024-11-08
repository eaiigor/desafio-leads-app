namespace desafio_leads.Domain.Entities;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Salary { get; set; }

    public HashSet<Lead> Leads { get; set; }
}