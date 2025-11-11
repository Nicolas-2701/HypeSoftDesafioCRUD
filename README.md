# Sistema de Gestão de Produtos (API .NET 9)

Este repositório contém um projeto de API RESTful de alta performance para um Sistema de Gestão de Produtos (PMS).

O projeto foi desenvolvido como um *showcase* de arquitetura de software moderna, demonstrando a implementação rigorosa dos princípios da **Clean Architecture** e **Domain-Driven Design (DDD)**. Ele utiliza o padrão **CQRS** (Command Query Responsibility Segregation) com **MediatR** para garantir uma separação clara de responsabilidades, alta manutenibilidade e escalabilidade.

A API é construída com **.NET 9** e utiliza **MongoDB** como banco de dados NoSQL, com toda a infraestrutura gerenciada por **Docker**.

## Principais Conceitos Implementados

* **Clean Architecture:** Separação estrita de camadas (Domain, Application, Infrastructure, API).
* **CQRS & MediatR:** Separação total das lógicas de escrita (Commands) e leitura (Queries).
* **Domain-Driven Design (DDD):** Foco nas entidades de negócio (`Product`, `Category`).
* **Padrão de Repositório:** Abstração da lógica de acesso a dados.
* **Testabilidade:** A arquitetura é desenhada para ser 100% testável.
---

## Agradecimentos (Acknowledgements)

A fundação deste projeto (a estrutura inicial .NET 9 + MongoDB com Clean Architecture) foi baseada no excelente boilerplate `DotNetMongoDbAPI` criado por [Mohaned Zekry](https://github.com/MohanedZekry). Todo o desenvolvimento da lógica de negócio, implementação de CQRS, endpoints de CRUD e funcionalidades de domínio (como `Product` e `Category`) foram construídos sobre essa base.