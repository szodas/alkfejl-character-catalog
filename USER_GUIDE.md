# User Guide

## A rendszer célja

Az alkalmazás egy egyszerű karakter-nyilvántartó rendszer, amely lehetővé teszi karakterek kezelését webes felületen és külön backend szolgáltatásokon keresztül.

## Elérhető funkciók

### 1. Character List
A kezdőoldalon megjelenik a rendszerben tárolt karakterek listája.

Itt a felhasználó:
- megtekintheti az összes karaktert,
- kiválaszthat egy karaktert,
- szerkesztheti egy karakter adatait,
- törölhet egy karaktert.

### 2. Character Creator
A létrehozó oldalon új karakter vehető fel.

Lépések:
1. Nyisd meg a **Character Creator** oldalt.
2. Add meg a karakter nevét.
3. Kattints a létrehozás gombra.
4. A karakter ezután megjelenik a listában.

### 3. Character Editor
A listából kiválasztott karakter szerkeszthető.

Itt a felhasználó:
- módosíthatja a karakter nevét,
- mentheti a változtatásokat,
- törölheti a karaktert,
- megszakíthatja a szerkesztést.

### 4. Query API
A rendszer tartalmaz egy külön lekérdező backend komponenst is.

Elérhető végpont:
- `http://localhost:5002/character`

Ez a komponens a karakterek lekérdezésére szolgál.

### 5. MCP komponens
A rendszer tartalmaz egy külön MCP-szerű backend komponenst is.

Elérhető végpontok:
- `http://localhost:5003/mcp/tools`
- `http://localhost:5003/mcp/get-characters`
- `http://localhost:5003/mcp/get-character/{id}`
- `http://localhost:5003/mcp/search?pattern=valami`

Ez a komponens külön backend szolgáltatásként biztosítja a karakterek lekérdezését és név szerinti keresését.

## Használat menete

1. Indítsd el a MongoDB-t.
2. Indítsd el a fő backendet.
3. Indítsd el a frontendet.
4. Igény szerint indítsd el a `CharacterQueryApi` és `CharacterMcpServer` komponenseket is.
5. Nyisd meg a frontend felületét böngészőben.
6. Használd a Character List és Character Creator nézeteket.

## Megjegyzés

A rendszer jelenlegi verziója fejlesztési célú, demonstrációs full-stack alkalmazás, több backend komponenssel.