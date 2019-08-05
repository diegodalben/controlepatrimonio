# Controle de Patrimônios

Este projeto tem como objetivo controlar o cadastro de patrimônios, bem como suas devidas marcas.

Foi desenvolvido uma API em ASP.NET Core 2.2 com endpoints possibilitando as operações de CRUD sobre as entidades Patrimônio e Marca.

Foi utilizado o ADO.Net puro para acesso a dados, possibilitando ganho de performance na realização das operações.

Para a camada de regras de validações de negócio, foi utilizado a biblioteca [FluentValidation](https://fluentvalidation.net/), deixando as validações mais fluídas, de fácil entendimento e manutenção e a redução de "ifs" no código.

Toda exceção ocorrida é capturada e tratada por uma camada global. É retornada uma mensagem genérica ao client e a exceção original é registrada em um arquivo de log (*"./src/Patrimonio.API/Log"*).

## Pré-Requisitos

Para o real funcionamento da solução, é necessário um pré-requisito mínimo com as seguintes ferramentas e Frameworks:

* [.Net Core 2.2](https://www.microsoft.com/net/download)
* [SQL Server 2017](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
* Visual Studio 2017 (15.7) ou Visual Studio Code

## Instalando a aplicação

Para que a solução fique pronta para utilização, são necessários os seguintes passos para instalação:

* Abrir conexão com o seu servidor de SQL, através de uma ferramenta de gerenciamento, e executar o arquivo *".src/Patrimonio.DataAccess/Scripts/14_Criar_Todos_Objetos_BD.sql"*, onde contém um script para a criação de todos os objetos necessários na base de dados.

* Alterar o valor da propriedade "ConnectionString" no arquivo *"./src/Patrimonio.API/appsettings.json"* de acordo com parâmetros para acesso ao seu servidor e instância SQL.

* Compilar a solução para que sejam restaurados os pacotes e dependências dos projetos e também gerados os arquivos binários. Abra o Prompt de Comando, aponte para a pasta da solução *".sln" e execute o seguinte comando:

	> dotnet build

* É necessário executar uma API que é base para o Backend da aplicação.
Ainda no Prompt de Comando e na pasta da solução, navegue até a pasta do projeto da API (*"./src/Patrimonio.API"*) e execute o seguinte comando:

	> dotnet run

	A API ficará disponível na porta 5000: http://localhost:5000 ou https://localhost:5001

## Passos para utilização da aplicação

Não foram desenvolvidas telas para o controle de patrimônios, portanto, será necessário consumir diretamente os endpoints da API através de uma ferramenta REST Client.

Indico a utilização do [Postman](https://www.getpostman.com/downloads/) como ferramenta. Caso opte por ela, no caminho *".src/resource"* contém uma coleção Postman com chamadas aos endpoints da API, que pode ser importada para a ferramenta.

## ROADMAP

A versão atual do produto não contempla todas as features e boas práticas desejadas, contudo, a listagem a seguir apresenta os principais itens para futuros releases:

* Necessidade de Token de acesso a todos os endpoints da API, permitindo acesso somente a usuários ou sistemas autenticados na plataforma;

* Desenvolvimento da suíte de testes, contemplando testes unitários de todas as camadas e testes de integração;

* Configuração do Swagger para documentação da API;

* Como versão inicial, não foram implementadas todas as regras de validações e tratamentos necessários;

* Configuração do Docker para build da API em uma imagem, possibilitando a sua execução em um container Linux
