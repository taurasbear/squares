# Squares API task

## Description

[![ASP.NET Core][ASP.NET Core]][ASP.NET-Core-url]
[![PostgreSQL][PostgreSQL]][PostgreSQL-url]
[![Docker][Docker]][Docker-url]

A simple Squares API with a persistence layer. The point is to find all squares when given a set of points (coordinates on a 2D plane).

## Getting started

### Prerequisites

- **Docker** and **Docker compose** installed on system
- Other Docker services are down (might get porting conflicts)

### Instructions

1. Open a terminal in the project root
2. Launch with:

```sh
docker compose up -d
```

3. Go to `localhost:8000/swagger/index.html` to access Swagger UI

4. _(Optionally)_ You can go to `http://localhost:8080/browser/` to access pgAdmin4 and log in with Username - `admin@example.com` and Password - `admin`

## Highlights

- Clean architecture
- CQRS with **MediatR**
- Mappings with **AutoMapper**
- Exception filters
- Request validation with **FluentValidation**
- Easy setup thanks to Docker

## Possible improvements

- Get rid of lazy-loading (only used it for convenience :p)
- Global exception handler
- Tests (fail to run)
- Replace in-memory tests with a real database
- Calculations are done only with whole numbers which means not all squares are found

## Final thoughts

- Spent around 5 hours in total working on this project
- Prioritised functionality (KISS)
- Had lots of fun :3

[ASP.NET Core]: https://img.shields.io/badge/ASP.NET_Core-20232A?style=for-the-badge&logo=.net&logoColor=512BD4
[ASP.NET-Core-url]: https://dotnet.microsoft.com/en-us/apps/aspnet
[PostgreSQL]: https://img.shields.io/badge/PostgreSQL-20232A?style=for-the-badge&logo=postgresql&logoColor=3178C6
[PostgreSQL-url]: https://www.postgresql.org/
[Docker]: https://img.shields.io/badge/Docker-20232A?style=for-the-badge&logo=docker&logoColor=2496ED
[Docker-url]: https://www.docker.com/
