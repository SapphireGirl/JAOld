FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55926
EXPOSE 44326

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Location/JA.MS.Services.Location.API/JA.MS.Services.Location.API.csproj src/Services/Location/JA.MS.Services.Location.API/
RUN dotnet restore src/Services/Location/JA.MS.Services.Location.API/JA.MS.Services.Location.API.csproj
COPY . .
WORKDIR /src/src/Services/Location/JA.MS.Services.Location.API
RUN dotnet build JA.MS.Services.Location.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.Services.Location.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.Services.Location.API.dll"]
