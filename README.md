# Api-Dot-Net

Desenvolvida em .Net6 - Essa API é apenas uma estrutura a ser usado em projetos.
O "projeto futuro" que a utilizar já iniciara com a arquitura e padrões de maneira simples porém com conceitos utilizados em projetos de grande porte.

ARQUITETUTA e PADRÕES
 - Domain Drive Design - DDD
 - CQRS - Command Query Responsibility Segregation
 - Inversion of Control (IOC)
 - Depency Injection
 - Clean Code / SOLID
 - DTO / Entidades
 - Repository Pattern
 - Testes unitários (entrada, fake repositories, red green refactor, etc)
 - Authentication / Authorization via JWT do google
 - Design By Contracts / domain notifications

PACOTES
 - EFCore - ORM principal
 - EFCore inMemory - validações iniciais
 - Flunt - Validações
 - JwtBearear

 
# Configuração inicial:
A Api conta com autenticação via JWT do Google, mas é possível criar um endpoint para criação do JWT e alterar as configs

O Endponit /Healthz é a porta de entrada da API.<br>
Para inciar os trabalhos com banco de dados basta alterar o arquivo `appsettings.json` adicionando sua ConnectionString.
