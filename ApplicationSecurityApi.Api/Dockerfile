#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApplicationSecurityApi.Api/ApplicationSecurityApi.Api.csproj", "ApplicationSecurityApi.Api/"]
COPY ["ApplicationSecurity.Application/ApplicationSecurity.Application.csproj", "ApplicationSecurity.Application/"]
COPY ["ApplicationSecurity.Domain/ApplicationSecurity.Domain.csproj", "ApplicationSecurity.Domain/"]
COPY ["ApplicationSecurity.Infrustructure/ApplicationSecurity.Infrustructure.csproj", "ApplicationSecurity.Infrustructure/"]
COPY ["ApplicationSecurity.Persistence/ApplicationSecurity.Persistence.csproj", "ApplicationSecurity.Persistence/"]
RUN dotnet restore "./ApplicationSecurityApi.Api/ApplicationSecurityApi.Api.csproj"
COPY . .
WORKDIR "/src/ApplicationSecurityApi.Api"
RUN dotnet build "./ApplicationSecurityApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApplicationSecurityApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApplicationSecurityApi.Api.dll"]