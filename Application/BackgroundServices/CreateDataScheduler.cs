using desafio_leads.Application.Commands.JobCommands;
using desafio_leads.Application.Commands.LeadCommands;
using desafio_leads.Application.Commands.PersonCommands;
using desafio_leads.Application.Queries.JobQueries;
using desafio_leads.Application.Queries.PersonQueries;
using MediatR;

namespace desafio_leads.Application.BackgroundServices;

public class CreateDataScheduler : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public CreateDataScheduler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(5));
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var name = new Bogus.DataSets.Name(locale: "pt_BR").FirstName();
            var lastName = new Bogus.DataSets.Name(locale: "pt_BR").LastName();

            var email = $"{name.ToLower()}.{lastName.ToLower()}@gmail.com";
            
            var street = new Bogus.DataSets.Address(locale: "pt_BR").StreetName();
            var neighborhood = new Bogus.DataSets.Address(locale: "pt_BR").SecondaryAddress();
            var city = new Bogus.DataSets.Address(locale: "pt_BR").City();
            var number = new Bogus.Randomizer().Number(1, 2500);
            var createPersonCommand = new CreatePersonCommand
            {
                Name = name,
                LastName = lastName,
                Email = email,
                Address = $"{street}, {neighborhood}, {city} - {number}",
                Phone = new Bogus.DataSets.PhoneNumbers(locale: "pt_BR").PhoneNumber(),
            };

            var person = await mediator.Send(createPersonCommand);

            var createJobCommand = new CreateJobCommand
            {
                Title = new Bogus.DataSets.Company(locale: "pt_BR").CompanyName(),
                Description = new Bogus.DataSets.Commerce(locale: "pt_BR").ProductDescription(),
                Salary = new Bogus.Randomizer().Number(0, 1500),
            };

            var job = await mediator.Send(createJobCommand);

            await Task.Delay(TimeSpan.FromMilliseconds(300));

            var createLeadCommand = new CreateLeadCommand()
            {
                PersonId = person.Id,
                JobId = job.Id
            };

            await mediator.Send(createLeadCommand);
        }
    }
}