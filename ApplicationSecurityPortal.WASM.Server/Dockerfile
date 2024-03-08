#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApplicationSecurityPortal.WASM.Server/ApplicationSecurityPortal.WASM.Server.csproj", "ApplicationSecurityPortal.WASM.Server/"]
COPY ["ApplicationSecurity.Domain/ApplicationSecurity.Domain.csproj", "ApplicationSecurity.Domain/"]
COPY ["ApplicationSecurityPortal.Application/ApplicationSecurityPortal.Application.csproj", "ApplicationSecurityPortal.Application/"]
COPY ["ApplicationSecurityPortal.Domain/ApplicationSecurityPortal.Domain.csproj", "ApplicationSecurityPortal.Domain/"]
COPY ["ApplicationSecurityPortal.Infrustructure/ApplicationSecurityPortal.Infrustructure.csproj", "ApplicationSecurityPortal.Infrustructure/"]
COPY ["ApplicationSecurityPortal.WASM.Client/ApplicationSecurityPortal.WASM.Client.csproj", "ApplicationSecurityPortal.WASM.Client/"]
RUN dotnet restore "./ApplicationSecurityPortal.WASM.Server/ApplicationSecurityPortal.WASM.Server.csproj"
COPY . .
WORKDIR "/src/ApplicationSecurityPortal.WASM.Server"
RUN dotnet build "./ApplicationSecurityPortal.WASM.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApplicationSecurityPortal.WASM.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApplicationSecurityPortal.WASM.Server.dll"]