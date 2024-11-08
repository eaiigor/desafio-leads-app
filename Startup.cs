using System.Reflection;
using System.Text.Json;
using desafio_leads.Application.BackgroundServices;
using desafio_leads.Application.Behaviors;
using desafio_leads.Application.Queries.JobQueries;
using desafio_leads.Application.Queries.LeadQueries;
using desafio_leads.Application.Queries.PersonQueries;
using desafio_leads.Infrastructure.Data;
using desafio_leads.Infrastructure.Repositories.JobRepository;
using desafio_leads.Infrastructure.Repositories.LeadRepository;
using desafio_leads.Infrastructure.Repositories.PersonRepository;
using desafio_leads.Infrastructure.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace desafio_leads
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Controllers and Swagger
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LeadsApi", Version = "v1" });
            });

            //Database
            services.AddDbContext<LeadsDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("Sqlite"));
            });

            //MediatR and AutoMapper
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //Repositories
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<ILeadRepository, LeadRepository>();

            //Queries
            services.AddTransient<IPersonQueries, PersonQueries>();
            services.AddTransient<IJobQueries, JobQueries>();
            services.AddTransient<ILeadQueries, LeadQueries>();
            
            //Services
            services.AddTransient<IEmailService, EmailService>();
            
            //Background Services
            services.AddHostedService<CreateDataScheduler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LeadsApi v1"));
            }

            app.UseExceptionHandler(options => options.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var ex = context.Features.Get<IExceptionHandlerFeature>();

                if (ex == null) return;

                if (ex.Error is ValidationException validationException)
                {
                    var errors = validationException.Errors.Select(error =>
                        new { PropertyName = error.PropertyName, ErrorMessage = error.ErrorMessage });
                    var json = JsonSerializer.Serialize(new { Message = ex.Error.Message, errors = errors });
                    await context.Response.WriteAsync(json);
                }
                else
                {
                    var errorMessage = new { Message = ex.Error.Message };
                    var json = JsonSerializer.Serialize(errorMessage);
                    await context.Response.WriteAsync(json);
                }
            }));

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}