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
#### Get onion address
```sh
docker exec noteapi_torhiddenservice_1 cat /var/lib/tor/hidden_service/hostname
// phga2tXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXructryd.onion
```
#### Testing tor service
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

