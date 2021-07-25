# NoteApi
NoteApi is a template project that uses .NET 5 and PostgreSQL via docker compose.

## Features

- Autofac with Microsoft's extension
- Serilog with Microsoft's extension
- JWT implementation

## Installation with docker
```sh
git clone https://github.com/bariskisir/NoteApi.git
cd NoteApi
docker-compose up -d
```
Navigate http://localhost/swagger

![Swagger](https://raw.githubusercontent.com/bariskisir/NoteApi/master/assets/swagger.png)

