#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

ARG DATABASE_SERVER=${DATABASE_SERVER}
ENV DATABASE_SERVER=${DATABASE_SERVER}

ARG DATABASE_NAME=${DATABASE_NAME}
ENV DATABASE_NAME=${DATABASE_NAME}

ARG DATABASE_USER=${DATABASE_USER}
ENV DATABASE_USER=${DATABASE_USER}

ARG DATABASE_PASSWORD=${DATABASE_PASSWORD}
ENV DATABASE_PASSWORD=${DATABASE_PASSWORD}

ARG JWT_SECRET=${JWT_SECRET}
ENV JWT_SECRET=${JWT_SECRET}

ARG JWT_EXPIRES=${JWT_EXPIRES}
ENV JWT_EXPIRES=${JWT_EXPIRES}

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/eShopCoffe.API/eShopCoffe.API.csproj", "src/eShopCoffe.API/"]
COPY ["src/Services/Identity/eShopCoffe.Identity.Application/eShopCoffe.Identity.Application.csproj", "src/Services/Identity/eShopCoffe.Identity.Application/"]
COPY ["src/Services/Identity/eShopCoffe.Identity.Infra.Data/eShopCoffe.Identity.Infra.Data.csproj", "src/Services/Identity/eShopCoffe.Identity.Infra.Data/"]
COPY ["src/Services/Identity/eShopCoffe.Identity.Domain/eShopCoffe.Identity.Domain.csproj", "src/Services/Identity/eShopCoffe.Identity.Domain/"]
COPY ["src/Shared/eShopCoffe.Core/eShopCoffe.Core.csproj", "src/Shared/eShopCoffe.Core/"]
COPY ["src/Shared/eShopCoffe.Context/eShopCoffe.Context.csproj", "src/Shared/eShopCoffe.Context/"]
COPY ["src/Services/Catalog/eShopCoffe.Catalog.Infra.Data/eShopCoffe.Catalog.Infra.Data.csproj", "src/Services/Catalog/eShopCoffe.Catalog.Infra.Data/"]
COPY ["src/Services/Catalog/eShopCoffe.Catalog.Domain/eShopCoffe.Catalog.Domain.csproj", "src/Services/Catalog/eShopCoffe.Catalog.Domain/"]
COPY ["src/Services/Catalog/eShopCoffe.Catalog.Application/eShopCoffe.Catalog.Application.csproj", "src/Services/Catalog/eShopCoffe.Catalog.Application/"]
RUN dotnet restore "src/eShopCoffe.API/eShopCoffe.API.csproj"
COPY . .
WORKDIR "/src/src/eShopCoffe.API"
RUN dotnet build "eShopCoffe.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eShopCoffe.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "eShopCoffe.API.dll"]