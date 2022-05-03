FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS base

EXPOSE 5000

FROM base AS build
WORKDIR /src
COPY ./*.sln ./
COPY MyStore.Web/*.csproj /src/MyStore.Web/
COPY MyStore.Core/*.csproj /src/MyStore.Core/

RUN dotnet restore

FROM build AS publish
WORKDIR /src/MyStore.Web
RUN dotnet publish -c Release -o /app
WORKDIR /src/MyStore.Core
RUN dotnet publish -c Release -o /app

FROM publish AS final
WORKDIR /app
COPY --from=final /app .
ENTRYPOINT ["dotnet", "MyStore.dll"]