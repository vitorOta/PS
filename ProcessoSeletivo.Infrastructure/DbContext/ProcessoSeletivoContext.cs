using ProcessoSeletivo.Domain.Entities;
using ProcessoSeletivo.Infrastructure.EntityConfig;
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
        public ProcessoSeletivoContext() : base(@"WebApiDatabase")
        {

        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p=>p.Name=="Id")
                .Configure(p=>p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p =>
                {
                    p.HasColumnType("varchar");
                    p.HasMaxLength(100);
                });

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PerfilConfiguration());
            modelBuilder.Configurations.Add(new UsuarioPerfilConfiguration());
            modelBuilder.Configurations.Add(new OperacaoUsuarioConfiguration());
        }

    }
}
