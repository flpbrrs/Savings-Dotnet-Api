# 💵 Savings API

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)

> **API RESTful para gestão financeira pessoal, desenvolvida com foco em Clean Architecture, DDD e boas práticas de engenharia de software.**

Esta aplicação foi construída para demonstrar a implementação de um sistema escalável utilizando o ecossistema moderno do **.NET 9**, containerização e testes automatizados.

---

## 🚀 Tecnologias e Práticas

O projeto utiliza uma stack moderna para performance e manutenibilidade:

- **.NET 9 SDK**: Umas das versões mais recentes do framework.
- **Entity Framework Core**: ORM para manipulação de dados.
- **PostgreSQL**: Banco de dados relacional robusto.
- **Docker & Docker Compose**: Para orquestração de containers e ambiente de desenvolvimento reprodutível.
- **FluentValidation**: Para validação de regras de negócio e inputs de forma fluida.
- **Mappers de entidade personalizados**: Para mapeamento eficiente entre Entidades e DTOs (Request/Response).
- **Scalar UI**: Interface moderna para documentação de API.
- **XUnit & Bogus**: Para testes de unidade e geração de dados falsos (fakes) para cenários de teste.

## 🏛️ Arquitetura

O projeto segue os princípios da **Clean Architecture** e **Domain-Driven Design (DDD)**, organizado nas seguintes camadas:

1.  **Domain**: Contém as Entidades, Value Objects, Interfaces de Repositórios e Exceções de Domínio.
2.  **Application**: Contém os Casos de Uso (Use Cases), validações e regras de orquestração.
3.  **Infrastructure**: Implementação de acesso a dados (EF Core), Repositórios, Unit of Work e configurações de banco.
4.  **API**: Camada de entrada (Controllers), Filtros de Exceção e Injeção de Dependência.
5.  **Communication**: Contratos de dados (DTOs/View Models) compartilhados.

---

## ✨ Funcionalidades

- **CRUD Completo de Despesas**: Registro, atualização, remoção e leitura detalhada.
- **Filtragem Avançada**: Listagem de despesas com paginação e filtros por período.
- **Tratamento Global de Exceções**: Middleware personalizado para padronizar respostas de erro (RFC 7807).
- **Validação de Domínio**: Regras de negócio encapsuladas e validadas antes da persistência.

---

## 🛠️ Como Executar

Você pode rodar a aplicação de duas formas: totalmente em containers ou em modo híbrido.

### Pré-requisitos
- Docker Desktop instalado.
- .NET 9 SDK (apenas para rodar localmente fora do Docker).

### Configuração Inicial (.env)
Duplique o arquivo `.env.example` e renomeie para `.env`.

```bash
cp .env.example .env
# Windows: copy .env.example .env
```

Opção 1: Via Docker Compose (Recomendado)
Sobe a API e o Banco de Dados PostgreSQL automaticamente.


```bash
docker-compose up -d
```

A API estará disponível em: http://localhost:8080/scalar/v1 (Documentação interativa).

Opção 2: Desenvolvimento Local (Debug)
Rode apenas o banco no Docker e a aplicação na sua máquina.

Suba o banco:

```Bash
docker-compose up -d db
```

Configure a Connection String (User Secrets):

```bash

dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=savings_db;Username=admin;Password=root"
```

Execute a API:

```bash
dotnet run --project src/Savings.Api
```

## 🧪 Testes
O projeto inclui testes de unidade para validar regras de negócio e validadores.

```bash
dotnet test
```

## 📄 Licença
Este projeto está sob a licença MIT.
