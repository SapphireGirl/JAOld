FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55934
EXPOSE 44375

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Marketing/JA.MS.Services.Marketing.API/JA.MS.Services.Marketing.API.csproj src/Services/Marketing/JA.MS.Services.Marketing.API/
RUN dotnet restore src/Services/Marketing/JA.MS.Services.Marketing.API/JA.MS.Services.Marketing.API.csproj
COPY . .
WORKDIR /src/src/Services/Marketing/JA.MS.Services.Marketing.API
RUN dotnet build JA.MS.Services.Marketing.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.Services.Marketing.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.Services.Marketing.API.dll"]
