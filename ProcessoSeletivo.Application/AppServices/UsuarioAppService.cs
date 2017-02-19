using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessoSeletivo.Domain.Interfaces.Services;
using ProcessoSeletivo.Application.ViewModel;
using AutoMapper;

namespace ProcessoSeletivo.Application.AppServices
{
    public class UsuarioAppService : AppServiceBase<UsuarioViewModel,Usuario>, IUsuarioAppService
    {
        public UsuarioAppService(IUsuarioService service) : base(service)
        {
        }

        public override void Update(UsuarioViewModel model)
        {
            var obj = service.GetById(model.Id);

            obj.Email = model.Email;
            obj.Ativo = model.Ativo;
            obj.Login = model.Login;
            obj.Nome = model.Nome;
            obj.Senha = model.Senha;

            obj.Perfis?.ToString(); //gg lazy load

            obj.Perfis = Mapper.Map<List<UsuarioPerfilViewModel>, List<UsuarioPerfil>>(model.Perfis ?? new List<UsuarioPerfilViewModel>());

            service.Update(obj);
        }
    }
}
