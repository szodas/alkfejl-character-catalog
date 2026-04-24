# alkfejl-character-catalog

## Rövid leírás

Ez a projekt az **Alkalmazásfejlesztés technológiái** tárgy beadandó feladataként készül.  
A cél egy egyszerű, teljes stackes, end-to-end webalkalmazás megvalósítása, amely frontendből, több backend komponensből és adatbázisból áll.

Az alkalmazás egy egyszerű karakter-nyilvántartó rendszert valósít meg, ahol az entitások listázhatók, létrehozhatók, módosíthatók és törölhetők.

## Használt technológiák

- Frontend: Angular + TypeScript
- Backend: ASP.NET Web API + C#
- Adatbázis: MongoDB
- Konténerizáció: Docker
- CI: GitHub Actions
- Registry: GitHub Container Registry (GHCR)
- Deployment: Kubernetes

## Architektúra

A rendszer fő komponensei:

- **WebUI** – Angular alapú frontend
- **WebApi** – fő CRUD backend szolgáltatás
- **CharacterQueryApi** – külön lekérdező backend komponens
- **CharacterMcpServer** – külön MCP-szerű backend komponens
- **MongoDB** – perzisztens adattárolás

## Projektstruktúra

- `source/WebUI` – frontend alkalmazás
- `source/WebApi` – fő backend API
- `source/CharacterQueryApi` – lekérdező backend komponens
- `source/CharacterMcpServer` – MCP backend komponens
- `source/DataAccess` – adatelérési réteg
- `source/Domain` – domain modellek
- `deployment/` – telepítési és futtatási fájlok
- `.github/` – CI workflow-k
- `.devcontainer/` – fejlesztői környezet
- `tools/` – segédszkriptek

## Fő funkciók

- Karakterek listázása
- Új karakter létrehozása
- Karakter módosítása
- Karakter törlése
- Karakterek lekérdezése külön query komponensen keresztül
- Karakterek elérése MCP-szerű külön backend komponensen keresztül

## CI folyamat

A projekt GitHub Actions workflow-kat használ a konténerképek automatikus buildelésére és publikálására.

A workflow-k feladatai:
- a backend komponens Docker image-ének buildelése (`character-catalog-webapi`)
- a frontend komponens Docker image-ének buildelése (`character-catalog-webui`)
- az elkészült image-ek feltöltése a GitHub Container Registry-be (GHCR)

A létrejövő image-ek a saját GitHub repository-hoz tartozó csomagokként érhetők el.

## Dokumentáció

A projekthez tartozik:
- `README.md`
- `REQSPEC.md`
- `USER_GUIDE.md`
- `DEPLOYMENT.md`

## Állapot

A projekt fejlesztés alatt áll.