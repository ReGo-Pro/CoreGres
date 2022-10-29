#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DbMigrator/DbMigrator.csproj", "DbMigrator/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "DbMigrator/DbMigrator.csproj"
COPY . .
WORKDIR "/src/DbMigrator"
RUN dotnet build "DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DbMigrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY ["DbMigrator/wait-for-postgres.sh", "."]
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DbMigrator.dll"]
