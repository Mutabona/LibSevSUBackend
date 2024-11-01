FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/LibSevSUBackend.DbMigrator/LibSevSUBackend.DbMigrator.csproj", "src/LibSevSUBackend.DbMigrator/"]
COPY ["src/LibSevSUBackend.DataAccess/LibSevSUBackend.DataAccess.csproj", "src/LibSevSUBackend.DataAccess/"]
COPY ["src/LibSevSUBackend.Domain/LibSevSUBackend.Domain.csproj", "src/LibSevSUBackend.Domain/"]
COPY ["src/LibSevSUBackend.Contracts/LibSevSUBackend.Contracts.csproj", "src/LibSevSUBackend.Contracts/"]
COPY ["src/LibSevSUBackend.AppServices/LibSevSUBackend.AppServices.csproj", "src/LibSevSUBackend.AppServices/"]
COPY ["src/LibSevSUBackend.Infrastructure/LibSevSUBackend.Infrastructure.csproj", "src/LibSevSUBackend.Infrastructure/"]
RUN dotnet restore "src/LibSevSUBackend.DbMigrator/LibSevSUBackend.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/LibSevSUBackend.DbMigrator"
RUN dotnet build "LibSevSUBackend.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LibSevSUBackend.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibSevSUBackend.DbMigrator.dll"]
