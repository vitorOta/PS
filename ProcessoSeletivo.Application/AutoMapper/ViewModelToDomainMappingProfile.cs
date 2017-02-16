using AutoMapper;
using ProcessoSeletivo.Application.ViewModel;
using ProcessoSeletivo.Domain.Entities;

namespace ProcessoSeletivo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile :Profile
    {
        public ViewModelToDomainMappingProfile() : base("ViewModelToDomainMappingProfile")
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<PerfilViewModel, Perfil>();
        }
    }
}