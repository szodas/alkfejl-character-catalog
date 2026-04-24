FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /App

COPY DataAccess ./DataAccess/
COPY Domain ./Domain/
COPY CharacterMcpServer ./CharacterMcpServer/

RUN dotnet restore CharacterMcpServer/CharacterMcpServer.csproj
RUN dotnet publish CharacterMcpServer/CharacterMcpServer.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build /App/out .
ENV ASPNETCORE_URLS=http://+:5003
EXPOSE 5003
ENTRYPOINT ["dotnet", "CharacterMcpServer.dll"]