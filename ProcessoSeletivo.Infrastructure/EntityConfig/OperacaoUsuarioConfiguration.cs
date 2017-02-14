using ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Infrastructure.EntityConfig
{
    public class OperacaoUsuarioConfiguration: EntityTypeConfiguration<OperacaoUsuario>
    {
        public OperacaoUsuarioConfiguration()
        {
            ToTable("OPERACAO_USUARIO ");

            Property(e => e.Id).HasColumnName("ID_OPERACAO");
            Property(e => e.UsuarioId).HasColumnName("ID_USUARIO") ;
            //fazer fk
            Property(e => e.DtLog).HasColumnName("DT_LOG");

            HasRequired(e => e.Usuario)
                .WithMany(u => u.Operacoes)
                .HasForeignKey(e=>e.UsuarioId);

        }
    }
}
