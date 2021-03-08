#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WidgetMarketplace/WidgetMarketplace.csproj", "WidgetMarketplace/"]
RUN dotnet restore "WidgetMarketplace/WidgetMarketplace.csproj"
COPY . .
WORKDIR "/src/WidgetMarketplace"
RUN dotnet build "WidgetMarketplace.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WidgetMarketplace.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WidgetMarketplace.dll"]