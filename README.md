# NoteApi
NoteApi is a template project that uses .NET 5 and PostgreSQL via docker compose.

## Features

- Autofac with Microsoft's extension
- Serilog with Microsoft's extension
- JWT implementation

## Installation with docker
### Standard
```sh
git clone https://github.com/bariskisir/NoteApi.git
cd NoteApi
docker-compose up -d
```
Navigate http://localhost/swagger

### Tor hidden service
```sh
git clone https://github.com/bariskisir/NoteApi.git
cd NoteApi
docker-compose -f docker-compose-tor.yml up -d
```
#### Get .onion address
```sh
docker logs noteapi_hiddenservice_1
// phga2tXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXructryd.onion
```
### (Option 1) Testing with Brave Browser
[Brave Browser](https://brave.com/)

### (Option 2) Testing with tor browser
Create tor browser on docker
```sh
docker run -d --name torbrowser -p 5800:5800 domistyle/tor-browser
```
Navigate http://localhost:5800

## Screenshots
### Standard

![Swagger](https://raw.githubusercontent.com/bariskisir/NoteApi/master/assets/swagger.png)

### Tor hidden service
![Swagger-Tor](https://raw.githubusercontent.com/bariskisir/NoteApi/master/assets/swagger-tor.png)

