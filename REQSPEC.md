# Követelményspecifikáció

## 1. A projekt célja

A projekt célja egy olyan automatizált, end-to-end megoldás megvalósítása, amely a fejlesztéstől a telepítésig lefedi egy egyszerű webalkalmazás teljes életciklusát.

A rendszer egy egyszerű domain modellre épülő nyilvántartó alkalmazás, amely frontendből, több backend komponensből és adatbázisból áll.

## 2. Választott domain modell

A projekt egy egyszerű karakter-nyilvántartó rendszert valósít meg.

A rendszerben tárolt entitás főbb adatai:
- azonosító
- név

## 3. Funkcionális követelmények

### Frontend
- karakterek listázása
- új karakter létrehozása
- karakter módosítása
- karakter törlése

### Backend
- fő CRUD REST API biztosítása
- külön lekérdező backend komponens biztosítása
- külön MCP-szerű backend komponens biztosítása
- MongoDB adatkapcsolat biztosítása

### Adatbázis
- karakterek perzisztens tárolása MongoDB-ben

## 4. Nem funkcionális követelmények

- a frontend és a backend külön komponensekből álljon
- a backend több szolgáltatásra bontva is futtatható legyen
- a komponensek Docker konténerként buildelhetők legyenek
- a rendszer dokumentáltan futtatható legyen
- a frontend és backend Docker image-ei GitHub Actions CI workflow segítségével automatikusan buildelhetők legyenek
- az elkészült Docker image-ek GitHub Container Registry-be (GHCR) publikálhatók legyenek
- a rendszer lokális fejlesztői környezetben stabilan futtatható legyen

## 5. Technológiák

- Angular
- ASP.NET Web API
- MongoDB
- Docker
- GitHub Actions
- Kubernetes

## 6. Architektúra

A rendszer fő komponensei:
- WebUI
- WebApi
- CharacterQueryApi
- CharacterMcpServer
- MongoDB

## 7. Dokumentáció

A projekthez az alábbi dokumentációk készülnek:
- README
- követelményspecifikáció
- user guide
- telepítési leírás