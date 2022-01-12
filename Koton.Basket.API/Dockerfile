#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /app
EXPOSE 80

COPY ./Koton.Basket.API/*.csproj Koton.Basket.API/
COPY ./Koton.Basket.Common/*.csproj Koton.Basket.Common/
COPY ./Koton.Basket.Infrastructure/*.csproj Koton.Basket.Infrastructure/
COPY *.sln .

RUN dotnet restore ./Koton.Basket.API/*.csproj
COPY . .
RUN dotnet publish ./Koton.Basket.API/*.csproj -c Release -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /publish .
ENV ASPNET5_URLS="http://*:5000"
ENTRYPOINT ["dotnet", "Koton.Basket.API.dll"]


FROM build AS publish
RUN dotnet publish "Koton.Basket.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
