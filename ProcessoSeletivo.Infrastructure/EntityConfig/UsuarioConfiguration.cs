﻿using ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Infrastructure.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuario");

            Property(e => e.Id).HasColumnName("ID_USUARIO");

            Property(e => e.Login).IsRequired();
            Property(e => e.Nome).IsRequired();



        }
    }
}