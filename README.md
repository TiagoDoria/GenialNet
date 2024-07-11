## Adicionar migrations
Add-Migration InitialCreate -StartupProject DesafioGenialNet -Project Infrastructure

## Executar migrations
update-database

## Nome do Banco de Dados
genialnet

## Estrutura e tecnologias
O projeto foi desenvolvido utilizando .NET Core 8, SQL Server, CQRS - Mediatr, Entity Framework. Utilizando o padrão DDD, sendo dividido em: Domain, Application, Infrastructure e a API.

## Unidades de Medida

  Unidade = 0
  Quilograma = 1
  Metro = 2

## Modelo de entrada

{
  "Fornecedor": {
    "Id": "uuid-fornecedor",
    "Nome": "Fornecedor Exemplo",
    "Cnpj": "12345678000123",
    "Telefone": "1234567890",
    "Endereco": {
      "Id": "uuid-endereco",
      "Cep": "12345-678",
      "Logradouro": "Rua Exemplo",
      "Complemento": "Apto 101",
      "Bairro": "Bairro Exemplo",
      "Localidade": "Cidade Exemplo",
      "Uf": "SP",
      "FornecedorId": "uuid-fornecedor"
    },
    "Produtos": [
      {
        "Id": "uuid-produto1",
        "Descricao": "Produto Exemplo 1",
        "Marca": "Marca Exemplo",
        "UnidadeDeMedida": "Unidade",
        "Preco": 10.50,
        "FornecedorId": "uuid-fornecedor"
      },
      {
        "Id": "uuid-produto2",
        "Descricao": "Produto Exemplo 2",
        "Marca": "Marca Exemplo",
        "UnidadeDeMedida": "Quilograma",
        "Preco": 25.00,
        "FornecedorId": "uuid-fornecedor"
      }
    ]
  }
}
