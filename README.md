# API de Gestão de Produtos (.NET 9, Clean Architecture, CQRS)

Este repositório contém uma API RESTful de alta performance para um Sistema de Gestão de Produtos (PMS), desenvolvida em .NET 9.

O projeto foi desenvolvido como um *showcase* de arquitetura de software moderna, demonstrando a implementação rigorosa dos princípios da **Clean Architecture** e **Domain-Driven Design (DDD)**. Ele utiliza o padrão **CQRS** (Command Query Responsibility Segregation) com **MediatR** para garantir uma separação clara de responsabilidades, alta manutenibilidade e escalabilidade.

A API é construída com **.NET 9** e utiliza **MongoDB** como banco de dados NoSQL, com a infraestrutura do banco gerenciada por **Docker**.

## Principais Conceitos Implementados

* **Clean Architecture:** Separação estrita de camadas (Domain, Application, Persistence, API).
* **CQRS & MediatR:** Separação total das lógicas de escrita (Commands) e leitura (Queries) para máxima performance e escalabilidade.
* **Padrão de Repositório:** Abstração completa da lógica de acesso a dados.
* **Soft Delete:** Produtos não são deletados fisicamente do banco; eles são marcados com `IsDeleted = true`, preservando a integridade dos dados.
* **Design de API Profissional:** Implementação de DTOs (Data Transfer Objects) como `UpdateProductRequest` para proteger a integridade da entidade e prevenir a edição de chaves primárias (`Id`).

## Funcionalidades da API (Produto)

* `POST /product`: Cria um novo produto.
* `GET /product`: Lista todos os produtos ativos (não deletados).
* `GET /product/{id}`: Busca um produto específico pelo ID.
* `PUT /product/{id}`: Atualiza um produto.
* `DELETE /product/{id}`: Executa um "soft delete" no produto.
* `GET /product/search`: Busca produtos por nome e/Vou categoria (case-insensitive).
* `GET /product/lowstock`: Retorna produtos com estoque baixo (quantidade < 10).

## Stack Tecnológica

* **.NET 9** (SDK 9.0.306)
* **ASP.NET Core** (para a API)
* **MediatR** (para implementação do CQRS)
* **MongoDB** (Driver Nativo `MongoDB.Driver`)
* **Docker & Docker Compose** (para gerenciamento do container do banco)
* **Swagger/OpenAPI** (para documentação da API)

## Como Executar

Este guia assume que você tem os pré-requisitos instalados e rodando na sua máquina.

### Pré-requisitos

* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) (É essencial que ele esteja em execução)
* [Git](https://git-scm.com/downloads)

### 1. Clonar o Repositório

```bash
git clone https://github.com/Nicolas-2701/HypeSoftDesafioCRUD.git
cd HypeSoftDesafioCRUD
```
---

## Agradecimentos (Acknowledgements)

A fundação deste projeto (a estrutura inicial .NET 9 + MongoDB com Clean Architecture) foi baseada no excelente boilerplate `DotNetMongoDbAPI` criado por [Mohaned Zekry](https://github.com/MohanedZekry). Todo o desenvolvimento da lógica de negócio, implementação de CQRS, endpoints de CRUD e funcionalidades de domínio (como `Product` e `Category`) foram construídos sobre essa base.