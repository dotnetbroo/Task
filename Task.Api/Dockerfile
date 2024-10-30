# Base stage used for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage for the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files for restore
COPY ["Task.Api/Task.Api.csproj", "Task.Api/"]
COPY ["Task.Data/Task.Data.csproj", "Task.Data/"]
COPY ["Task.Domain/Task.Domain.csproj", "Task.Domain/"]
COPY ["Task.Service/Task.Service.csproj", "Task.Service/"]

# Restore dependencies
RUN dotnet restore "Task.Api/Task.Api.csproj"

# Copy all files and build
COPY . .
WORKDIR "/src/Task.Api"
RUN dotnet build "Task.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Task.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage for production
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Task.Api.dll"]
 