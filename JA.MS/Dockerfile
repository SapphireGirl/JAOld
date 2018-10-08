FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50981
EXPOSE 44347

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY JA.MS/JA.MS.csproj JA.MS/
RUN dotnet restore JA.MS/JA.MS.csproj
COPY . .
WORKDIR /src/JA.MS
RUN dotnet build JA.MS.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.dll"]
