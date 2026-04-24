# Deployment Guide

## Lokális futtatás

A rendszer fő komponensei:
- frontend (`WebUI`)
- fő backend (`WebApi`)
- lekérdező backend (`CharacterQueryApi`)
- MCP backend (`CharacterMcpServer`)
- MongoDB adatbázis

## 1. MongoDB indítása Dockerrel

```bash
docker run -d --name character-catalog-mongodb -p 27017:27017 mongo:8
2. Fő backend indítása lokálisan
dotnet run --project source/WebApi/WebApi.csproj

A fő backend alapértelmezett címe:

http://localhost:5000
2/b. Fő backend futtatása Docker konténerből
docker run --rm -p 5001:5000 -e MongoDb__ConneX="mongodb://host.docker.internal:27017" -e MongoDb__Database="CharacterCatalogDb" character-catalog-webapi:latest

A konténeres fő backend ezen a címen érhető el:

http://localhost:5001/character
3. Frontend indítása lokálisan
cd source/WebUI
npm install
npm start

A frontend általában az alábbi címen érhető el:

http://localhost:4200

Ha ez foglalt, az Angular másik portot ajánl fel.

3/b. Frontend futtatása Docker konténerből
docker run --rm -p 8080:80 character-catalog-webui:latest

A konténeres frontend ezen a címen érhető el:

http://localhost:8080
4. CharacterQueryApi indítása lokálisan
dotnet run --project source/CharacterQueryApi/CharacterQueryApi.csproj

A lekérdező backend ezen a címen érhető el:

http://localhost:5002/character
4/b. CharacterQueryApi futtatása Docker konténerből
docker run --rm -p 5002:5002 -e MongoDb__ConneX="mongodb://host.docker.internal:27017" -e MongoDb__Database="CharacterCatalogDb" character-catalog-queryapi:latest
5. CharacterMcpServer indítása lokálisan
dotnet run --project source/CharacterMcpServer/CharacterMcpServer.csproj

Az MCP backend ezen a címen érhető el:

http://localhost:5003/mcp/tools
5/b. CharacterMcpServer futtatása Docker konténerből
docker run --rm -p 5003:5003 -e MongoDb__ConneX="mongodb://host.docker.internal:27017" -e MongoDb__Database="CharacterCatalogDb" character-catalog-mcpserver:latest

Használat
Indítsd el a MongoDB-t.
Indítsd el a fő backendet.
Indítsd el a frontendet.
Igény szerint indítsd el a CharacterQueryApi és CharacterMcpServer komponenseket is.
Nyisd meg a frontend címet a böngészőben.
Használd a Character List és Character Creator nézeteket.
Megjegyzés

A projekt jelenlegi állapotában lokális fejlesztői környezetben stabilan futtatható.
A deployment/ mappa tartalmazza a további konténeres és Kubernetes alapú telepítéshez szükséges fájlokat.