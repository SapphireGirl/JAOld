FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55370
EXPOSE 44309

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Basket/JA.MS.Services.Basket.API/JA.MS.Services.Basket.API.csproj src/Services/Basket/JA.MS.Services.Basket.API/
RUN dotnet restore src/Services/Basket/JA.MS.Services.Basket.API/JA.MS.Services.Basket.API.csproj
COPY . .
WORKDIR /src/src/Services/Basket/JA.MS.Services.Basket.API
RUN dotnet build JA.MS.Services.Basket.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.Services.Basket.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.Services.Basket.API.dll"]
