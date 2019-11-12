using AutoMapper;
using TesteClienteAgenda.Application.ViewModels;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Agenda, AgendaViewModel>().ReverseMap();
        }
    }
}