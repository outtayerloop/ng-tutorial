FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build

WORKDIR /app

EXPOSE 5000

COPY MyStore.Web/* ./
COPY MyStore.Core/* ./

RUN dotnet restore ./MyStore.Web
RUN dotnet restore ./MyStore.Core

RUN dotnet publish -c Release -o out ./MyStore.Web
RUN dotnet publish -c Release -o out ./MyStore.Core

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "MyStore.dll"]