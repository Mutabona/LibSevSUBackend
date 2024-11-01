FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LibSevSUBackend.Api/LibSevSUBackend.Api.csproj", "LibSevSUBackend.Api/"]
RUN dotnet restore "LibSevSUBackend.Api/LibSevSUBackend.Api.csproj"
COPY . .
WORKDIR "/src/LibSevSUBackend.Api"
RUN dotnet build "LibSevSUBackend.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LibSevSUBackend.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibSevSUBackend.Api.dll"]
