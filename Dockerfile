#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://0.0.0.0:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./src/ServiceHost/ServiceHost.csproj", "ServiceHost/"]
COPY ["./src/HTTP/HTTP.csproj", "HTTP/"]
COPY ["./src/UserManagement/UserManagement.csproj", "UserManagement/"]
COPY ["./src/Shop/Shop.csproj", "Shop/"]

RUN dotnet restore "ServiceHost/ServiceHost.csproj"
COPY ./src .
WORKDIR "/src/ServiceHost"
RUN ls

# Comment following three lines for prod deployment
ENV ASPNETCORE_URLS=http://0.0.0.0:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "run", "--project", "ServiceHost.csproj"]

#RUN dotnet build "ServiceHost.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "ServiceHost.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ServiceHost.dll"]
#COPY --from=build /src .
#ENTRYPOINT ["dotnet run --project ServiceHost\ServiceHost.csproj"]