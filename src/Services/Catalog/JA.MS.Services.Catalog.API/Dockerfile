FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55679
EXPOSE 44387

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Catalog/JA.MS.Services.Catalog.API/JA.MS.Services.Catalog.API.csproj src/Services/Catalog/JA.MS.Services.Catalog.API/
RUN dotnet restore src/Services/Catalog/JA.MS.Services.Catalog.API/JA.MS.Services.Catalog.API.csproj
COPY . .
WORKDIR /src/src/Services/Catalog/JA.MS.Services.Catalog.API
RUN dotnet build JA.MS.Services.Catalog.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.Services.Catalog.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.Services.Catalog.API.dll"]
