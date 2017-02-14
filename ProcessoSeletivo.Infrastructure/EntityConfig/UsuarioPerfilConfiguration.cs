using ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Infrastructure.EntityConfig
{
    public class UsuarioPerfilConfiguration :EntityTypeConfiguration<UsuarioPerfil>
    {
        public UsuarioPerfilConfiguration()
        {
            ToTable("USUARIO_PERFIL");

            Property(e => e.PerfilId).HasColumnName("ID_PERFIL");
            Property(e => e.UsuarioId).HasColumnName("ID_USUARIO");

            HasKey(e => new { e.PerfilId, e.UsuarioId });

            HasRequired(e => e.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(e => e.PerfilId);

            HasRequired(e => e.Usuario)
                .WithMany(u => u.Perfis)
                .HasForeignKey(e=>e.UsuarioId);
        }

    }
}
