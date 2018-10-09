FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55958
EXPOSE 44310

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Ordering/JA.MS.Services.Ordering.API/JA.MS.Services.Ordering.API.csproj src/Services/Ordering/JA.MS.Services.Ordering.API/
RUN dotnet restore src/Services/Ordering/JA.MS.Services.Ordering.API/JA.MS.Services.Ordering.API.csproj
COPY . .
WORKDIR /src/src/Services/Ordering/JA.MS.Services.Ordering.API
RUN dotnet build JA.MS.Services.Ordering.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.Services.Ordering.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.Services.Ordering.API.dll"]
