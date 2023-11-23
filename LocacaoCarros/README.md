# Sistema de Locação de Veículos

Uma aplicação .NET que simula o processo de locação de veículos, composta por três componentes principais:

- **Back-end (API):** Implementação da API usando ASP.NET Core Web API, responsável por gerenciar dados e fornecer serviços para o front-end.

- **Front-end (MVC):** Aplicação web ASP.NET Core MVC, interagindo com a API e proporcionando uma interface amigável para os usuários.

- **Business (Library):** Biblioteca .NET contendo a lógica de negócio, utilizada pelo back-end para cálculos e operações relacionadas à locação de veículos.

## Estrutura do Projeto

### Back-end
- [Lista de Controllers do Back-end](https://github.com/gabrielmelim/.net-mjv-school/blob/main/LocacaoCarros/LocacaoCarros/Backend/Controllers/controllers.md)
- [Lista de Models do Back-end](https://github.com/gabrielmelim/.net-mjv-school/blob/main/LocacaoCarros/LocacaoCarros/Backend/Models/models.md)
- [Lista de Data do Back-end](https://github.com/gabrielmelim/.net-mjv-school/blob/main/LocacaoCarros/LocacaoCarros/Backend/Data/appDbContext.md)

### Front-end
- [Lista de Controllers do Front-end](frontend/controllers.md)
- [Lista de Views do Front-end](frontend/views.md)
- [Lista de ViewModel do Front-end](frontend/viewmodels.md)

### Business (Library)
- [Lista de Classes de Lógica de Negócio](business/classes.md)
- [Métodos Importantes da Biblioteca](business/methods.md)

## Pré-requisitos

- [.NET Core 6](https://dotnet.microsoft.com/download/dotnet/6.0)

### Configuração e Uso

## Clonando o Repositório

Clone o repositório para obter o código-fonte da aplicação:

```bash
git clone https://github.com/gabrielmelim/.net-mjv-school.git
cd .net-mjv-school
```

### Configurando o Ambiente
Certifique-se de ter o .NET Core 6 instalado no seu sistema.

## Configurando o Back-end (API)

Navegue até o diretório do back-end:

```bash
cd LocacaoCarros/LocacaoCarros/Backend
```
Abra o arquivo de configuração da aplicação, como appsettings.json, e ajuste as configurações, como a string de conexão do banco de dados.<br>

Execute as migrações para criar o banco de dados:<br>
```bash
dotnet ef database update
```

Execute a aplicação:<br>
```bash
dotnet run
```
A API estará em execução em: http://localhost:5000. (verifique a porta localhost do seu sistema)<br>

### Configurando o Front-end (MVC)
## Navegue até o diretório do front-end:

Navegue até o diretório do front-end:<br>
```bash
cd LocacaoCarros/LocacaoCarros/Frontend
```

Abra o arquivo de configuração, ajustando conforme necessário.<br>

Execute a aplicação:
```bash
dotnet run
```
A aplicação MVC estará em execução em: http://localhost:5001. (verifique a porta localhost do seu sistema)
