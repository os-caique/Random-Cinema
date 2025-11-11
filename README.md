# 🎬 Cinema Aleatório

[![C#](https://img.shields.io/badge/C%23-9.0-purple.svg)](https://dotnet.microsoft.com/)
[![API](https://img.shields.io/badge/API-RESTful-green.svg)](https://restfulapi.net/)
[![Architecture](https://img.shields.io/badge/Architecture-Onion-orange.svg)](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/)

## Sobre

O **Cinema Aleatório** é uma API inteligente que resolve o [**paradoxo da escolha**](https://www.bbc.com/portuguese/articles/cvgqj3ezllpo) (Schwartz, 2004) no universo cinematográfico. O projeto oferece recomendações de filmes que combinam aleatoriedade com qualidade garantida, eliminando a sobrecarga de decisão para os usuários.

## Características

- Sistema de Avaliação com [ajuste bayesiano](https://en.wikipedia.org/wiki/Rule_of_succession)
- Filtragem por Gênero de Filme
- Onion Architecture
- API RESTful MVC
- Interface básica com Vue.js

## Tecnologias

### Requisitos do Sistema
- **C# 9.0+**
- **.NET 6.0+**
- **Git**

### Frameworks e Bibliotecas
- ASP.NET Core
- Vue.js 3

## Como Executar

```bash
git clone https://github.com/os-caique/random-cinema.git
cd random-cinema

dotnet restore

dotnet run
```
E por fim acesse:
http://localhost:5019
