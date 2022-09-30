FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BoredApiClient/BoredApiClient.csproj", "BoredApiClient/"]
RUN dotnet restore "BoredApiClient/BoredApiClient.csproj"
COPY . .
WORKDIR "/src/BoredApiClient"
RUN dotnet build "BoredApiClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BoredApiClient.csproj" -c Release -o /app/publish

FROM base
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BoredApiClient.dll"]
