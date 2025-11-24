# 💵 Savings API

API destinada para o controle de despesas.

Este projeto é uma API .NET 9 construída com Entity Framework Core e PostgreSQL, projetada para rodar em contêineres Docker.

## 🛠️ Pré-requisitos

Antes de começar, certifique-se de ter as seguintes ferramentas instaladas:

- .NET 9 SDK
- Docker Desktop
- Git

## ⚙️ Configuração do Ambiente

Você precisa configurar os segredos dependendo de como vai executar a aplicação.

### 1. Para rodar com Docker Compose (Recomendado)

Este método sobe a API e o Banco de Dados juntos, simulando o ambiente de produção.

1. Crie o arquivo de variáveis: Na raiz do projeto, duplique o arquivo .env.example e renomeie para .env.

```Bash
cp .env.example .env
# No Windows: copy .env.example .env
```
2. Defina seus segredos: Abra o arquivo .env recém-criado e preencha os valores. O Docker Compose lerá este arquivo automaticamente.

```Ini, TOML
POSTGRES_USER=admin
POSTGRES_PASSWORD=minhasenhasuperforte
POSTGRES_DB=minha_api_db
```

### 2. Para rodar Localmente (Debug / F5 no Visual Studio)

Este método é usado quando você quer rodar o código C# na sua máquina (para usar breakpoints, etc), mas conectando ao banco de dados.

Usamos o .NET User Secrets para isso.

1. Inicialize os segredos (caso ainda não tenha feito): No terminal, dentro da pasta do projeto (.csproj):
```Bash
dotnet user-secrets init
```
2. Configure a Connection String: Execute o comando abaixo. Note que aqui o Host é localhost (pois o banco está exposto na sua máquina), diferente do Docker onde o host é o nome do serviço.
```Bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=minha_api_db;Username=admin;Password=minhasenhasuperforte"
```

## 🏃 Como Executar o Projeto

**Opção A: Via Docker (Full Stack)**
Para subir a aplicação completa (API + Banco):

```Bash
# Sobe os containers em segundo plano
docker-compose up -d
```

A API estará disponível em: http://localhost:8080 (ou a porta definida no seu docker-compose).

**Opção B: Modo Híbrido (App Local + Banco Docker)**

Ideal para desenvolvimento diário e debug.

Suba apenas o banco de dados: Isso garante que o Postgres esteja rodando para sua API se conectar.

```Bash
docker-compose up -d db
```
Rode a aplicação .NET: Pelo Visual Studio (F5) ou terminal:

```Bash
dotnet run
```
