# Deployment Guide

Lokális futtatás

A rendszer három fő komponensből áll:
- frontend
- backend
- MongoDB adatbázis

1. MongoDB indítása Dockerrel

```bash
docker run -d --name character-catalog-mongodb -p 27017:27017 mongo:8
2. Backend indítása
dotnet run --project source/WebApi/WebApi.csproj

A backend alapértelmezett címe:

http://localhost:5000
3. Frontend indítása
cd source/WebUI
npm install
npm start

A frontend általában az alábbi címen érhető el:

http://localhost:4200
ha ez foglalt, Angular másik portot ajánl fel
Használat
Indítsd el a MongoDB-t.
Indítsd el a backendet.
Indítsd el a frontendet.
Nyisd meg a frontend címet a böngészőben.
Használd a Character List és Character Creator nézeteket.


Megjegyzés

A projekt jelenlegi állapotában lokális fejlesztői környezetben futtatható stabilan.
A deployment/ mappa tartalmazza a további konténeres és Kubernetes alapú telepítéshez szükséges fájlokat.