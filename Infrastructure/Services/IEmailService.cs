namespace desafio_leads.Infrastructure.Services;

public interface IEmailService
{
    public Task SendEmailAsync(string to, string subject, string body);
}