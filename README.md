## Adicionar migrations
Add-Migration InitialCreate -StartupProject DesafioGenialNet -Project Infrastructure

## Executar migrations
update-database

## Nome do Banco de Dados
genialnet

## Estrutura e tecnologias
O projeto foi desenvolvido utilizando .NET Core 8, SQL Server, CQRS - Mediatr, Entity Framework. Utilizando o padrão DDD, sendo dividido em: Domain, Application, Infrastructure e a API.

