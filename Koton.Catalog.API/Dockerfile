#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /app
EXPOSE 80

COPY ./Koton.Catalog.API/*.csproj Koton.Catalog.API/
COPY ./Koton.Catalog.Common/*.csproj Koton.Catalog.Common/
COPY ./Koton.Catalog.Infrastructure/*.csproj Koton.Catalog.Infrastructure/
COPY *.sln .

RUN dotnet restore ./Koton.Catalog.API/*.csproj
COPY . .
RUN dotnet publish ./Koton.Catalog.API/*.csproj -c Release -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /publish .
ENV ASPNET5_URLS="http://*:5000"
ENTRYPOINT ["dotnet", "Koton.Catalog.API.dll"]


FROM build AS publish
RUN dotnet publish "Koton.Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
