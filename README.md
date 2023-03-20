<h3 align="center">MyFinance - Práticas de Implementação e Evolução de Software</h3>

---

<p align="center"> Projeto para a diciplina Práticas de Implementação e Evolução de Software escrito em asp dotnet
    <br> 
</p>

## 📝 Conteúdo

- [Sobre](#sobre)
- [Uso](#uso)
- [Construído com](#construido_com)

## 🧐 Sobre <a name = "sobre"></a>

Projeto desenvolvido com o propósito de mostrar a implementação de novas features. Escrito em ASP .NET com o layout usando bootstrap. Com a implementação da feature de gráfico de receitas e despesas com o filtro de datas.
No Readme desse projeto está esperando já um SQLServer rodando dentro de um docker.

## 🏁 Iniciando <a name = "iniciando"></a>

### Prerequisitos

- [Dotnet 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

### Instalação

Dependências e ferramentas usadas para um sistema Unix

- [Docker](https://docs.docker.com/get-docker/)
- [Azure Data Studio](https://azure.microsoft.com/pt-br/products/data-studio)

Para iniciar um serviço de SQL Server no Docker:

```
docker run --name [Nome do seu SQL Server] -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=[Sua senha para o banco de dados]' -e 'MSSQL_PID=[Produto ID: Developer/Express/Standard/Enterprise/EnterpriseCore/]’ -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

## 🎈 Uso <a name="uso"></a>

Trocar para suas reais credenciais de banco de dados no arquivo

```
myfinance-web-netcore/MyFinanceDBContext.cs
```

Comando para iniciar o sistema

```
dotnet run
```

## ⛏️ Construído com <a name = "construido_com"></a>

- [SQLServer](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - Banco de dados
- [Dotnet 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) - Server Framework
- [Bootstrap 5](https://getbootstrap.com/docs/5.0/getting-started/introduction/) - Web Framework
