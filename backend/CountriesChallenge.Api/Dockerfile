#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CountriesChallenge.Api/CountriesChallenge.Api.csproj", "CountriesChallenge.Api/"]
RUN dotnet restore "CountriesChallenge.Api/CountriesChallenge.Api.csproj"
COPY . .
WORKDIR "/src/CountriesChallenge.Api"
RUN dotnet build "CountriesChallenge.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CountriesChallenge.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountriesChallenge.Api.dll"]