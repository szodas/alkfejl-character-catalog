# alkfejl-character-catalog

## Rövid leírás

Ez a projekt az **Alkalmazásfejlesztés technológiái** tárgy beadandó feladataként készül.  
A cél egy egyszerű, teljes stackes, end-to-end webalkalmazás megvalósítása, amely frontendből, backendből és adatbázisból áll.

Az alkalmazás egy egyszerű karakter-nyilvántartó rendszert valósít meg, ahol az entitások listázhatók, létrehozhatók, módosíthatók és törölhetők.

## Használt technológiák

- Frontend: Angular + TypeScript
- Backend: ASP.NET Web API + C#
- Adatbázis: MongoDB
- Konténerizáció: Docker
- CI: GitHub Actions
- Deployment: Kubernetes

## Projektstruktúra

- `source/` – alkalmazás forráskód
- `deployment/` – telepítési és futtatási fájlok
- `.github/` – CI workflow-k
- `.devcontainer/` – fejlesztői környezet
- `tools/` – segédszkriptek

## Fő funkciók

- Karakterek listázása
- Új karakter létrehozása
- Karakter módosítása
- Karakter törlése

## CI folyamat

A projekt GitHub Actions workflow-kat használ a konténerképek automatikus buildelésére és publikálására.

A workflow-k feladatai:
- a backend komponens Docker image-ének buildelése (`character-catalog-webapi`)
- a frontend komponens Docker image-ének buildelése (`character-catalog-webui`)
- az elkészült image-ek feltöltése a GitHub Container Registry-be (GHCR)

A létrejövő image-ek a saját GitHub repository-hoz tartozó csomagokként érhetők el.
## Állapot

A projekt fejlesztés alatt áll.