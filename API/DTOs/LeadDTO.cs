using desafio_leads.Domain.Enums;

namespace desafio_leads.API.DTOs;

public class LeadDTO
{
    public int Id { get; set; }
    public PersonDTO Person { get; set; }
    public JobDTO Job { get; set; }
    public DateTime CreatedAt { get; set; }
    public ELeadStatus Status { get; set; }
    public decimal SalaryProposed { get; set; }
}