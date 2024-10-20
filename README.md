# Matheus Felipe dos Santos Silva

## 1. Introdução
  
**Objetivo:**  
Este projeto é um teste prático de um processo seletivo interno da empresa Paschoalotto para a vaga de Desenvolvedor BackEnd C# - Jr. O principal objetivo é realizar uma requisição à API RandomUser e persistir os dados em um banco relacional PostgreSQL através de métodos CRUD.

**Tecnologias Utilizadas:**
- .NET
- Entity Framework Core
- PostgreSQL

---

## 2. Configuração do Ambiente

- **SDK:** versão net8.0
- **Banco de Dados:** PostgreSQL
- **IDE:** Visual Studio Code

**Instalação das bibliotecas:**
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0-rc.1.24451.1
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0-rc.1.24451.1
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0-rc.1.24451.1
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0-rc.1
dotnet add package Newtonsoft.Json

---

3. Estrutura do Projeto
 
  Estrutura de pastas:
  PROJETOCASERANDOMUSER
  │
  ├── /caserandomuser                     # Pasta principal do projeto.
  │   ├── /Controller                     # Controladores para gerenciar requisições.
  │   ├── /Data                           
  │       ├── /Migrations                 # Configurações de banco de dados.
  │       └── /AppDbContext.cs            # Classe AppDbContext.
  │   ├── /Entities                       # Classes entidades do banco de dados.
  │   ├── /Models                         # Classes que representam o Json de retorno da API.
  │   ├── /Services                       
  │       ├── /ApiService.cs              # Serviço que realiza requisições da API randomUser.
  │   ├── /wwwroot                        # Arquivos estáticos (HTML, CSS, JavaScript, imagens).
  │   ├── /Properties                     # Propriedades do projeto.
  │   ├── /Program.cs                     # Ponto de entrada da aplicação.
  ├── /projetorandomuser.sln              # Solução do Visual Studio.
  └── /README.md                          # Documentação do projeto.
  

4. Conexão com a API RandomUser
  
  Configuração da API: 
  Utilizado a biblioteca HttpClient que permite enviar e receber solicitações HTTP. 
  Utilizado somente o ENDPOINT /api/ para requisições.

  url utilizada = https://randomuser.me/api/?results=1


5. Persistência de Dados e estrutura das tabelas

  Cadastros - Tabela Pai      # Contém a Primary Key - IdInd
  │
  ├── Names                   # Ligação - Cadastros.IdInt x CaNameEntityId
  ├── Locations               # Ligação - Cadastros.IdInt x LocationEntityId
      ├── Streets             # Ligação - Locations.IdInt x StreetEntityId
      ├── Coordinateses       # Ligação - Locations.IdInt x CoordinateseEntityId
      ├── Timezones           # Ligação - Locations.IdInt x TimezoneEntityId
  ├── Logins                  # Ligação - Cadastros.IdInt x LoginEntityId 
  ├── Dobs                    # Ligação - Cadastros.IdInt x DobEntityId
  ├── Registereds             # Ligação - Cadastros.IdInt x RegisteredEntityId
  ├── Ids                     # Ligação - Cadastros.IdInt x IdEntityId
  └── Pictures                # Ligação - Cadastros.IdInt x PictureEntityId 

  Em AppDbContext:
    - #HasOne(): Configurado ligação entre tabelas conforme modelo acima. 
    - #WithOne(): Configurado a ligação 1 para 1 através de número único - Primary Key de cada tabela. 
    - #OnDelete(): Configurado delete OnCascade para todas as foreign keys.


6. Home Controller
  
  Operações Crud:
  Create: CadastrarUsuarioNoBancoDeDados() - Método HttpPost, método recebe do corpo da requisição([FromBody]) como parâmetro um modelo correspondente a classe entidade e suas subclasses.

  Read: ListarUsuariosCadastrados() - Método HttpGet, método retorna uma lista de usuarios correspondente a classe entidade e suas subclasses.
  
  Update: EditarUsuario() - Método HttpPatch escolhido pois a edição será disponibilizada de forma parcial. Assim como no método de criação, recebe do corpo da requisição([FromBody]) como parametro um modelo correspondente a classe entidade e suas subclasses permitindo a edição do usuário.

  Delete: DeletarUsuario() - Método HttpDelete, recebe um ID como parâmetro na chamada do método, realiza validação de ID nulo e de retorno de pesquisa nulo, existindo o cadastro realiza a remoção dos dados.

  Método que gera novo usuário - GerarNovoUsuario() - Método HttpGet, requisita via ApiService e devolve como retorno objeto correspondente a classe EstruturaApiResponse.cs
  Método de pesquisa por ID - PesquisarUsuarioPorId() - Método HttpGet, realiza a pesquisa em banco de dados trazendo os dados da tabela pai e tabelas filhas do banco de dados.


7. Problemas Conhecidos e Soluções
  
  Método HttpDelete - DeletarUsuario()
  Ao realizar a operação de _context.Cadastros.Remove(usuario) não era realizada a remoção em cascata conforme configurado no Contexto.
  Realizado o Delete em todas as tabelas dentro do meto para o ID correspondênte.


8. Conhecimento adquirido na criação do projeto
  
  Durante a construção do projeto, aprendi alguns pontos importantes, como:
    - Embora já soubesse o conceito de foreign key, nunca havia utilizado, e aprendi a estabelecer ligações no contexto.
    - Adquiri conhecimento do método .Include() e .ThenInclude() da biblioteca Entity Framework Core, que inclui na requisição as tabelas filhas que contém ligação.
    - Conhecido diferença entre HttpPut e HttpPatch.
    - - Aprendi sobre os códigos de status HTTP:
      - **2xx**: Resposta de sucesso.
      - **4xx**: Erro do cliente.
      - **5xx**: Erro do servidor.


9. Referências

  **Bibliotecas instaladas:**
  - [NuGet](https://www.nuget.org/)
  
  **Documentação API RandomUser:**
  - [RandomUser.me Documentation](https://randomuser.me/documentation)

  **Templates HTML:**
  - [Bootstrap Documentation](https://getbootstrap.com/docs/5.3/getting-started/introduction/)
  
  **Documentação do Entity Framework Core:**
  - [Entity Framework Core Docs](https://docs.microsoft.com/en-us/ef/core/)