# ---------- STAGE 1: BUILD ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos los csproj en el orden correcto de dependencias
COPY MediTech/MediTech.API.csproj ./MediTech/
COPY MediTech.Application/MediTech.Application.csproj ./MediTech.Application/
COPY MediTech.Domain/MediTech.Domain.csproj ./MediTech.Domain/
COPY MediTech.Infrastructure/MediTech.Infrastructure.csproj ./MediTech.Infrastructure/

# Restauramos dependencias usando el proyecto API como punto de entrada
RUN dotnet restore "MediTech/MediTech.API.csproj"

# Copiamos todo el código
COPY . .

# Build del proyecto (opcional, pero recomendado)
RUN dotnet build "MediTech/MediTech.API.csproj" -c Release -o /app/build

# Publicar el proyecto API
RUN dotnet publish "MediTech/MediTech.API.csproj" -c Release -o /app/publish /p:UseAppHost=false



# ---------- STAGE 2: RUNTIME ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiar archivos publicados
COPY --from=build /app/publish .

# Render expone 10000, pero tu API debe escuchar en 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "MediTech.API.dll"]
