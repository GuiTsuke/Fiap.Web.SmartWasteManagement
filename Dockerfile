#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# 1. Base image for runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Build image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Fiap.Web.SmartWasteManagement.csproj", "."]
RUN dotnet restore "./Fiap.Web.SmartWasteManagement.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./Fiap.Web.SmartWasteManagement.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Publish the app into a publish folder
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Fiap.Web.SmartWasteManagement.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Final image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Define the ASP.NET Core environment as Production by default
ENV ASPNETCORE_ENVIRONMENT=Production

# Entry point to run the application
ENTRYPOINT ["dotnet", "Fiap.Web.SmartWasteManagement.dll"]