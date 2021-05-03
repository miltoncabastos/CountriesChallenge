<h1 align="center">Countries Challenge</h1>

<p align="center"> 🚀 Projeto desenvolvido como desafio técnico para fullstack. </p>

---

<p align="center">
 <a href="#estrutura-de-pastas">Estrutura de pastas</a> •
 <a href="#dependências">Dependências</a> •
 <a href="#tecnologias">Tecnologias</a> • 
 <a href="#observações-importantes">Observações Importantes</a> • 
 <a href="#executando-a-aplicação">Executando a Aplicação</a> • 
 <a href="#sobre-mim">Sobre Mim</a>
</p>

### **Estrutura de Pastas**
- frontend
- backend
- graphcountries
---
### **Dependências**
- [dotnet core 3.1](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.408-windows-x64-installer)
- [nodejs v15](https://nodejs.org/dist/v14.16.1/node-v14.16.1-x64.msi) veja mais em [nodejs.org](https://nodejs.org/pt-br/)
---

### **Tecnologias**
- .Net Core 3.1
    - WebApi
    - Swagger
- ReactJs
    - Redux
    - Hooks
    - Router
- GraphQL
    - Neo4j

---
### **Observações Importantes**
- Para o banco de dados, foi preferível utilizar "InMemory", assim, não precisa existir dependências de nenhum banco de dados em específico e facilita a execução da aplicação para testes rápidos. Caso queira executar utilizando um banco Sql Server, o código existe no arquivo Startup.cs (projeto backend) e basta ter o comentário invertido.

```
//var connectionString = Configuration.GetConnectionString("CountryChallengeCn");

//services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

services.AddDbContext<Context>(options => options.UseInMemoryDatabase("CountryChallenge"));
```
---
### **Executando a Aplicação**
### **Preparativos**
- certifique-se de ter instalado todas dependências.
```
node -v
dotnet --list-sdks
```
- faça o clone deste repositório para o seu computador.
### **executando o backend**
1. acesse a pasta backend com prompt de comando da sua preferência
2. restaure os pacotes da aplicação com `dotnet restore`
3. construa a aplicação com `dotnet build`
4. e execute a aplicação com `dotnet watch run --project ./CountriesChallenge.Api\CountriesChallenge.Api.csproj`
5. verifique se a aplicação está rodando utilizando o swagger em https://localhost:5001/swagger
    - login: admin
    - senha: admin
### **executando graphcountries**

1. acesse a pasta graphcountries com prompt de comando da sua preferência
2. crei um arquivo .env na pasta raiz.
    - para facilitar, deixarei criado um banco de dados online e populado durante uma semana para testes.
    - caso tenha interesse em criar um banco de dados local, veja o passo a passo no [github](https://github.com/lennertVanSever/graphcountries) do repositório original.
    - caso queira criar seu próprio banco de dados online, acesse [neo4j sandbox](https://neo4j.com/sandbox/) e siga o passo a passo.
```
ENGINE_API_KEY=
BOLT_ADDRESS=bolt://54.226.165.95:7687
DB_USERNAME=neo4j
DB_PASSWORD=sterilizers-screen-displacements
```
3. instale as dependências do projeto com `npm install`
4. inicie a aplicação com `npm run dev`  
5. playground disponível em http://localhost:8080/

### Executando o frontend
1. acesse a pasta frontend com prompt de comando da sua preferência
2. instale as dependências do projeto com `npm install`
3. inicie a aplicação com `npm start`
4. a aplicação está disponível em http://localhost:3000

---
### **Sobre Mim**
Olá, eu sou Milton Bastos, sou de Salvador-BA, hoje moro em Blumenau-SC, aqui conheci minha esposa e juntos ganhamos nossa filha Amanda.  
Sou apaixonado por tecnologia e programação, trabalho na área de TI desde os meus 19 anos e atualmente foco em desenvolvimento web utilizando ReactJS e C#.Net