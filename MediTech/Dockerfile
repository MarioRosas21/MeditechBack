# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY MediTech/MediTech.API.csproj ./MediTech/
COPY MediTech.Application/MediTech.Application.csproj ./MediTech.Application/
COPY MediTech.Domain/MediTech.Domain.csproj ./MediTech.Domain/
COPY MediTech.Infrastructure/MediTech.Infrastructure.csproj ./MediTech.Infrastructure/

RUN dotnet restore ./MediTech/MediTech.API.csproj

COPY . .
RUN dotnet publish ./MediTech/MediTech.API.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MediTech.API.dll"]
