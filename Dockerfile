#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Hackathon/Server/Hackathon.Server.csproj", "Hackathon/Server/"]
COPY ["Hackathon/Client/Hackathon.Client.csproj", "Hackathon/Client/"]
COPY ["Hackathon/Shared/Hackathon.Domain.csproj", "Hackathon/Shared/"]
COPY ["Hackathon/Hackathon.Application/Hackathon.Application.csproj", "Hackathon/Hackathon.Application/"]
COPY ["Hackathon.IntegrationEvents/Hackathon.IntegrationEvents.csproj", "Hackathon.IntegrationEvents/"]
COPY ["Hackathon/Hackathon.Persistence/Hackathon.Persistence.csproj", "Hackathon/Hackathon.Persistence/"]
RUN dotnet restore "./Hackathon/Server/Hackathon.Server.csproj"
COPY . .
WORKDIR "/src/Hackathon/Server"
RUN dotnet build "./Hackathon.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Hackathon.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hackathon.Server.dll"]