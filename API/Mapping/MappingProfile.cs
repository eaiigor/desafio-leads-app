using desafio_leads.API.DTOs;
using desafio_leads.Domain.Entities;
using AutoMapper;
using desafio_leads.Application.Commands;
using desafio_leads.Application.Commands.JobCommands;
using desafio_leads.Application.Commands.LeadCommands;
using desafio_leads.Application.Commands.PersonCommands;

namespace desafio_leads.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Person, PersonDTO>();
        CreateMap<Job, JobDTO>();
        CreateMap<Lead, LeadDTO>()
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
            .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job));

        CreateMap<PersonDTO, Person>();
        CreateMap<JobDTO, Job>();
        CreateMap<LeadDTO, Lead>()
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
            .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job));

        CreateMap<CreatePersonCommand, Person>();
        CreateMap<UpdatePersonCommand, Person>();
        CreateMap<CreateJobCommand, Job>();
        CreateMap<UpdateJobCommand, Job>();
        CreateMap<CreateLeadCommand, Lead>();
        CreateMap<UpdateLeadCommand, Lead>();
    }
}