## Aplicação Leads

Aplicação SPA para cadastro de leads.
Construída com Angular 15 e .NET 6.0.135

## Instalação

Certifique-se de estar utilizando o .NET 6.0.135
https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.135-windows-x64-installer

Lembre-se de entrar na pasta ClientApp e rode o comando

```bash
npm install
```


## Migrations

Para executar as migrations do banco de dados, execute os seguintes comandos:

```bash
dotnet tool install --global dotnet-ef --version 6.0.35
dotnet ef migrations add NomeDaMigration --project desafio-leads
dotnet ef database update --project desafio-le
```

---

## Arquitetura

- Domain Driven Design (DDD)

A aplicação segue os conceitos de DDD

**Domain**  
Na camada de domínio temos as entidades da aplicação. foi aplicado o conceito de domínio rico na criação dos Leads, onde no construtor da entidade é feito o preenchimento automático da propriedade **CreatedAt**

Como a aplicação é simples, não foi encontrado outras alternativas de encapsular a regra de negócio no domínio.

**Infrastructure**  
Na camada de infraestrutura temos a definição dos repositórios, o contexto do banco de dados e o serviço de Email.

**API**  
Já na camada de apresentação temos todos os controllers e DTOs, assim como as configurações de mapping para o automapper.

**Application**  
Nesta camada estão os itens que não estão diretamente relacionados às principais camadas do DDD. Aqui está localizado os Comandos, Handlers e Queries da aplicação, seguindo os conceitos de CQRS

## Banco de Dados

Foi utilizado de ORM o Entity Framework Core junto do SQLite.
Há um arquivo de banco de dados já populado com alguns leads para facilitar o teste da aplicação.

## Background Service

Como no front não havia nenhum lugar para criar items e popular o banco de dados, foi criado um serviço de background que cria um novo lead a cada 5 minutos.


