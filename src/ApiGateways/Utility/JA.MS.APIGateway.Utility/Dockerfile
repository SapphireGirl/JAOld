FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 59661
EXPOSE 44349

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY src/ApiGateways/Utility/JA.MS.APIGateway.Utility/JA.MS.APIGateway.Utility.csproj src/ApiGateways/Utility/JA.MS.APIGateway.Utility/
RUN dotnet restore src/ApiGateways/Utility/JA.MS.APIGateway.Utility/JA.MS.APIGateway.Utility.csproj
COPY . .
WORKDIR /src/src/ApiGateways/Utility/JA.MS.APIGateway.Utility
RUN dotnet build JA.MS.APIGateway.Utility.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.APIGateway.Utility.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.APIGateway.Utility.dll"]
