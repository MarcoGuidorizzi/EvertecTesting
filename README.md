# 🗺️ TurismoApp-API

Sistema de gerenciamento de **Pontos Turísticos** com operações completas de cadastro, consulta, edição e remoção de informações.

🎥 [Ver demonstração em vídeo](https://drive.google.com/file/d/18v1nIW341CBN9c60uWcOAGnmv2FbPt6z/view?usp=sharing)

---

## 🛠️ Tecnologias Utilizadas

**Backend**

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

**Frontend**

![React](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)
![Vite](https://img.shields.io/badge/Vite-646CFF?style=for-the-badge&logo=vite&logoColor=white)
![Tailwind CSS](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)

---

## 🏗️ Arquitetura

O backend foi desenvolvido utilizando a **arquitetura em camadas**, separando as responsabilidades da aplicação para melhorar a organização, manutenção e escalabilidade.

```
Controller → Service → Repository → Database
```

| Camada | Responsabilidade |
|---|---|
| **Controller** | Recebe as requisições HTTP e retorna as respostas |
| **Service** | Contém as regras de negócio da aplicação |
| **Repository** | Gerencia o acesso e persistência dos dados |
| **Database** | Banco de dados SQL Server via Entity Framework Core |

---

## 📁 Estrutura do Projeto

```
TurismoApp-API/
├── PontoTuristicoBackEnd/
│   ├── Controllers/
│   ├── Services/
│   ├── Repositories/
│   ├── Models/
│   ├── Data/
│   ├── Migrations/
│   └── appsettings.json
└── PontoTuristicoFrontEnd/
    └── turismoClient/
```

---

## ✅ Funcionalidades

- 📋 Listagem de todos os pontos turísticos
- ➕ Cadastro de novo ponto turístico
- 🔍 Consulta de ponto turístico por ID
- ✏️ Edição de informações de um ponto turístico
- 🗑️ Remoção de ponto turístico

---

## ⚙️ Pré-requisitos

Antes de rodar o projeto, certifique-se de ter instalado:

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

---

## 🚀 Como Rodar o Projeto

### Backend

1. Clone o repositório:
```bash
git clone https://github.com/MarcoGuidorizzi/TurismoApp-API.git
```

2. Acesse a pasta do backend:
```bash
cd TurismoApp-API/PontoTuristicoBackEnd/PontoTuristico
```

3. Configure a string de conexão no arquivo `appsettings.json`, substituindo pelo nome do seu servidor SQL Server:
```json
"ConnectionStrings": {
  "AppDbConnectionString": "Server=SEU_SERVIDOR;Database=PontoTuristicoDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

4. Aplique as migrations para criar o banco de dados:
```bash
dotnet ef database update
```

5. Execute o backend:
```bash
dotnet run
```

A API estará disponível em `https://localhost:7000` (ou conforme configurado no seu ambiente).

---

### Frontend

1. Acesse a pasta do frontend:
```bash
cd TurismoApp-API/PontoTuristicoFrontEnd/turismoClient
```

2. Instale as dependências:
```bash
npm install
```

3. Execute o frontend:
```bash
npm run dev
```

O frontend estará disponível em `http://localhost:5173`.

---

## 👨‍💻 Autor

Feito por **Marco Guidorizzi**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/marco-guidorizzi-314282219/)
[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/MarcoGuidorizzi)
