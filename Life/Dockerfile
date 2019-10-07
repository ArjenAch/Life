FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Life/Life.csproj", "Life/"]
COPY ["Life.Data/Life.Data.csproj", "Life.Data/"]
COPY ["Life.Core/Life.Core.csproj", "Life.Core/"]
COPY ["Life.Application/Life.Application.csproj", "Life.Application/"]
RUN dotnet restore "Life/Life.csproj"
COPY . .
WORKDIR "/src/Life"
RUN dotnet build "Life.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Life.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Life.dll"]