﻿using ProcessoSeletivo.Infrastructure.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Infrastructure.DbContext
{
    public class ProcessoSeletivoContext : System.Data.Entity.DbContext
    {
        public ProcessoSeletivoContext() : base("ProcessoSeletivoContext")/*mudar e jogar no webconfig do appCliente*/
        {

        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            modelBuilder.Properties()
                .Where(p=>p.Name=="Id")
                .Configure(c=>c.IsKey());

            modelBuilder.Properties<string>()
                .Configure(c =>
                {
                    c.HasColumnType("varchar");
                    c.HasMaxLength(100);
                });

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PerfilConfiguration());
        }

    }
}