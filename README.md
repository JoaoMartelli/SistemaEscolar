````markdown
# Sistema Escolar

Este é um projeto em **Windows Forms** com uma **Class Library** para regras de negócio e conexão com o banco de dados SQL Server. O objetivo do projeto é gerenciar informações sobre alunos, escolas e cursos.

## Requisitos

Antes de rodar o projeto, certifique-se de ter os seguintes pré-requisitos:

- **Visual Studio** instalado.
- **.NET Framework 4.7.2**.
- **SQL Server** (local ou em container Docker).

## Como Rodar o Projeto

### Passo 1: Clonar o Repositório

Clone este repositório para o seu computador:

```bash
git clone https://github.com/JoaoMartelli/SistemaEscolar.git
cd SistemaEscolar
````

### Passo 2: Alterar a Connection String

Depois de clonar o repositório, é necessário ajustar a string de conexão no arquivo `App.Config` para apontar para o seu banco de dados.

Abra o arquivo `App.Config` e localize a tag `<connectionStrings>`:

```xml
<connectionStrings>
    <add name="DbConnStr" connectionString="Server=localhost,1433;Initial Catalog=SistemaEscola;User Id=sa;Password=Senha@123;TrustServerCertificate=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

Altere a string de conexão para corresponder às configurações do seu banco de dados.

#### Exemplo de String de Conexão:

```xml
<add name="DbConnStr" connectionString="Server=SEU_SERVIDOR;Initial Catalog=SistemaEscola;User Id=SEU_USUARIO;Password=SUA_SENHA;" providerName="System.Data.SqlClient" />
```

### Passo 3: Criar o Banco de Dados

Para o banco de dados, você tem duas opções: usar um banco local ou criar um container Docker com o SQL Server.

#### 1. Banco Local (SQL Server)

Se você já tem um banco SQL Server configurado, basta executar o script SQL abaixo para criar o banco de dados e as tabelas necessárias.

```sql
CREATE DATABASE SistemaEscola;
GO

USE SistemaEscola;
GO

-- ======================
-- TABELA ALUNO
-- ======================
CREATE TABLE Aluno (
    AlunoId INT IDENTITY(1,1) PRIMARY KEY,
    NomeCompleto NVARCHAR(200) NOT NULL,
    CPF CHAR(11) NOT NULL UNIQUE,
    Endereco NVARCHAR(200),
    Cidade NVARCHAR(100),
    UF CHAR(2),
    DataNascimento DATE,
    Ativo BIT NOT NULL DEFAULT 1
);
GO

-- ======================
-- TABELA ESCOLA
-- ======================
CREATE TABLE Escola (
    EscolaId INT IDENTITY(1,1) PRIMARY KEY,
    NomeCompleto NVARCHAR(200) NOT NULL,
    CNPJ CHAR(14) NOT NULL UNIQUE,
    Endereco NVARCHAR(200),
    Cidade NVARCHAR(100),
    UF CHAR(2),
    DataInauguracao DATE
);
GO

-- ======================
-- TABELA CURSO
-- ======================
CREATE TABLE Curso (
    CursoId INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(150) NOT NULL,
    CargaHoraria INT NOT NULL,
    Instrutor NVARCHAR(150) NOT NULL,
    EscolaId INT NOT NULL,
    Ativo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Curso_Escola FOREIGN KEY (EscolaId) REFERENCES Escola(EscolaId)
);
GO

-- ======================
-- TABELA ALUNO x CURSO (N:N)
-- ======================
CREATE TABLE AlunoCurso (
    AlunoId INT NOT NULL,
    CursoId INT NOT NULL,
    DataMatricula DATE NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_AlunoCurso PRIMARY KEY (AlunoId, CursoId),
    CONSTRAINT FK_AlunoCurso_Aluno FOREIGN KEY (AlunoId) REFERENCES Aluno(AlunoId),
    CONSTRAINT FK_AlunoCurso_Curso FOREIGN KEY (CursoId) REFERENCES Curso(CursoId)
);
GO
```

#### 2. Usando Docker para Criar um Banco SQL Server

Se você não tem um SQL Server instalado, pode facilmente criar um container Docker com o SQL Server utilizando o seguinte comando:

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Senha@123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

Isso irá iniciar um container com o SQL Server em sua máquina. Para conectar no banco dentro do container, use:

* **Servidor**: `localhost,1433`
* **Usuário**: `sa`
* **Senha**: `Senha@123`

Agora, execute o script SQL (mostrado na seção anterior) dentro deste banco de dados.

### Passo 4: Compilar e Rodar o Projeto

Com a conexão ao banco de dados configurada e as tabelas criadas, você já pode compilar e rodar o projeto no Visual Studio.

1. Abra o **Visual Studio**.
2. Selecione **Abrir o Projeto**.
3. Navegue até a pasta do repositório clonado e abra o arquivo do projeto.
4. Compile e execute o projeto.

### Passo 5: Testar a Aplicação

Após rodar a aplicação, você pode interagir com as funcionalidades do sistema de gestão de alunos, escolas e cursos.
