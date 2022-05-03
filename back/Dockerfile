FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build

WORKDIR /app

EXPOSE 5000

COPY * ./

RUN dotnet restore

RUN dotnet publish -c Release -o out

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "MyStore.dll"]