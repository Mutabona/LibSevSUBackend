FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/LibSevSUBackend.Api/LibSevSUBackend.Api.csproj", "src/LibSevSUBackend.Api/"]
COPY ["src/LibSevSUBackend.AppServices/LibSevSUBackend.AppServices.csproj", "src/LibSevSUBackend.AppServices/"]
COPY ["src/LibSevSUBackend.Contracts/LibSevSUBackend.Contracts.csproj", "src/LibSevSUBackend.Contracts/"]
COPY ["src/LibSevSUBackend.ComponentRegistrar/LibSevSUBackend.ComponentRegistrar.csproj", "src/LibSevSUBackend.ComponentRegistrar/"]
COPY ["src/LibSevSUBackend.Infrastructure/LibSevSUBackend.Infrastructure.csproj", "src/LibSevSUBackend.Infrastructure/"]
COPY ["src/LibSevSUBackend.Domain/LibSevSUBackend.Domain.csproj", "src/LibSevSUBackend.Domain/"]
COPY ["src/LibSevSUBackend.DataAccess/LibSevSUBackend.DataAccess.csproj", "src/LibSevSUBackend.DataAccess/"]
RUN dotnet restore "src/LibSevSUBackend.Api/LibSevSUBackend.Api.csproj"
COPY . .
WORKDIR "/src/src/LibSevSUBackend.Api"
RUN dotnet build "LibSevSUBackend.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LibSevSUBackend.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibSevSUBackend.Api.dll"]
