FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build-env
WORKDIR /app
COPY ./back/* ./
RUN set -o allexport; source .env; set +o allexport
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MyStore.dll"]