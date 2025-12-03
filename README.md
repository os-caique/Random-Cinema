# 🎬 Cinema Aleatório

[![C#](https://img.shields.io/badge/C%23-9.0-purple.svg)](https://dotnet.microsoft.com/)
[![.NET](https://img.shields.io/badge/.NET-6.0-512BD4.svg)](https://dotnet.microsoft.com/)
[![API](https://img.shields.io/badge/API-RESTful-green.svg)](https://restfulapi.net/)
[![Architecture](https://img.shields.io/badge/Architecture-Onion-orange.svg)](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/)
[![Docker](https://img.shields.io/badge/Docker-Enabled-2496ED.svg)](https://www.docker.com/)

## Sobre o Projeto

O **Cinema Aleatório** é uma API RESTful desenvolvida para resolver o [**paradoxo da escolha**](https://www.bbc.com/portuguese/articles/cvgqj3ezllpo) no contexto cinematográfico. Inspirado na teoria de Barry Schwartz (2004), o sistema combina aleatoriedade controlada com um mecanismo de avaliação baseado em estatística bayesiana para oferecer recomendações cinematográficas relevantes, reduzindo a sobrecarga de decisão dos usuários.

## Características

- Seleção Aleatória das páginas de filmes através da TMDB API
- Filtragem por Gênero de Filme
- API com endpoints conforme o padrão RESTfull
- Uso da Regra de Sucessão de Laplace para redução de viés

## Tecnologias

### Backend
- **Linguagem**: C# 9.0+
- **Framework**: .NET 6.0
- **Arquitetura**: Onion Architecture
- **APIs**: RESTful com ASP.NET Core MVC

### Frontend
- **Framework**: Vue.js 3
- **Tipo**: Interface básica para demonstração das funcionalidades


## Como Executar

### Pré-requisitos
- [Docker](https://docs.docker.com/get-docker/) instalado
- Git para clonar o repositório

### Passo-a-passo

1. Clonar o repositório
```
git clone https://github.com/os-caique/Random-Cinema
```

2. Navegar para o diretório do projeto
```
cd cinema-aleatorio
```

3. Construir com Docker
```
docker build -t random-cinema .
```

4. Executar a API
```
docker run -p 5019:8080 random-cinema
```

5. Acessar a aplicação em: 
http://localhost:5019
