using ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Infrastructure.EntityConfig
{
    public class PerfilConfiguration : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfiguration()
        {
            ToTable("PERFIL");
            Property(e => e.Id).HasColumnName("ID_PERFIL");
            Property(e => e.Nome).HasColumnName("NOME");
            Property(e => e.Ativo).HasColumnName("ATIVO");

            
            
        }

    }
}
