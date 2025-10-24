# Suppliers System

Este projeto é um MVP que demonstra uma arquitetura de microsserviços moderna utilizando **.NET**, **Entity Framework Core**, **JWT** e **Blazor**. Ele foi projetado com base em princípios de **Clean Architecture**, **DDD** e **SOLID**, com foco em separação de responsabilidades, testabilidade e fácil manutenção.

---

## 📘 Visão Geral

O sistema é composto por três aplicações independentes que se comunicam via HTTP:

| Serviço              | Tipo       | Função                                                                                |
| -------------------- | ---------- | ------------------------------------------------------------------------------------- |
| **AuthService**      | Web API    | Gerencia autenticação e cadastro de usuários, emitindo tokens JWT.                    |
| **SuppliersService** | Web API    | Controla o cadastro de fornecedores, produtos e entregas, validando o acesso via JWT. |
| **SuppliersPortal**  | Blazor App | Interface web para interação com os dois serviços.                                    |

---

## 🧩 Arquitetura

```
SuppliersPortal (Blazor)
   │
   ├─ /login  → AuthService (/auth/login) → JWT
   └─ /suppliers, /products, /deliveries → SuppliersService (Bearer <token>)
```

Cada microsserviço segue o padrão de **Clean Architecture**, com as seguintes camadas:

* **Domain** → entidades e value objects;
* **Application** → casos de uso, validações e DTOs;
* **Infrastructure** → acesso a dados, segurança, repositórios e implementações;
* **API** → endpoints, injeção de dependência e documentação.

---

## ⚙️ Tecnologias

* **.NET 8/9**
* **ASP.NET Core Web API**
* **Entity Framework Core (SQL Server)**
* **JWT Authentication**
* **Blazor (Server/Unified)**
* **FluentValidation / MediatR**
* **Swagger para documentação**

---

## 🚀 Execução Local (sem Docker)

### 1. AuthService

```bash
cd AuthService
 dotnet build
 dotnet ef database update -p src/Auth.Infrastructure -s src/Auth.Api
 dotnet run --project src/Auth.Api
```

**Swagger:** [https://localhost:5001/swagger](https://localhost:5001/swagger)

#### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AuthDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Issuer": "AuthService",
    "Audience": "AuthServiceUsers",
    "SecretKey": "MinhaChaveUltraSecretaDe256Bits_123456"
  }
}
```

---

### 2. SuppliersService

```bash
cd SuppliersService
 dotnet build
 dotnet ef database update -p src/Suppliers.Infrastructure -s src/Suppliers.Api
 dotnet run --project src/Suppliers.Api
```

**Swagger:** [https://localhost:5002/swagger](https://localhost:5002/swagger)

#### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SuppliersDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Issuer": "AuthService",
    "Audience": "AuthServiceUsers",
    "SecretKey": "MinhaChaveUltraSecretaDe256Bits_123456"
  }
}
```

---

### 3. SuppliersPortal (Blazor)

```bash
cd SuppliersPortal
 dotnet build
 dotnet run
```

**URL padrão:** [https://localhost:5003](https://localhost:5003)

#### appsettings.json

```json
{
  "AuthApi": { "BaseUrl": "https://localhost:5001" },
  "SuppliersApi": { "BaseUrl": "https://localhost:5002" }
}
```

---

## 🔐 Fluxo de Autenticação

1. O usuário faz login pelo portal (rota `/login`).
2. O `AuthService` valida as credenciais e retorna um token JWT.
3. O Blazor armazena o token em sessão e envia nas próximas requisições.
4. O `SuppliersService` valida o token antes de permitir o acesso.

---

## 📡 Endpoints Principais

### AuthService

* `POST /auth/register` → Cria novo usuário
* `POST /auth/login` → Retorna token JWT

### SuppliersService

* `GET /api/suppliers` → Lista fornecedores
* `POST /api/suppliers` → Cadastra fornecedor
* `GET /api/products` → Lista produtos
* `POST /api/products` → Cadastra produto
* `GET /api/deliveries` → Lista entregas
* `POST /api/deliveries` → Registra entrega

---

## 🧱 Estrutura do Repositório

```
AuthService/
 └── src/
     ├── Auth.Domain/
     ├── Auth.Application/
     ├── Auth.Infrastructure/
     └── Auth.Api/

SuppliersService/
 └── src/
     ├── Suppliers.Domain/
     ├── Suppliers.Application/
     ├── Suppliers.Infrastructure/
     └── Suppliers.Api/

SuppliersPortal/
 ├── Components/
 │   ├── Layout/
 │   └── Pages/
 ├── Models/
 ├── Services/
 └── appsettings.json / Program.cs
```

---

## 🧭 Dicas e Soluções

* **Erro `UseSqlServer`** → Instalar `Microsoft.EntityFrameworkCore.SqlServer`.
* **Erro `ToTable`** → Adicionar `using Microsoft.EntityFrameworkCore;`.
* **Certificado HTTPS** → `dotnet dev-certs https --trust`.
* **Problema com JWT Section** → usar:

  ```csharp
  var section = config.GetSection("Jwt");
  services.Configure<JwtOptions>(o => section.Bind(o));
  ```

---

## 🧪 Teste rápido (Postman/curl)

```bash
# Registrar usuário
curl -k -X POST https://localhost:5001/auth/register \
 -H "Content-Type: application/json" \
 -d '{"email":"admin@demo.com","password":"123456"}'

# Login
TOKEN=$(curl -ks https://localhost:5001/auth/login \
 -H "Content-Type: application/json" \
 -d '{"email":"admin@demo.com","password":"123456"}' | jq -r .token)

# Criar fornecedor
curl -k -X POST https://localhost:5002/api/suppliers \
 -H "Authorization: Bearer $TOKEN" \
 -H "Content-Type: application/json" \
 -d '{"name":"Fornecedor XPTO","cnpj":"12345678000199","email":"contato@xpto.com"}'
```

---

## 🧩 Roadmap

* [x] MVP funcional
* [ ] Adicionar refresh token
* [ ] Implementar testes automatizados
* [ ] Adicionar logs e métricas (Serilog / OpenTelemetry)
* [ ] Criar pipeline CI/CD (GitHub Actions)

---

## 📄 Licença

Projeto educacional — código livre para uso e modificação sob licença **MIT**.
