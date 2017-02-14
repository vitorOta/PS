namespace ProcessoSeletivo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProcessoSeletivo.Infrastructure.DbContext.ProcessoSeletivoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        

        protected override void Seed(ProcessoSeletivo.Infrastructure.DbContext.ProcessoSeletivoContext context)
        {
            //  This method will be called after migrating to the latest version.


            //Usuario
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX ix_usuario_login ON USUARIO(LOGIN)");
            context.Database.ExecuteSqlCommand("ALTER TABLE USUARIO ADD CONSTRAINT usuario_ativo DEFAULT 1 FOR ATIVO");
            context.Database.ExecuteSqlCommand("ALTER TABLE USUARIO ADD CONSTRAINT usuario_dtLog DEFAULT GETDATE() FOR DT_INCLUSAO");

            //Perfil
            context.Database.ExecuteSqlCommand("ALTER TABLE PERFIL ADD CONSTRAINT perfil_ativo DEFAULT 1 FOR ATIVO");

            //UsuarioPerfil
            context.Database.ExecuteSqlCommand("ALTER TABLE USUARIO_PERFIL ADD CONSTRAINT usuarioPerfil_ativo DEFAULT 1 FOR ATIVO ");


            //OperacaoUsuario
            context.Database.ExecuteSqlCommand("ALTER TABLE OPERACAO_USUARIO ADD CONSTRAINT operacaoUsuario_dtLog DEFAULT GETDATE() FOR DT_LOG");

        }
    }
}
