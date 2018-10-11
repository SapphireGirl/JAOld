FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 58494
EXPOSE 44362

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY LoveTheCoffeeHouse/LoveTheCoffeeHouse.csproj LoveTheCoffeeHouse/
RUN dotnet restore LoveTheCoffeeHouse/LoveTheCoffeeHouse.csproj
COPY . .
WORKDIR /src/LoveTheCoffeeHouse
RUN dotnet build LoveTheCoffeeHouse.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish LoveTheCoffeeHouse.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoveTheCoffeeHouse.dll"]
