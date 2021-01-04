FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY LubyClocker.Api/LubyClocker.Api.csproj LubyClocker.Api/
COPY LubyClocker.Domain/LubyClocker.Domain.csproj LubyClocker.Domain/
COPY LubyClocker.Application/LubyClocker.Application.csproj LubyClocker.Application/
COPY LubyClocker.Infra.Data/LubyClocker.Infra.Data.csproj LubyClocker.Infra.Data/
COPY LubyClocker.CrossCuting.IoC/LubyClocker.CrossCuting.IoC.csproj LubyClocker.CrossCuting.IoC/
COPY LubyClocker.CrossCuting.Shared/LubyClocker.CrossCuting.Shared.csproj LubyClocker.CrossCuting.Shared/

RUN dotnet restore "LubyClocker.Api/LubyClocker.Api.csproj"
COPY . .
WORKDIR "/src/LubyClocker.Api"
RUN dotnet build "LubyClocker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LubyClocker.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LubyClocker.Api.dll"]
