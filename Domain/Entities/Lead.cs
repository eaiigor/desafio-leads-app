using desafio_leads.Domain.Enums;

namespace desafio_leads.Domain.Entities;

public class Lead
{
    public Lead()
    {
        CreatedAt = DateTime.Now;
    }

    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int JobId { get; set; }
    public Job Job { get; set; }
    public DateTime CreatedAt { get; set; }
    public ELeadStatus Status { get; set; }
    public decimal? SalaryProposed { get; set; }
}