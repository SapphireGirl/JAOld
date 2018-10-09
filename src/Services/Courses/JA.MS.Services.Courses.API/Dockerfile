FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55699
EXPOSE 44337

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Courses/JA.MS.Services.Courses.API/JA.MS.Services.Courses.API.csproj src/Services/Courses/JA.MS.Services.Courses.API/
RUN dotnet restore src/Services/Courses/JA.MS.Services.Courses.API/JA.MS.Services.Courses.API.csproj
COPY . .
WORKDIR /src/src/Services/Courses/JA.MS.Services.Courses.API
RUN dotnet build JA.MS.Services.Courses.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JA.MS.Services.Courses.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JA.MS.Services.Courses.API.dll"]
