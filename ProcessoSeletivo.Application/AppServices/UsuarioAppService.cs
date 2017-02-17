﻿using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessoSeletivo.Domain.Interfaces.Services;
using ProcessoSeletivo.Application.ViewModel;

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

            service.Update(obj);
        }
    }
}
