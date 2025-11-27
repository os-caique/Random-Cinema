# 🎬 Cinema Aleatório

[![C#](https://img.shields.io/badge/C%23-9.0-purple.svg)](https://dotnet.microsoft.com/)
[![API](https://img.shields.io/badge/API-RESTful-green.svg)](https://restfulapi.net/)
[![Architecture](https://img.shields.io/badge/Architecture-Onion-orange.svg)](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/)

## Sobre

O **Cinema Aleatório** é uma API que resolve o [**paradoxo da escolha**](https://www.bbc.com/portuguese/articles/cvgqj3ezllpo) (Schwartz, 2004) no universo cinematográfico. O projeto oferece recomendações de filmes que combinam aleatoriedade e qualidade, eliminando a sobrecarga de decisão para os usuários.

## Características

- Sistema de Avaliação com [Ajuste Bayesiano](https://en.wikipedia.org/wiki/Rule_of_succession)
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


### Prérequisitos
- installed on your machine[Docker](https://docs.docker.com/get-docker/)


## Como Executar

1. **Construa a imagem Docker:**
   ```bash
   docker build -t randomcinema .

2. **Execute o container:**
   ```bash
   docker run -p 8080:8080 randomcinema

3. **Acesse a aplicação:**
 - Abra seu browser e entre através de: ```http://localhost:8080```
