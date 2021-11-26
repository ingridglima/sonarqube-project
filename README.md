# SonarQube + .NET Core

[![SonarQube](https://miro.medium.com/max/1400/1*RCowy6wN9oGxDOy7NRh8lQ.png)](https://www.sonarqube.org/)


### O que é o SonarQube?

O [SonarQube](https://www.sonarqube.org/) é uma plataforma de código aberto desenvolvida pela SonarSource para inspeção contínua da qualidade do código para realizar revisões automáticas com análise estática de código para detectar bugs, códigos cheirosos e vulnerabilidades de segurança em 20+ linguagens de programação.

Ele oferece relatórios sobre código duplicado, padrões de codificação, testes de unidade, cobertura de código, complexidade de código, comentários, bugs e vulnerabilidades de segurança. **(Fonte: Wikipedia)**


### Objetivo

O objetivo desse projeto é apresentar uma breve introdução sobre o SonarQube, através de um exemplo prático de sua utilização na análise de código de uma API de Cadastro de Dados Simples desenvolvida em ASP.NET Core.


### Ambiente

É possível configurar o sonarqube sem necessariamente instalá-lo, utilizando o Docker. Dessa forma, basta clonar ou copiar o arquivo [docker-compose.yml]():

> Obs.: É necessário possuir o [JDK(Java Development Kit) 11](https://www.oracle.com/br/java/technologies/javase/jdk11-archive-downloads.html)  instalado!

```sh
version: '2'
services:
  postgresql:
    image: 'bitnami/postgresql:latest'
    container_name: sonar-db
    ports:
      - '5444:5432'
    volumes:
      - 'postgresql_data:/bitnami'
    environment:
      - ALLOW_EMPTY_PASSWORD=yes
      
  sonarqube:
    image: bitnami/sonarqube:latest
    container_name: sonarqube
    ports:
      - '9000:9000'
    environment:
      - POSTGRESQL_HOST=postgresql
      - POSTGRESQL_PORT=5444
      - POSTGRESQL_ROOT_USER=postgres
      - ALLOW_EMPTY_PASSWORD=yes
      - POSTGRESQL_CLIENT_CREATE_DATABASE_NAME=bitnami_sonarqube
      - POSTGRESQL_CLIENT_CREATE_DATABASE_USERNAME=bn_sonarqube
      - POSTGRESQL_CLIENT_CREATE_DATABASE_PASSWORD=bitnami1234
      - SONARQUBE_DATABASE_NAME=bitnami_sonarqube
      - SONARQUBE_DATABASE_USER=bn_sonarqube
      - SONARQUBE_DATABASE_PASSWORD=bitnami1234
    volumes:
      - sonarqube_data:/bitnami
        
volumes:
  sonarqube_data:
    driver: local
  postgresql_data:
    driver: local
```
  
E então executar o seguinte comando:
  
 ```sh
 docker-compose up -d
 ```
 
Após conferir que os containers estão rodando correntamente, abra o seu navegador no endereço http://localhost:9000 e realize o login com as seguintes credenciais:
 
> Login: `admin`
> Password: `bitnami`


### Colocando em Prática

Quanto ao SonarQube, para o .NET Core, existe uma tool nativa, que pode ser instalada através do seguinte comando:

```sh
dotnet tool install --global dotnet-sonarscanner
```

>PS: colocar as imagens de como criou o projeto no Sonar

Quando finalizar a configuração do projeto, abra o terminal e navege até a pasta onde se encontra o arquivo .sln do seu projeto e execute os seguintes comandos:

```sh
dotnet sonarscanner begin /d:sonar.login=TOKEN_GERADO /k:”sonar-pdi-key”

dotnet build

dotnet sonarscanner end /d:sonar.login=TOKEN_GERADO”
```
> ps: colocar fotos de que o build foi bem sucedido e tals

Por fim, é só navegar de volta até o dashboard do SonarQube e lá estarão os resultados da análise de seu código.

> ps: print do dashboard, com explicações

## _Integração com o Github_