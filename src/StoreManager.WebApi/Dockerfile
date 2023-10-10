FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AutoDispo.Fresh.WebApi/AutoDispo.Fresh.WebApi.csproj", "AutoDispo.Fresh.WebApi/"]
RUN dotnet restore "AutoDispo.Fresh.WebApi/AutoDispo.Fresh.WebApi.csproj"
COPY . .
WORKDIR "/src/AutoDispo.Fresh.WebApi"
RUN dotnet build "AutoDispo.Fresh.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutoDispo.Fresh.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoDispo.Fresh.WebApi.dll"]
