# 🏦 Bank Teller System

Sistema de contas bancárias desenvolvido com **.NET 9**, arquitetura em camadas, validação robusta com **FluentValidation**, e armazenamento de dados em memória com **Entity Framework Core**. Projetado para simular operações como abertura de conta, transferência de saldo e desativação de contas.

---

## 📁 Estrutura do Projeto

- **BankTellerSystem.API**  
  Camada de entrada (Controllers, Configurações, Middlewares, Swagger, etc.)

- **BankTellerSystem.Application**  
  Camada de aplicação, contendo comandos, handlers, validadores (usando MediatR + FluentValidation).

- **BankTellerSystem.Domain**  
  Núcleo da aplicação com entidades, regras de negócio, enums e exceções.

- **BankTellerSystem.InfraData**  
  Acesso a dados com EF Core, mapeamentos (`EntityTypeConfiguration`), e contexto `DbContext`.

---

## 🚀 Tecnologias Utilizadas

- [.NET 9 Preview](https://dotnet.microsoft.com)
- [Entity Framework Core InMemory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/)
- [FluentValidation](https://docs.fluentvalidation.net/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- AutoMapper

---

## 📦 Funcionalidades Principais

- ✅ Criar Conta Bancária
- 🔁 Transferência de Saldo entre Contas
- 🚫 Desativar Conta
- 🔍 Consultar Contas Cadastradas
- 🧾 Histórico de Operações por Conta
- 🔒 Validações com FluentValidation
- ⚠️ Lançamento de `BusinessException` com código HTTP 400 para regras de negócio violadas
- 📄 Validação automática de modelos com `ValidationProblemDetails` (HTTP 400)
- 📕 Swagger UI para explorar e testar as rotas disponíveis

---

## ⚙️ Como Executar Localmente

### 1. Clone o repositório
### 2. Execute o projeto 
dotnet run --project BankTellerSystem.API
### 3. Acesse o Swagger
https://localhost:7126/swagger/index.html

