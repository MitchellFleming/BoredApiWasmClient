FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BoredApiWasmClient/BoredApiWasmClient.csproj", "BoredApiWasmClient/"]
RUN dotnet restore "BoredApiWasmClient/BoredApiWasmClient.csproj"
COPY . .
WORKDIR "/src/BoredApiWasmClient"
RUN dotnet build "BoredApiWasmClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BoredApiWasmClient.csproj" -c Release -o /app/publish

FROM base
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BoredApiWasmClient.dll"]
