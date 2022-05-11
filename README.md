# API Rest construida com ASP.NET, EntityFramework e SQLite.

// Dependências da aplicação: .NET Core SDK 5.0, Entity Framework 5.0.3, SQLite e Postman.
// IDE utilizado: Rider.

// Pacotes necessários para a utilização da aplicação:

- dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 5.0.3
- dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.3

// Agora podemos levantar nossa API:

- dotnet watch run

// Dentro do Postman podemos criar e testar os nossos endpoints:

- Método GET : https://localhost:5001/v1/apis : Get de todos os objetos cadastrados;
-----------------------------------------------------------------------------------------

- Método GET : https://localhost:5001/v1/apis/1 : Get dos objetos por Id;
-----------------------------------------------------------------------------------------

- Método POST : https://localhost:5001/v1/apis > Body > raw > JSON : Cadastro de um objeto dentro do Banco de Dados; 
- {
    "title": ""
  }
-- Irá retornar um erro de campo de título requerido.

- {
    "title": "Cadastrando um objeto com ASP.NET e EntityFramework!!"
  }
-- Irá retornar 201 created com Id, Título, Done e Data de criação.
-----------------------------------------------------------------------------------------

- Método PUT : https://localhost:5001/v1/apis/1 > Body > raw > JSON : Atualização de um objeto por Id;
- {
    "title": "Atualizando um objeto dentro do SQLite!!"
  }
-- Irá retornar 200 OK com Id, Título, Done e Data atualizados.
-----------------------------------------------------------------------------------------

- Método DELETE : https://localhost:5001/v1/apis/1 : Deleta um objeto por Id.


