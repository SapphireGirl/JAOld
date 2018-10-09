FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 56186
EXPOSE 44386

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Identity/JA.MS.Services.Identity.API/JA.MS.Services.Identity.API.csproj src/Services/Identity/JA.MS.Services.Identity.API/
RUN dotnet restore src/Services/Identity/JA.MS.Services.Identity.API/JA.MS.Services.Identity.API.csproj
COPY . .
WORKDIR /src/src/Services/Identity/JA.MS.Services.Identity.API
RUN dotnet build JA.MS.Services.Identity.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.Services.Identity.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.Services.Identity.API.dll"]
