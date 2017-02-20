# Processo Seletivo

2ª Etapa do Processo Seletivo da Todos Empreendimentos.
##

#### Estrutura do Sistema

* Domain
	* ProcessoSeletivo.Domain
* Infrastructure
	* Data
		* ProcessoSeletivo.Infrastructure.Data
	* IoC
		* ProcessoSeletivo.Infrastructure.IoC
* Application
	* ProcessoSeletivo.Application
	* ProcessoSeletivo.Application.WebApi
* Presentation
	* ProcessoSeletivo.Presentation.MVC
	* ProcessoSeletivo.Presentation.WebForms

##
#### Configurações
Para executar o projeto é necessário alterar algumas configurações nos arquivos de configuração (Web.config)
* Url do Banco de Dados (ProcessoSeletivo.Application.WebApi)
```
 <add name ="WebApiDatabase" providerName="System.Data.SqlClient" connectionString="Data Source=[Seu Servidor];Initial Catalog=ProcessoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" ></add>
```
* Url da WebApi (MVC e WebForms)
```
<add key="WebServiceUrl" value="http://[Seu Servidor]:[Porta]/api/" />
```

##
#### Scripts do Banco
Os scripts do banco estão na pasta [scripts db](https://github.com/vitorOta/PS/tree/master/scripts%20db).
* Db, Tables and Index.sql (não é necessário a sua  execução, visto que o sistema utiliza o CodeFirst)
* Triggers and Procedures.sql
* Importação do txt.sql
* Query.sql
