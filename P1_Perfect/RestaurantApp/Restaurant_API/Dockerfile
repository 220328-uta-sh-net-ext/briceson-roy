#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Restaurant_API/Restaurant_API.csproj", "Restaurant_API/"]
COPY ["RestaurantModel/RestaurantModel.csproj", "RestaurantModel/"]
COPY ["RestaurantDL/RestaurantDL.csproj", "RestaurantDL/"]
COPY ["RestaurantBL/RestaurantBL.csproj", "RestaurantBL/"]
RUN dotnet restore "Restaurant_API/Restaurant_API.csproj"
COPY . .
WORKDIR "/src/Restaurant_API"
RUN dotnet build "Restaurant_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaurant_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurant_API.dll"]