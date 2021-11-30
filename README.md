# SonarQube + .NET Core

[![SonarQube](https://miro.medium.com/max/1400/1*RCowy6wN9oGxDOy7NRh8lQ.png)](https://www.sonarqube.org/)


### O que é o SonarQube?

O [SonarQube](https://www.sonarqube.org/) é uma plataforma de código aberto desenvolvida pela SonarSource para inspeção contínua da qualidade do código para realizar revisões automáticas com análise estática de código para detectar bugs, códigos cheirosos e vulnerabilidades de segurança em 20+ linguagens de programação.

Ele oferece relatórios sobre código duplicado, padrões de codificação, testes de unidade, cobertura de código, complexidade de código, comentários, bugs e vulnerabilidades de segurança. **(Fonte: Wikipedia)**


### Objetivo

O objetivo desse projeto é apresentar uma breve introdução sobre o SonarQube, através de um exemplo prático de sua utilização na análise de código de uma API de Cadastro de Dados Simples desenvolvida em ASP.NET Core.


### Ambiente

É possível configurar o sonarqube sem necessariamente instalá-lo, utilizando o Docker. Dessa forma, basta clonar ou copiar o arquivo [docker-compose.yml](https://github.com/ingridglima/sonarqube-project/blob/main/docker-compose.yml):

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
 
 Caso não receba a seguinte saída:
 
 ![sonarrodando](https://user-images.githubusercontent.com/95044629/143968246-5875eb20-c960-4b04-9d5b-7630260ac3e8.PNG)

Aqui está um recurso que pode te ajudar: https://github.com/bitnami/bitnami-docker-sonarqube/issues/40 
 
Após conferir que os containers estão rodando corretamente, abra o seu navegador no endereço http://localhost:9000 e realize o login com as seguintes credenciais:
 
> Login: `admin`
> Password: `bitnami`


### Colocando em Prática

#### _Configurando o Sonar_

Quando realizar login, você verá a seguinte tela:

![telaInicial](https://user-images.githubusercontent.com/95044629/143965843-09d14a97-d59a-4426-a4ab-a2e4a9603387.PNG)

Como estamos testando localmente, selecione a seguinte opção:

![criandoprojetomanual](https://user-images.githubusercontent.com/95044629/143965573-fddf216a-976a-4070-8671-a0e00f0ddbf9.PNG)

Insira o nome do projeto, assim como a chave, que desejar:

![criandoprojeto](https://user-images.githubusercontent.com/95044629/143965507-b97aae31-64d1-421b-9b53-42880374b450.PNG)

Selecione "Set Up" e então selecione a seguinte opção:

![criandoprojeto2](https://user-images.githubusercontent.com/95044629/143965534-4ed6bf62-f6af-4573-8ddb-cb4b00ed9ecd.PNG)

Informe a chave que desejar, e então selecione "Generate":

![gerandotoken](https://user-images.githubusercontent.com/95044629/143967021-a9cc4027-db10-44e5-980f-d10c357c9c30.PNG)

Utilizando o bloco de notas copie o token gerado, pois será utilizado posteriormente.

![gerandotoken2](https://user-images.githubusercontent.com/95044629/143967017-3e1e7ecc-4cf2-413b-b303-006d353385e9.PNG)

#### _Conectando o Sonar ao Projeto_

Quanto ao SonarQube, para o .NET Core, existe uma tool nativa, que pode ser instalada através do seguinte comando:

```sh
dotnet tool install --global dotnet-sonarscanner
```
Após finalizada a instalação, abra o terminal e navege até a pasta onde se encontra o arquivo .sln do seu projeto e execute os seguintes comandos:

```sh
dotnet sonarscanner begin /d:sonar.login=TOKEN_GERADO /k:”sonar-pdi-key”

dotnet build

dotnet sonarscanner end /d:sonar.login=TOKEN_GERADO”
```

Você deverá obter saídas como:
![comandos1](https://user-images.githubusercontent.com/95044629/143967922-9244c78c-810a-42ed-ba3b-816912f77ce6.PNG)
![comandos2](https://user-images.githubusercontent.com/95044629/143967920-273d5743-afb4-4056-b7e9-50b848b5b080.PNG)
![comandos3](https://user-images.githubusercontent.com/95044629/143967917-c83aba87-9be7-47a7-88d4-8bd16c041e33.PNG)
![comandos4](https://user-images.githubusercontent.com/95044629/143967924-8b62ed61-a799-4cfb-93b2-125f6e750162.PNG)
![comandos5](https://user-images.githubusercontent.com/95044629/143967923-edfc8425-b5eb-4f55-9745-d376450e9d2f.PNG)

Por fim, navegue até a página inicial do SonarQube, acesse a seção de "Projects" e poderá visualizar um breve resultado da análise de seu projeto:

![dashboardsonar](https://user-images.githubusercontent.com/95044629/143968520-39e433cb-2545-4067-98ed-8cd1d2e3e3ef.PNG)

Se quiser mais detalhes sobre essa análise, selecione o projeto e navegue entre as abas:
![estadodequalidade](https://user-images.githubusercontent.com/95044629/143968684-d572dbe7-45c9-4fa7-9c9e-89acf7f8cff5.PNG)


Como, por exemplo, a aba de "Issues":
![dashboardissue](https://user-images.githubusercontent.com/95044629/143968683-b964abf0-cc0e-40ee-8267-97c9ddaa280f.PNG)


### Conclusão

Com o aumento da importância de uma prática de código limpo, para fins de aumento da produtividade e a diminuição de retrabalhos, bem como bugs encontrados devido a
falta de padrões em código. Ferramentas como o SonarQube acabam se tornando cada vez mais importantes e essenciais na vida dos desenvolvedores de código, uma vez que geram cada vez mais valor dentro da área de desenvolvimento e para seus clientes.
