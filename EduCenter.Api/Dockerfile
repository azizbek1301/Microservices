#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EduCenter.Api/EduCenter.Api.csproj", "EduCenter.Api/"]
COPY ["EduCenter.Application/EduCenter.Application.csproj", "EduCenter.Application/"]
COPY ["EduCenter.Domain/EduCenter.Domain.csproj", "EduCenter.Domain/"]
COPY ["EduCenter.Infrastructure/EduCenter.Infrastructure.csproj", "EduCenter.Infrastructure/"]
RUN dotnet restore "./EduCenter.Api/./EduCenter.Api.csproj"
COPY . .
WORKDIR "/src/EduCenter.Api"
RUN dotnet build "./EduCenter.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EduCenter.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduCenter.Api.dll"]