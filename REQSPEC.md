# Követelményspecifikáció

## 1. A projekt célja

A projekt célja egy olyan automatizált, end-to-end megoldás megvalósítása, amely a fejlesztéstől a telepítésig lefedi egy egyszerű webalkalmazás teljes életciklusát.

A rendszer egy egyszerű domain modellre épülő nyilvántartó alkalmazás, amely frontend, backend és adatbázis komponensekből áll.

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
- REST API biztosítása CRUD műveletekhez
- MongoDB adatkapcsolat biztosítása

### Adatbázis
- karakterek perzisztens tárolása MongoDB-ben

## 4. Nem funkcionális követelmények

- a frontend és a backend külön komponens legyen
- a komponensek konténerizálhatók legyenek
- a rendszer dokumentáltan futtatható legyen
- a Docker image-ek buildelhetők és publikálhatók legyenek

## 5. Technológiák

- Angular
- ASP.NET Web API
- MongoDB
- Docker
- GitHub Actions
- Kubernetes

## 6. Dokumentáció

A projekthez az alábbi dokumentációk készülnek:
- README
- követelményspecifikáció
- user guide
- telepítési leírás