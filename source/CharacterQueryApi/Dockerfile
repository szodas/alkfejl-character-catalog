FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /App

COPY DataAccess ./DataAccess/
COPY Domain ./Domain/
COPY CharacterQueryApi ./CharacterQueryApi/

RUN dotnet restore CharacterQueryApi/CharacterQueryApi.csproj
RUN dotnet publish CharacterQueryApi/CharacterQueryApi.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build /App/out .
ENV ASPNETCORE_URLS=http://+:5002
EXPOSE 5002
ENTRYPOINT ["dotnet", "CharacterQueryApi.dll"]