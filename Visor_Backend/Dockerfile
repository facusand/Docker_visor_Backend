# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copiar archivos del proyecto al contenedor
COPY . .

# Verificar la instalación del SDK
RUN dotnet --info
RUN dotnet --list-sdks
RUN dotnet --list-runtimes
RUN which dotnet

# Verificar la existencia del archivo de proyecto
RUN if [ ! -f "/src/Visor_Backend/Visor_Backend.csproj" ]; then echo "Archivo no encontrado"; exit 1; fi

# Restaurar dependencias y construir proyecto
RUN dotnet restore "/src/Visor_Backend/Visor_Backend.csproj"
RUN dotnet build "/src/Visor_Backend/Visor_Backend.csproj" -c Release -o /app/build
RUN dotnet publish "/src/Visor_Backend/Visor_Backend.csproj" -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7073 

# Crear directorio de recursos y copiar archivos publicados
COPY --from=build /app/publish .
COPY --from=build /src/Visor_Backend/Resources /app/Resources

ENTRYPOINT ["dotnet", "Visor_Backend.dll"]

