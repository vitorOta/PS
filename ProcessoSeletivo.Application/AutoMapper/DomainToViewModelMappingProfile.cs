using AutoMapper;
using ProcessoSeletivo.Application.ViewModel;
using ProcessoSeletivo.Domain.Entities;

namespace ProcessoSeletivo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base("DomainToViewModelMappingProfile")
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Perfil, PerfilViewModel>();
        }
    }
}