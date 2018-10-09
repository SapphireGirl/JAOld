FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55974
EXPOSE 44355

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Payment/JA.MS.Services.Payment.API/JA.MS.Services.Payment.API.csproj src/Services/Payment/JA.MS.Services.Payment.API/
RUN dotnet restore src/Services/Payment/JA.MS.Services.Payment.API/JA.MS.Services.Payment.API.csproj
COPY . .
WORKDIR /src/src/Services/Payment/JA.MS.Services.Payment.API
RUN dotnet build JA.MS.Services.Payment.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.Services.Payment.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.Services.Payment.API.dll"]
