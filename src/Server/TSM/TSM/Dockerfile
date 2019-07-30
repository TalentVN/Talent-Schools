FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TSM/TSM.csproj", "TSM/"]
RUN dotnet restore "TSM/TSM.csproj"
COPY . .
WORKDIR "/src/TSM"
RUN dotnet build "TSM.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TSM.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TSM.dll"]