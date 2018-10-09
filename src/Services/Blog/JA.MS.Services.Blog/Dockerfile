FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55652
EXPOSE 44372

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Blog/JA.MS.Services.Blog/JA.MS.Services.Blog.csproj src/Services/Blog/JA.MS.Services.Blog/
RUN dotnet restore src/Services/Blog/JA.MS.Services.Blog/JA.MS.Services.Blog.csproj
COPY . .
WORKDIR /src/src/Services/Blog/JA.MS.Services.Blog
RUN dotnet build JA.MS.Services.Blog.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.Services.Blog.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.Services.Blog.dll"]
