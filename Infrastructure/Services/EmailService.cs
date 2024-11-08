namespace desafio_leads.Infrastructure.Services;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(string to, string subject, string body)
    {
        return Task.Run(() =>
        {
            // Send email
            return;
        });
    }
}